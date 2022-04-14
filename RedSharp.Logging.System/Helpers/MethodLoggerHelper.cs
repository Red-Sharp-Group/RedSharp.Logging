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
        /// <summary>
        /// Unwraps the exception and writes all possible information about it
        /// </summary>
        /// <remarks>
        /// Writes <see cref="LogLevel.Error"/> type of logs.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void WriteException(this IMethodLogger logger, Exception exception)
        {
            if (logger.Level <= LogLevel.Error)
            {
                var buidler = new StringBuilder();
                var listOfExceptions = new List<Exception>();

                GetAllExceptionsRecursive(exception, listOfExceptions);

                for(int i = 0; i < listOfExceptions.Count; i++)
                {
                    if (i == 0)
                    {
                        buidler.Append("The exception of type: ");
                    }
                    else
                    {
                        buidler.AppendLine();

                        buidler.Append("Inner exception(");
                        buidler.Append(i);
                        buidler.Append(") type: ");
                    }

                    buidler.Append(listOfExceptions[i].GetType().Name);
                    buidler.AppendLine(" - was thrown.");
                    buidler.AppendLine(listOfExceptions[i].Message);
                    buidler.AppendLine(listOfExceptions[i].StackTrace);
                }

                logger.Write(LogLevel.Error, buidler.ToString());
            }
        }

        /// <summary>
        /// Returns ALL inner exceptions.
        /// </summary>
        /// <remarks>
        /// At least I've tried to do this.
        /// </remarks>
        private static void GetAllExceptionsRecursive(Exception current, List<Exception> exceptions)
        {
            exceptions.Add(current);

            if (current is AggregateException)
            {
                var aggregateException = current as AggregateException;

                foreach(var item in aggregateException.InnerExceptions)
                    GetAllExceptionsRecursive(item, exceptions);

            }
            else if(current.InnerException != null)
            {
                GetAllExceptionsRecursive(current.InnerException, exceptions);
            }
        }
    }
}
