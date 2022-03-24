using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedSharp.Logging.Sys.Enums;
using RedSharp.Logging.Sys.Helpers;
using RedSharp.Logging.Sys.Interfaces.Services;

namespace RedSharp.Logging.Sys.Services
{
    public class DummyMethodLogger : IMethodLogger
    {
        /// <summary>
        /// Dummy object, always returns null.
        /// </summary>
        public IClassLogger Parent => null;

        /// <summary>
        /// Dummy object is created only for <see cref="LogLevel.None"/>
        /// </summary>
        public LogLevel Level => LogLevel.None;

        /// <summary>
        /// Dummy object, always returns null.
        /// </summary>
        public Object Metadata => null;

        /// <summary>
        /// Dummy object, always returns fixed placeholder.
        /// </summary>
        public String Name => "Dummy method logger.";

        /// <summary>
        /// Dummy object, always false.
        /// </summary>
        public bool IsDisposed => false;

        /// <summary>
        /// Dummy object, do nothing.
        /// </summary>
        public void Dispose()
        {
            //DO NOTHING
        }

        /// <summary>
        /// Does only a single foolproof check.
        /// </summary>
        public void Write(LogLevel level, string message, object metadata = null)
        {
            LoggerGuard.ThrowIfLevelIsNone(level);
        }

        /// <inheritdoc cref="Write(LogLevel, string, object)"/>
        public void Write<T1>(LogLevel level, string template, T1 arg1, object metadata = null)
        {
            LoggerGuard.ThrowIfLevelIsNone(level);
        }

        /// <inheritdoc cref="Write(LogLevel, string, object)"/>
        public void Write<T1, T2>(LogLevel level, string template, T1 arg1, T2 arg2, object metadata = null)
        {
            LoggerGuard.ThrowIfLevelIsNone(level);
        }

        /// <inheritdoc cref="Write(LogLevel, string, object)"/>
        public void Write<T1, T2, T3>(LogLevel level, string template, T1 arg1, T2 arg2, T3 arg3, object metadata = null)
        {
            LoggerGuard.ThrowIfLevelIsNone(level);
        }

        /// <inheritdoc cref="Write(LogLevel, string, object)"/>
        public void Write<T1, T2, T3, T4>(LogLevel level, string template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, object metadata = null)
        {
            LoggerGuard.ThrowIfLevelIsNone(level);
        }

        /// <inheritdoc cref="Write(LogLevel, string, object)"/>
        public void Write<T1, T2, T3, T4, T5>(LogLevel level, string template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, object metadata = null)
        {
            LoggerGuard.ThrowIfLevelIsNone(level);
        }
    }
}
