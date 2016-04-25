using System;
using System.Diagnostics;

namespace CompareFolders
{
    internal static class Printer
    {
        public static void PrintProgress(string fileCount1, string fileCount2, string currentFile)
        {
            Console.CursorTop = 3;
            Console.WriteLine($"В первой папке обработано {fileCount1} файлов");
            Console.CursorTop = 4;
            Console.WriteLine($"Во второй папке обработано {fileCount2} файлов\n");
            Console.CursorTop = 6;
            ClearCurrentConsoleLine();
            Console.WriteLine($"Текущий файл: {currentFile}\n");

        }
        public static void PrintHeader()
        {
            Console.WriteLine("Сравнение папок [версия " + GetAssemblyVersion() + "]");
            Console.WriteLine("Автор: Михаил Даньшин, (с) 2015");
        }
        public static void PrintErrorr()
        {
            Console.WriteLine("\nОШИБКА: Аргументы заданы неверно\n");
            Console.WriteLine("Пример использования: CompareFolders.exe c:\\folder1 c:\\folder2 [/quite] [/print]\n");
            Console.WriteLine("Для вывода справки используйте ключ /?");
        }
        public static void PrintHelp()
        {
            Console.WriteLine("\nCOMPAREFOLDERS c:\\folder1 c:\\folder2 [/quite] [/print]\n");
            Console.WriteLine("/quite\tНе запрашивать вывод списка уникальных файлов на экран");
            Console.WriteLine("/print\tВывести список уникальных файлов на экран (используется с ключем /quite)");
            Console.WriteLine("Для сравнения файлов используется алгоритм хеширования MD5.\n");
            Console.WriteLine("В следующей версии:\n");
            Console.WriteLine("/file:filename[.txt]\tВывести список уникальных файлов в файл \t\t\t\t\t(при использовании /quite и /print)\n");
            Console.WriteLine(">>Функция удаления неуникальных файлов");
            Console.WriteLine(">>Функция копирования уникальных файлов в третью папку");

        }
        private static string GetAssemblyVersion()
        {
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            var version = fvi.FileVersion;
            return version;
        }

        private static void ClearCurrentConsoleLine()
        {
            var currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth * (Console.WindowHeight-7)));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
