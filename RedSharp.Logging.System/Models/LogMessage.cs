using System;
using System.Collections.Generic;
using System.Text;
using RedSharp.Logging.Sys.Enums;
using RedSharp.Logging.Sys.Interfaces.Utils;

namespace RedSharp.Logging.Sys.Models
{
    public struct LogMessage
    {
        internal DateTimeOffset lmTimestamp;
        internal LogLevel lmLevel;
        internal MessageType lmType;
        internal String lmThread;
        internal String lmService;
        internal String lmClass;
        internal String lmMethod;
        internal String lmTemplate;
        internal String lmArgument1;
        internal String lmArgument2;
        internal String lmArgument3;
        internal String lmArgument4;
        internal String lmArgument5;
        internal Object lmMetadata;

        public DateTimeOffset Timestamp => lmTimestamp;

        public LogLevel Level => lmLevel;

        public MessageType Type => lmType;

        public String Thread => lmThread;

        public String Service => lmService;

        public String Class => lmClass;

        public String Method => lmMethod;

        public String Template => lmTemplate;

        public String Argument1 => lmArgument1;

        public String Argument2 => lmArgument2;

        public String Argument3 => lmArgument3;

        public String Argument4 => lmArgument4;

        public String Argument5 => lmArgument5;

        public Object Metadata => lmMetadata;
    }
}
