using System.Collections.Generic;
using RedSharp.Logging.Sys.Models;

namespace RedSharp.Logging.Sys.Interfaces.Utils
{
    public interface IBufferedClient
    {
        void OnNextSession(IEnumerable<LogMessage> messages);
    }
}