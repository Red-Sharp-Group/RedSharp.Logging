using System;
using System.Collections.Generic;
using System.Text;
using RedSharp.Logging.Sys.Models;

namespace RedSharp.Logging.Sys.Interfaces.Utils
{
    public interface ILoggerClient
    {
        void OnNextLog(ref LogMessage message);
    }
}
