using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedSharp.Logging.Sys.Enums;
using RedSharp.Logging.Sys.Interfaces.Utils;
using RedSharp.Logging.Sys.Models;

namespace RedSharp.Logging.Integration.FileSystem
{
    public class StringLogFormatter : ILogFormatter
    {
        private const char StartSectionChar = '↘';
        private const char EndSectionChar = '↙';

        private const String FormatterType = "log";
        private const int FirstPartSize = 70;
        private const int SecondPartSize = 20 + FirstPartSize;
        private const int IntervalSize = 4;

        public string Type => FormatterType;

        public void OnNext(ref LogMessage message, TextWriter writer)
        {
            var builder = new StringBuilder();

            builder.Append(message.Timestamp.ToString("yyyy/MM/dd HH:mm:ss fffffff"));
            builder.Append("  |  (");
            builder.Append(message.Thread);
            builder.Append(") ");
            builder.Append(message.Service);
            builder.Append('.');
            builder.Append(message.Class);
            builder.Append('.');
            builder.Append(message.Method);
            builder.Append(' ', Math.Max(FirstPartSize - builder.Length, 0));
            builder.Append("|  ");
            builder.Append(message.Level.ToString());
            builder.Append(' ', Math.Max(SecondPartSize - builder.Length, 0));
            builder.Append("  |  ");

            var currentLength = builder.Length;
            var messageLine = message.Template;

            if (message.Type == MessageType.MethodStart)
            {
                messageLine = $"{StartSectionChar} {message.Method}(...)";
            }
            else if (message.Type == MessageType.MethodEnd)
            {
                messageLine = $"{EndSectionChar} return;";
            }
            else
            {
                if(message.Argument1 != null)
                {
                    var list = new List<String>();

                    if (message.Argument1 != null)
                        list.Add(message.Argument1);

                    if (message.Argument2 != null)
                        list.Add(message.Argument2);

                    if (message.Argument3 != null)
                        list.Add(message.Argument3);

                    if (message.Argument4 != null)
                        list.Add(message.Argument4);

                    if (message.Argument5 != null)
                        list.Add(message.Argument5);

                    messageLine = String.Format(message.Template, list.ToArray());
                }
            }

            var splitted = messageLine.Split('\n');

            for(int i = 0; i < splitted.Length; i++)
            {
                if(i == 0)
                {
                    if(message.Type == MessageType.General)
                        builder.Append(' ', IntervalSize);

                    builder.AppendLine(splitted[i].Trim());
                }
                else
                {
                    if (message.Type == MessageType.General)
                        builder.Append(' ', currentLength + IntervalSize);

                    builder.AppendLine(splitted[i].Trim());
                }
            }

            writer.Write(builder.ToString());
        }
    }
}
