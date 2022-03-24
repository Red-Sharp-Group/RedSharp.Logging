using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using RedSharp.Logging.Sys.Interfaces.Utils;
using RedSharp.Logging.Sys.Models;
using RedSharp.Sys.Utils;

namespace RedSharp.Logging.Sys.Utils
{
    public class BufferedLogerClient : ILoggerClient
    {
        private SwapBuffer<LogMessage> _buffer;
        private IBufferedClient[] _clients;
        private Timer _timer;

        public BufferedLogerClient(int concurrentNumber, int bufferSize, TimeSpan timerInterval, IEnumerable<IBufferedClient> clients)
        {
            _buffer = new SwapBuffer<LogMessage>(concurrentNumber, bufferSize, OnBufferSwap);

            _timer = new Timer();
            _timer.Interval = timerInterval.Milliseconds;
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();

            _clients = clients.ToArray();
        }

        public void OnNextLog(ref LogMessage message)
        {
            _buffer.Write(message);
        }

        protected void OnBufferSwap(LogMessage[] messages, int length)
        {
            _timer.Stop();

            var prepared = messages as IEnumerable<LogMessage>;

            if (messages.Length != length)
                prepared = messages.SkipLast(messages.Length - length);

            var sorted = messages.OrderBy(item => item.Timestamp)
                                 .ToArray();

            foreach (var item in _clients)
            {
                try
                {
                    item.OnNextSession(sorted);
                }
                catch (Exception exception)
                {
                    Trace.WriteLine(exception.Message);
                    Trace.WriteLine(exception.StackTrace);
                }
            }

            _timer.Start();
        }

        protected void OnTimerElapsed(object sender, ElapsedEventArgs arguments)
        {
            _timer.Stop();

            var currentLength = _buffer.GetCount();

            if (currentLength > 0)
                _buffer.ExchangeBuffer();
            else
                _timer.Start();
        }
    }
}