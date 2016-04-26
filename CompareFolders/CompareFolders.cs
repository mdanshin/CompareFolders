﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Collections;
using System.Diagnostics;

//TODO: Ввести классы, сделать нормальные объекты.
namespace CompareFolders
{
    public static class CompareFolders
    {
        #region Declaring variable
        private const string Title = "Сравнение папок";
        private const int MinFileSize = 1; //Size in bytes
        private const long MaxFileSize = 104857600; //Size in bytes

        private static Hashtable TableOfFiles { get; } = new Hashtable();
        private static List<string> SkipedFiles { get; } = new List<string>();

        private static int FileCount1 { get; set; }
        private static int FileCount2 { get; set; }

        private static bool Quite { get; set; }
        private static bool Print { get; set; }

        #endregion

        private static void Main(string[] args)
        {
            ConsoleReady();

            if (args.Length >= 2 && args[0] != "/?")
            {
                #region Start
                if (args.Length >= 3 && args[2] != null && args[2] == "/quite")
                {
                    Quite = true;
                }
                else if (args.Length >= 3 && args[2] != null && args[2] != "/quite")
                {
                    Printer.PrintErrorr();
                    Environment.Exit(0);
                }
                if (args.Length >= 4 && args[3] != null && args[3] == "/print")
                {
                    Print = true;
                }
                else if (args.Length >= 4 && args[3] != null && args[3] != "/print")
                {
                    Printer.PrintErrorr();
                    Environment.Exit(0);
                }

                var watch = new Stopwatch();
                watch.Start();

                //Получаем список файлов из директории a1 и добавляем их в таблицу
                foreach (var file in GetFiles(args[0]))
                {
                    var fileSize = new FileInfo(file).Length;

                    if (fileSize < MaxFileSize & fileSize >= MinFileSize) //TODO:Подумать как оптимизировать, чтобы не делать двойную проверку
                    {
                        //TODO: Дублирование кода!
                        FileCount1++;
                        FillFileTabe(file);
                        Printer.PrintProgress(FileCount1.ToString(), FileCount2.ToString(), file);
                    }
                    else
                    {
                        SkipedFiles.Add(file);
                    }
                }

                //Получаем список файлов из директории a2 и добавляем в таблицу tableOfFiles только те файлы, которых там нет
                foreach (var file in GetFiles(args[1]))
                {
                    var fileSize = new FileInfo(file).Length;

                    if (fileSize < MaxFileSize & fileSize >= MinFileSize) //TODO:Подумать как оптимизировать, чтобы не делать двойную проверку
                    {
                        //TODO: Дублирование кода!
                        FileCount2++;
                        FillFileTabe(file);
                        Printer.PrintProgress(FileCount1.ToString(), FileCount2.ToString(), file);
                    }
                    else
                    {
                        SkipedFiles.Add(file);
                    }
                }

                watch.Stop();
                #endregion

                #region Result
                Console.CursorLeft = 0;
                Console.WriteLine($"Всего обработано {FileCount1 + FileCount2} файлов\n");
                Console.WriteLine($"Найдено уникальных файлов {TableOfFiles.Count}\n");
                Console.WriteLine(
                    $"Время выполнения (чч:мм:сс:мс): {watch.Elapsed.Hours}:{watch.Elapsed.Minutes}:{watch.Elapsed.Seconds}:{watch.Elapsed.Milliseconds}\n");
                Console.WriteLine($"Пропущено {SkipedFiles.Count} файл(ов):");
                foreach (var t in SkipedFiles)
                {
                    Console.WriteLine(t);
                }


                if (TableOfFiles.Count != 0 && Quite && Print)
                {
                    //Вывод на экран получившегося уникального списка значений
                    foreach (DictionaryEntry entry in TableOfFiles)
                    {
                        Console.WriteLine($"{entry.Key}");
                    }
                }
                #endregion

                #region Print

                if (TableOfFiles.Count == 0 || Quite) return;
                {
                    Console.WriteLine("Вывести список уникальных файлов? (y/N)");
                    if (Console.ReadKey(true).Key.ToString() != "Y") return;
                    //Вывод на экран получившегося уникального списка значений
                    foreach (DictionaryEntry entry in TableOfFiles)
                    {
                        Console.WriteLine($"{entry.Key}");
                    }
                }

                #endregion
            }
            else
            {
                if (args.Length != 0 && args[0] == "/?")
                {
                    Printer.PrintHelp();
                }
                else
                {
                    Printer.PrintErrorr();
                }
            }

        }

        private static void ConsoleReady()
        {
            Console.Title = Title;
            Console.Clear();
            Printer.PrintHeader();
        }

        private static IEnumerable<string> GetFiles(string path)
        {
            var queue = new Queue<string>();
            queue.Enqueue(path);
            while (queue.Count > 0)
            {
                path = queue.Dequeue();
                string[] files = null;

                try
                {
                    foreach (var subDir in Directory.GetDirectories(path))
                    {
                        queue.Enqueue(subDir);
                    }

                    files = Directory.GetFiles(path);
                }
                catch (UnauthorizedAccessException)
                {
                    SkipedFiles.Add(path);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine("\n" + ex.Message);
                    if (ex.InnerException != null)
                        Console.Error.WriteLine("\n" + ex.InnerException);
                    Environment.Exit(0);
                }

                if (files == null) continue;
                foreach (var t in files)
                {
                    yield return t;
                }
            }
        }

        private static void FillFileTabe(string file)
        {
            var hash = GetFileHash(file);
            var val = TableOfFiles.ContainsValue(hash);

            if (!val) TableOfFiles.Add(file, hash);
        }
        //Нужно следить за тем, чтобы эта функция вызывалась не более одного раза.
        //Это влияет на производительность.
        //TODO: Возможно стоит организовать SingleTone?
        private static string GetFileHash(string filename)
        {
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filename))
                    {
                        return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
                    }
                }
            }
            catch(Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                //TODO: С точки зрения ООП неправильно размещать в этом блоке логику. Переделать.
                SkipedFiles.Add(filename);
                //TODO: Тут есть проблема. Если в дальнейшем встретится несколько значений null, то они будут восприняты как одинаковые.
                //Возможно стоит организовать какой-то счетчик
                return null;
            }
        }
    }
}
