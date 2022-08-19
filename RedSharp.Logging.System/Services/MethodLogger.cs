using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using RedSharp.Logging.Sys.Enums;
using RedSharp.Logging.Sys.Helpers;
using RedSharp.Logging.Sys.Interfaces.Services;
using RedSharp.Logging.Sys.Interfaces.Utils;
using RedSharp.Logging.Sys.Models;
using RedSharp.Sys.Abstracts;
using RedSharp.Sys.Helpers;

namespace RedSharp.Logging.Sys.Services
{
    /// <inheritdoc/>
    public class MethodLogger : DisposableBase, IMethodLogger
    {
        private const String LoggerWasNotDisposed = "Method logger wasn't disposed: {0}.{1}";
        private const String MethodStartMessage = "The method start.";
        private const String MethodEndMessage = "The method end.";
        private const LogLevel MethodStartEndLogLevel = LogLevel.Debug;

        public MethodLogger(ClassLogger parent, LogLevel level, String name, Object metadata = null)
        {
            ArgumentsGuard.ThrowIfNull(parent);
            ArgumentsGuard.ThrowIfNullOrEmpty(name);

            Parent = parent;
            Level = level;
            Name = name;
            Metadata = metadata;

            WriteMethodStart();
        }

        /// <inheritdoc/>
        IClassLogger IMethodLogger.Parent => Parent;

        /// <inheritdoc cref="IMethodLogger.Parent"/>
        public ClassLogger Parent { get; private set; }

        /// <inheritdoc/>
        public LogLevel Level { get; private set; }

        /// <inheritdoc/>
        public Object Metadata { get; }

        /// <inheritdoc/>
        public String Name { get; private set; }

        /// <inheritdoc/>
        public void Write(LogLevel level, String template, Object metadata = null)
        {
            if (level < Level)
                return;

            LoggerGuard.ThrowIfLevelIsNone(level);

            var logEvent = new LogMessage();

            logEvent.lmTemplate = template;
            logEvent.lmLevel = level;
            logEvent.lmType = MessageType.General;
            logEvent.lmMetadata = metadata ?? Metadata;

            WriteMessage(ref logEvent);
        }

        /// <inheritdoc/>
        public void Write<T1>(LogLevel level, String template, T1 arg1, Object metadata = null)
        {
            if (level < Level)
                return;

            LoggerGuard.ThrowIfLevelIsNone(level);

            var logEvent = new LogMessage();

            logEvent.lmTemplate = template;
            logEvent.lmLevel = level;
            logEvent.lmType = MessageType.General;
            logEvent.lmMetadata = metadata ?? Metadata;

            logEvent.lmArgument1 = arg1.ToString();

            WriteMessage(ref logEvent);
        }

        /// <inheritdoc/>
        public void Write<T1, T2>(LogLevel level, String template, T1 arg1, T2 arg2, Object metadata = null)
        {
            if (level < Level)
                return;

            LoggerGuard.ThrowIfLevelIsNone(level);

            var logEvent = new LogMessage();

            logEvent.lmTemplate = template;
            logEvent.lmLevel = level;
            logEvent.lmType = MessageType.General;
            logEvent.lmMetadata = metadata ?? Metadata;

            logEvent.lmArgument1 = arg1.ToString();
            logEvent.lmArgument2 = arg2.ToString();

            WriteMessage(ref logEvent);
        }

        /// <inheritdoc/>
        public void Write<T1, T2, T3>(LogLevel level, String template, T1 arg1, T2 arg2, T3 arg3, Object metadata = null)
        {
            if (level < Level)
                return;

            LoggerGuard.ThrowIfLevelIsNone(level);

            var logEvent = new LogMessage();

            logEvent.lmTemplate = template;
            logEvent.lmLevel = level;
            logEvent.lmType = MessageType.General;
            logEvent.lmMetadata = metadata ?? Metadata;

            logEvent.lmArgument1 = arg1.ToString();
            logEvent.lmArgument2 = arg2.ToString();
            logEvent.lmArgument3 = arg3.ToString();

            WriteMessage(ref logEvent);
        }

        /// <inheritdoc/>
        public void Write<T1, T2, T3, T4>(LogLevel level, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Object metadata = null)
        {
            if (level < Level)
                return;

            LoggerGuard.ThrowIfLevelIsNone(level);

            var logEvent = new LogMessage();

            logEvent.lmTemplate = template;
            logEvent.lmLevel = level;
            logEvent.lmType = MessageType.General;
            logEvent.lmMetadata = metadata ?? Metadata;

            logEvent.lmArgument1 = arg1.ToString();
            logEvent.lmArgument2 = arg2.ToString();
            logEvent.lmArgument3 = arg3.ToString();
            logEvent.lmArgument4 = arg4.ToString();

            WriteMessage(ref logEvent);
        }

        /// <inheritdoc/>
        public void Write<T1, T2, T3, T4, T5>(LogLevel level, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Object metadata = null)
        {
            if (level < Level)
                return;

            LoggerGuard.ThrowIfLevelIsNone(level);

            var logEvent = new LogMessage();

            logEvent.lmTemplate = template;
            logEvent.lmLevel = level;
            logEvent.lmType = MessageType.General;
            logEvent.lmMetadata = metadata ?? Metadata;

            logEvent.lmArgument1 = arg1.ToString();
            logEvent.lmArgument2 = arg2.ToString();
            logEvent.lmArgument3 = arg3.ToString();
            logEvent.lmArgument4 = arg4.ToString();
            logEvent.lmArgument5 = arg5.ToString();

            WriteMessage(ref logEvent);
        }

        /// <summary>
        /// Writes a message about start of the method.
        /// Invokes in constructor or initializer or whatever 
        /// will be invoked on the method logger creation.
        /// </summary>
        private void WriteMethodStart()
        {
            if (MethodStartEndLogLevel < Level)
                return;

            var logEvent = new LogMessage();

            logEvent.lmLevel = MethodStartEndLogLevel;
            logEvent.lmType = MessageType.MethodStart;
            logEvent.lmTemplate = MethodStartMessage;

            WriteMessage(ref logEvent);
        }

        /// <summary>
        /// Writes a message about finish of the method.
        /// Invokes in destructor/dispose
        /// </summary>
        private void WriteMethodEnd()
        {
            if (MethodStartEndLogLevel < Level)
                return;

            var logEvent = new LogMessage();

            logEvent.lmLevel = MethodStartEndLogLevel;
            logEvent.lmType = MessageType.MethodEnd;
            logEvent.lmTemplate = MethodEndMessage;

            WriteMessage(ref logEvent);
        }

        /// <summary>
        /// Adds more information to the log message.
        /// Was created just to simplify process of message filling.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void WriteMessage(ref LogMessage logEvent)
        {
            logEvent.lmTimestamp = DateTimeOffset.Now;
            logEvent.lmService = Parent.Owner.Name;
            logEvent.lmClass = Parent.Name;
            logEvent.lmMethod = Name;

            var thread = Thread.CurrentThread;

            if (String.IsNullOrEmpty(thread.Name))
                logEvent.lmThread = thread.ManagedThreadId.ToString();
            else
                logEvent.lmThread = thread.Name;

            Parent.Owner.OnNextLog(ref logEvent);
        }

        protected override void InternalDispose(bool manual)
        {
            if (manual)
                WriteMethodEnd();
            else
                Write(LogLevel.Error, LoggerWasNotDisposed, Parent.Name, Name);

            base.InternalDispose(manual);
        }
    }
}
