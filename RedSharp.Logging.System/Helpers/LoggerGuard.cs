using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RedSharp.Logging.Sys.Enums;

namespace RedSharp.Logging.Sys.Helpers
{
    public static class LoggerGuard
    {
        /// <summary>
        /// This is a little bit weird that I have the <see cref="LogLevel.None"/> in my list,
        /// but with this level making compares is much easier, BUT I have to exclude this stupid situation,
        /// when someone tries to write a log with none level of logging.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfLevelIsNone(LogLevel level)
        {
            if (level == LogLevel.None)
                throw new ArgumentException("You cannot use None level to write a message.");
        }
    }
}
