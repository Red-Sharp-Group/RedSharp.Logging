using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using RedSharp.Logging.Sys.Enums;

namespace RedSharp.Logging.Sys.Interfaces.Services
{
    /// <summary>
    /// Logger that is created specially for a single instance.
    /// </summary>
    public interface IClassLogger
    {
        /// <summary>
        /// Logger with upper type which own this.
        /// </summary>
        ILoggerService Owner { get; }

        /// <summary>
        /// Current level of logging.
        /// </summary>
        LogLevel Level { get; }

        /// <summary>
        /// Meta-data which will be passed on <see cref="IMethodLogger"/> creation.
        /// </summary>
        Object Metadata { get; }

        /// <summary>
        /// Class name.
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Creates a new method logger with meta-data from class.
        /// </summary>
        IMethodLogger CreateMethodLogger([CallerMemberName] String methodName = null);

        /// <summary>
        /// Creates a new method logger with input meta-data.
        /// </summary>
        /// <remarks>
        /// Meta-data will be passed as is, without checks on null or something like that.
        /// </remarks>
        IMethodLogger CreateMethodLoggerWithMetadata(Object metadata, [CallerMemberName] String methodName = null);
    }
}
