using System;
using System.Collections.Generic;
using System.Text;

namespace RedSharp.Logging.Sys.Enums
{
    /// <summary>
    /// Type of a log message.
    /// </summary>
    public enum MessageType : short
    {
        /// <summary>
        /// Internal message.
        /// </summary>
        None,

        /// <summary>
        /// General message. 
        /// </summary>
        General,

        /// <summary>
        /// Internal message, generates by method logger.
        /// Creates on method logger creation.
        /// </summary>
        MethodStart,

        /// <summary>
        /// Internal message, generates by method logger.
        /// Creates on method logger disposing.
        /// </summary>
        MethodEnd
    }
}
