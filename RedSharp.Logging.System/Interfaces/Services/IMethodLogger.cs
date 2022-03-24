using System;
using System.Collections.Generic;
using System.Text;
using RedSharp.Logging.Sys.Enums;
using RedSharp.Sys.Interfaces.Shared;

namespace RedSharp.Logging.Sys.Interfaces.Services
{
    /// <summary>
    /// Low level object for logging.
    /// Has to live only during single method invocation.
    /// </summary>
    public interface IMethodLogger : IDisposable, IDisposeIndication
    {
        /// <summary>
        /// Logger with upper type which own this.
        /// </summary>
        IClassLogger Parent { get; }

        /// <summary>
        /// Level of logging with what this logger was created.
        /// </summary>
        /// <remarks>
        /// Will not change during the lifetime of this object.
        /// </remarks>
        LogLevel Level { get; }

        /// <summary>
        /// Preselected meta-data. will be passed if user doesn't pass meta-data explicitly.
        /// </summary>
        Object Metadata { get; }

        /// <summary>
        /// Name of the method for what this logger was created.
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Write log with only message.
        /// </summary>
        /// <remarks>
        /// Better to use in-line helper.
        /// <br/>Meta-data will be passed as is, without checks on null or something like that.
        /// </remarks>
        /// <exception cref="ArgumentException">If you to stupid to use <see cref="LogLevel.None"/></exception>
        void Write(LogLevel level, String message, Object metadata = null);

        /// <summary>
        /// Write log with string format template and one parameter.
        /// </summary>
        /// <inheritdoc cref="Write(LogLevel, string, object)"/>
        void Write<T1>(LogLevel level, String template, T1 arg1, Object metadata = null);

        /// <summary>
        /// Write log with string format template and two parameters.
        /// </summary>
        /// <inheritdoc cref="Write(LogLevel, string, object)"/>
        void Write<T1, T2>(LogLevel level, String template, T1 arg1, T2 arg2, Object metadata = null);

        /// <summary>
        /// Write log with string format template and three parameters.
        /// </summary>
        /// <inheritdoc cref="Write(LogLevel, string, object)"/>
        void Write<T1, T2, T3>(LogLevel level, String template, T1 arg1, T2 arg2, T3 arg3, Object metadata = null);

        /// <summary>
        /// Write log with string format template and four parameters.
        /// </summary>
        /// <inheritdoc cref="Write(LogLevel, string, object)"/>
        void Write<T1, T2, T3, T4>(LogLevel level, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, Object metadata = null);

        /// <summary>
        /// Write log with string format template and five parameters.
        /// </summary>
        /// <inheritdoc cref="Write(LogLevel, string, object)"/>
        void Write<T1, T2, T3, T4, T5>(LogLevel level, String template, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, Object metadata = null);
    }
}
