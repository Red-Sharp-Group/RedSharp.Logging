using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RedSharp.Logging.Sys.Enums;

namespace RedSharp.Logging.Sys.Interfaces.Services
{
    /// <summary>
    /// Service that is made for a part of an application f.e. for model part in MVVM
    /// </summary>
    public interface ILoggerService
    {
        /// <summary>
        /// Level of logging, with setter, logging can be different for different parts of an application.
        /// </summary>
        LogLevel Level { get; set; }

        /// <summary>
        /// Global meta-data. Will be set in each instance of class logger.
        /// </summary>
        Object Metadata { get; }

        /// <summary>
        /// Name of the part of an application.
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Creates a new class logger, meta-data will be retrieved from service meta-data.
        /// </summary>
        IClassLogger CreateClassLogger([CallerMemberName] String className = null);

        /// <summary>
        /// Creates a new class logger, meta-data has to be defined by user.
        /// </summary>
        IClassLogger CreateClassLoggerWithMetadata(Object metadata, [CallerMemberName] String className = null);
    }
}
