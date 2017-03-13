using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace CompareFolders
{
    public class FilesTables
    {
        private string Path { get; }
        private List<FileEntity> FilesHashList { get; set; }
        private List<FileEntity> FilesSkipedList { get; set; }

        public FilesTables(string path)
        {
            Path = path;
        }

        public void Create()
        {
            var files = Directory.GetFiles(Path);
        }

        public List<FileEntity> GetFilesHashList()
        {
            FillTables(Path);
            return FilesHashList;
        }

        public List<FileEntity> GetFilesSkipedList(string path)
        {
            return FilesHashList;
        }

        private void FillTables(string path)
        {

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
