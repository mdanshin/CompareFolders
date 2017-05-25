using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace CompareFolders
{
    public class HashFilesTables
    {
        private const int MinFileSize = 1; //Size in bytes
        private const long MaxFileSize = 104857600; //Size in bytes

        private string PathFirst { get; }
        private string PathSecond { get; }
        private List<FileEntity> FilesListHashFirst { get; set; }
        private List<FileEntity> FilesListHashSecond { get; set; }
        private List<FileEntity> FilesListSkipped { get; set; }

        public HashFilesTables(string[] args)
        {
            PathFirst = args[0];
            PathSecond = args[1];
        }

        public void Begin(string output="console")
        {
            throw new NotImplementedException();
        }

        public List<FileEntity> GetFilesList(string kindFilesList)
        {
            throw new NotImplementedException();
        }

        public List<FileEntity> GetUnique()
        {
            throw new NotImplementedException();
        }

        private void FillTables(string path)
        {
            throw new NotImplementedException();
        }

        private string GetFileHash(string path)
        {
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(path))
                    {
                        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                    }
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                return null;
            }
        }
    }
}
