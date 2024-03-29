﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RedSharp.Logging.Sys.Models;

namespace RedSharp.Logging.Sys.Interfaces.Utils
{
    public interface ILogFormatter
    {
        void OnNext(ref LogMessage message, TextWriter writer);
    }
}
