using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RedSharp.Logging.Sys.Enums;
using RedSharp.Logging.Sys.Interfaces.Services;

namespace RedSharp.Logging.Sys.Helpers
{
    public static class MethodLoggerHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteException(this IMethodLogger logger, Exception exception)
        {
            if (logger.Level <= LogLevel.Error)
            {
                var buidler = new StringBuilder();
                var lastException = exception;
                var index = 0;

                while(lastException != null)
                {
                    if (index == 0)
                    {
                        buidler.Append("The exception of type: ");
                    }
                    else
                    {
                        buidler.Append("Inner exception(");
                        buidler.Append(index);
                        buidler.Append(") type: ");
                    }

                    buidler.AppendLine(exception.GetType().Name);
                    buidler.AppendLine(" - was thrown.");
                    buidler.AppendLine(exception.Message);
                    buidler.AppendLine(exception.StackTrace);

                    index++;

                    lastException = lastException.InnerException;
                }

                logger.Write(LogLevel.Error, buidler.ToString());
            }
        }
    }
}
