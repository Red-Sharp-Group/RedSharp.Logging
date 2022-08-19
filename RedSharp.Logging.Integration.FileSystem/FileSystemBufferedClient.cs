using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedSharp.FileSystem.Sys.Helpers;
using RedSharp.FileSystem.Sys.Interfaces.Models;
using RedSharp.FileSystem.Sys.Interfaces.Services;
using RedSharp.FileSystem.Sys.Utils;
using RedSharp.Logging.Sys.Interfaces.Utils;
using RedSharp.Logging.Sys.Models;
using RedSharp.Sys.Helpers;

namespace RedSharp.Logging.Integration.FileSystem
{
    public class FileSystemBufferedClient : IBufferedClient
    {
        public const int TenMbFileSize = OneMbFileSize * 10;
        public const int OneMbFileSize = 1048576;
        public const int MinFileSize = OneMbFileSize;
        public const int DefaultFileCount = 2;
        public const int MinFileCount = 1;
        public const String SubFileExtension = "bak";

        private IFileSystemManager _fileSystem;
        private FileSystemPath _targetDirectoryPath;

        private ulong _maxSizeOfLogFile;
        private uint _maxFilesCount;

        private ILogFormatter _formatter;

        public FileSystemBufferedClient(IFileSystemManager fileSystem, 
                                        FileSystemPath targetDirectoryPath, 
                                        ILogFormatter formatter, 
                                        ulong maxFileSize = TenMbFileSize, 
                                        uint maxFilesCount = DefaultFileCount)
        {
            ArgumentsGuard.ThrowIfNull(fileSystem);
            ArgumentsGuard.ThrowIfDisposed(fileSystem);
            ArgumentsGuard.ThrowIfNull(targetDirectoryPath);
            ArgumentsGuard.ThrowIfNull(formatter);

            DrivesGuard.ThrowIfPathIsNotAbsolute(targetDirectoryPath);

            _fileSystem = fileSystem;
            _targetDirectoryPath = targetDirectoryPath;

            _maxSizeOfLogFile = Math.Max(maxFileSize, MinFileSize);
            _maxFilesCount = Math.Max(maxFilesCount, MinFileCount);

            _formatter = formatter;
        }

        public void OnNextSession(IEnumerable<LogMessage> messages)
        {
            var directoryInfo = _fileSystem.CreatePathTo(_targetDirectoryPath);

            var tempDictionary = new Dictionary<String, List<LogMessage>>();

            foreach(var item in messages)
            {
                List<LogMessage> buffer;

                if(!tempDictionary.TryGetValue(item.Thread, out buffer))
                {
                    buffer = new List<LogMessage>();

                    tempDictionary.Add(item.Thread, buffer);
                }

                buffer.Add(item);
            }

            var tasks = new List<Task>();

            foreach(var item in tempDictionary)
                tasks.Add(Task.Factory.StartNew(() => WriteLogs(item.Key, item.Value, directoryInfo)));

            Task.WaitAll(tasks.ToArray());
        }

        private void WriteLogs(String thread, List<LogMessage> messages, IDirectoryInfo directory)
        {
            try
            {
                var fileName = $"{thread}.{_formatter.Type.ToLower()}";
                var filePath = directory.Path.Combine(fileName);

                IFileInfo fileInfo;

                if (_fileSystem.IsFileExist(filePath))
                {
                    fileInfo = _fileSystem.GetFile(filePath);

                    if (fileInfo.Size > _maxSizeOfLogFile)
                    {
                        var pathes = new List<FileSystemPath>();

                        for (int i = 0; i < _maxFilesCount; i++)
                        {
                            if (i == 0)
                                pathes.Add(filePath);
                            else if (i == 1)
                                pathes.Add(directory.Path.Combine($"{fileName}.{SubFileExtension}"));
                            else
                                pathes.Add(directory.Path.Combine($"{fileName}.{SubFileExtension}{i - 1}"));
                        }

                        var lastPath = pathes.Last();

                        if (_fileSystem.IsFileExist(lastPath))
                            _fileSystem.Remove(_fileSystem.GetFile(lastPath));

                        if (pathes.Count > 1)
                        {
                            for (int i = pathes.Count - 2; i >= 0; i--)
                            {
                                if (!_fileSystem.IsFileExist(pathes[i]))
                                    continue;

                                _fileSystem.Rename(pathes[i + 1].Name, _fileSystem.GetFile(pathes[i]));
                            }
                        }

                        fileInfo = _fileSystem.CreateFile(fileName, directory);
                    }
                }
                else
                {
                    fileInfo = _fileSystem.CreateFile(fileName, directory);
                }

                using (var stream = _fileSystem.Write(fileInfo))
                {
                    using (var writer = new StreamWriter(stream))
                    {
                        foreach (var item in messages)
                        {
                            var stackItem = item;

                            _formatter.OnNext(ref stackItem, writer);
                        }
                    }
                }
            }
            catch(Exception exception)
            {
                Trace.WriteLine(exception.Message);
                Trace.WriteLine(exception.StackTrace);
            }
        }
    }
}
