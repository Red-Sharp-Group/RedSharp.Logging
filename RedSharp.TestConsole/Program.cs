using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RedSharp.FileSystem.Sys.Services;
using RedSharp.FileSystem.Sys.Utils;
using RedSharp.Logging.Integration.FileSystem;
using RedSharp.Logging.Sys.Enums;
using RedSharp.Logging.Sys.Interfaces.Services;
using RedSharp.Logging.Sys.Interfaces.Utils;
using RedSharp.Logging.Sys.Services;
using RedSharp.Logging.Sys.Utils;
using RedSharp.Sys.Utils;

namespace RedSharp.TestConsole
{
    class Program
    {
        static int iterations;

        static void Main(string[] args)
        {
            var path = new FileSystemPath(@"C:\Users\andrii.v.kudriavtsev\Desktop\Logs", false);
            var fileSystem = new LocalFileSystemManager();
            var formatter = new StringLogFormatter();
            var fileSystemClient = new FileSystemBufferedClient(fileSystem, path, formatter);
            var bufferClient = new BufferedLogerClient(5, 50, new TimeSpan(1000000), new IBufferedClient[] { fileSystemClient });
            var logger = new LoggerService("Terminal", null, new ILoggerClient[] { bufferClient });

            logger.Level = LogLevel.Verbose;

            var obj = new Example(logger);

            var task1 = Task.Factory.StartNew(() =>
            {
                Thread.CurrentThread.Name = "First";

                for (int i = 0; i < 60; i++)
                    obj.RunExample(i);
            });

            var task2 = Task.Factory.StartNew(() =>
            {
                Thread.CurrentThread.Name = "Second";

                for (int i = 0; i < 60; i++)
                    obj.RunExample(i);
            });

            Task.WaitAll(task1, task2);
        }
    }

    class Example 
    {
        private IClassLogger _classLogger;

        public Example(ILoggerService service)
        {
            _classLogger = service.CreateClassLogger(nameof(Example));
        }

        public void RunExample(int iteration)
        {
            using var logger = _classLogger.CreateMethodLogger();

            logger.WriteInformation("Test message from iteration #{0}", iteration);
            logger.WriteInformation("Example message from the method.");
            logger.WriteInformation("Incredible,\r\nwhat do you think?");

            RunSubTask(iteration);

            logger.WriteInformation("Example message after another method.");
            logger.WriteInformation("Hope nothing is broken");
        }

        public void RunSubTask(int iteration)
        {
            using var logger = _classLogger.CreateMethodLogger();

            logger.WriteInformation("Still this iteration #{0}", iteration);
            logger.WriteInformation("Still incredible, isn't?");
        }
    }
}
