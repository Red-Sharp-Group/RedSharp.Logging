using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RedSharp.Sys.Utils;

namespace RedSharp.TestConsole
{
    class Program
    {
        static int iterations;

        static void Main(string[] args)
        {
            var buffer = new SwapBuffer<char>(20, 1000, ConsoleWrite, false);

            int a = 0;
            int b = 0;
            int c = 0;
            int d = 0;
            int e = 0;
            int f = 0;
            int g = 0;
            int h = 0;

            var tasks = new List<Task>()
            {
                Task.Factory.StartNew(() => Write(buffer, 'a', ref a)),
                Task.Factory.StartNew(() => Write(buffer, 'b', ref b)),
                Task.Factory.StartNew(() => Write(buffer, 'c', ref c)),
                Task.Factory.StartNew(() => Write(buffer, 'd', ref d)),
                Task.Factory.StartNew(() => Write(buffer, 'e', ref e)),
                Task.Factory.StartNew(() => Write(buffer, 'f', ref f)),
                Task.Factory.StartNew(() => Write(buffer, 'g', ref g)),
                Task.Factory.StartNew(() => Write(buffer, 'h', ref h)),
            };

            Task.WaitAll(tasks.ToArray(), 10000);

            buffer.ExchangeBuffer();

            iterations = a + b + c + d + e + f + g + h;

            Console.WriteLine(iterations);
        }

        static void ConsoleWrite(char[] buffer, int length)
        {
            Console.WriteLine(buffer);
        }

        static void Write(SwapBuffer<char> buffer, char value, ref int counter)
        {
            //for(int i = 0; i < 1000; i++)
            //{
            //    buffer.Write(value);
            //}

            //while(true)
            //  buffer.Write(value);

            while (true)
            {
                //Console.Write(value);
                buffer.Write(value);
                counter++;
            }
        }
    }
}
