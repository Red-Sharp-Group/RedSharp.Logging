using System;
using System.Collections.Generic;
using System.Text;

namespace RedSharp.Logging.Sys.Enums
{
    /// <summary>
    /// Level of logging. Each level includes all other levels below it.
    /// </summary>
    public enum LogLevel : short
    {
        /// <summary>
        /// This is like a scream. Almost trash information.
        /// </summary>
        Verbose,

        /// <summary>
        /// Information that cannot help solve that issue, just piece of info.
        /// </summary>
        Information,

        /// <summary>
        /// Debug information: method name, list of parameters, values of local variables etc.
        /// </summary>
        Debug,

        /// <summary>
        /// Information about of event or action that may damage execution.
        /// </summary>
        Warning,

        /// <summary>
        /// Unexpected behavior of the algorithm or user.
        /// </summary>
        Error,

        /// <summary>
        /// Uses for exception logging.
        /// </summary>
        Critical,

        /// <summary>
        /// All logging is turned off.
        /// </summary>
        None
    }
}
