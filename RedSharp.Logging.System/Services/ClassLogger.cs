using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using RedSharp.Logging.Sys.Enums;
using RedSharp.Logging.Sys.Interfaces.Services;
using RedSharp.Sys.Helpers;

namespace RedSharp.Logging.Sys.Services
{
    /// <inheritdoc cref="IClassLogger"/>
    public class ClassLogger : IClassLogger
    {
        public ClassLogger(LoggerService loggerService, String name, Object metadata = null)
        {
            ArgumentsGuard.ThrowIfNull(loggerService);
            ArgumentsGuard.ThrowIfNullOrEmpty(name);

            Owner = loggerService;
            Metadata = metadata;
            Name = name;
        }

        /// <inheritdoc/>
        ILoggerService IClassLogger.Owner => Owner;

        /// <inheritdoc cref="IClassLogger.Owner"/>
        public LoggerService Owner { get; private set; }

        /// <inheritdoc/>
        public LogLevel Level => Owner.Level;

        /// <inheritdoc/>
        public String Name { get; private set; }

        /// <inheritdoc/>
        public Object Metadata { get; private set; }

        /// <inheritdoc/>
        /// <remarks>
        /// Will return a dummy method logger if level is <see cref="LogLevel.None"/>
        /// </remarks>
        public IMethodLogger CreateMethodLogger([CallerMemberName] String methodName = null)
        {
            if (Level == LogLevel.None)
                return LoggerService.DummyMethodLogger;
            else
                return new MethodLogger(this, Level, methodName, Metadata);
        }

        /// <inheritdoc/>
        /// <remarks>
        /// Will return a dummy method logger if level is <see cref="LogLevel.None"/>
        /// </remarks>
        public IMethodLogger CreateMethodLoggerWithMetadata(Object metadata, [CallerMemberName] String methodName = null)
        {
            if (Level == LogLevel.None)
                return LoggerService.DummyMethodLogger;
            else
                return new MethodLogger(this, Level, methodName, metadata);
        }
    }
}
