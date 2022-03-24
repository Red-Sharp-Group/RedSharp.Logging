using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RedSharp.Logging.Sys.Enums;
using RedSharp.Logging.Sys.Interfaces.Services;
using RedSharp.Logging.Sys.Interfaces.Utils;
using RedSharp.Logging.Sys.Models;
using RedSharp.Sys.Helpers;

namespace RedSharp.Logging.Sys.Services
{
    public class LoggerService : ILoggerService
    {
        public static readonly DummyMethodLogger DummyMethodLogger = new DummyMethodLogger();

        private ILoggerClient[] _clients;

        public LoggerService(String name, Object metadata)
        {
            ArgumentsGuard.ThrowIfNullOrEmpty(name);

            Name = name;
            Metadata = metadata;
        }

        /// <inheritdoc/>
        public LogLevel Level { get; set; }

        /// <inheritdoc/>
        public String Name { get; private set; }

        /// <inheritdoc/>
        public Object Metadata { get; private set; }

        /// <inheritdoc/>
        public IClassLogger CreateClassLogger([CallerMemberName] String className = null)
        {
            return new ClassLogger(this, className, Metadata);
        }

        /// <inheritdoc/>
        public IClassLogger CreateClassLoggerWithMetadata(Object metadata, [CallerMemberName] String className = null)
        {
            return new ClassLogger(this, className, metadata);
        }

        internal void OnNextLog(ref LogMessage message)
        {
            for (int i = 0; i < _clients.Length; i++)
                _clients[i].OnNextLog(ref message);
        }
    }
}
