using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedSharp.FileSystem.Sys.Interfaces.Models;
using RedSharp.FileSystem.Sys.Interfaces.Services;
using RedSharp.Logging.Sys.Interfaces.Utils;
using RedSharp.Logging.Sys.Models;

namespace RedSharp.Logging.Integration.FileSystem
{
    public class FileSystemBufferedClient : IBufferedClient
    {
        private IFileSystemManager _fileSystemManager;
        private IDirectoryInfo _targetDirectory;

        private long _maxSizeOfLogFile;
        private int _maxFilesCount;

        private ILogFormatter _formatter;

        public void OnNextSession(IEnumerable<LogMessage> messages)
        {

        }
    }
}
