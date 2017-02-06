﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CompareFolders
{
    public class FilesTables
    {
        private string Path { get; }
        private List<FileEntity> FilesHashList { get; set; }
        private List<FileEntity> FilesSkipedList { get; set; }

        FilesTables(string path)
        {
            Path = path;
        }

        public void Create()
        {
            var files = Directory.GetFiles(Path);
        }

        public List<FileEntity> GetFilesHashList(string path)
        {
            FillTables(path);
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
