using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CompareFolders
{
    static class Printer
    {
        static public void PrintProgress(string fileCount1, string fileCount2, string currentFile)
        {
            Console.CursorTop = 3;
            Console.WriteLine("В первой папке обработано {0} файлов", fileCount1);
            Console.CursorTop = 4;
            Console.WriteLine("Во второй папке обработано {0} файлов\n", fileCount2);
            Console.CursorTop = 6;
            ClearCurrentConsoleLine();
            Console.WriteLine("Текущий файл: {0}\n", currentFile);

        }
        static public void PrintHeader()
        {
            Console.WriteLine("Сравнение папок [версия " + GetAssemblyVersion() + "]");
            Console.WriteLine("Автор: Михаил Даньшин, (с) 2015");
        }
        static public void PrintErrorr()
        {
            Console.WriteLine("\nОШИБКА: Аргументы заданы неверно\n");
            Console.WriteLine("Пример использования: CompareFolders.exe c:\\folder1 c:\\folder2 [/quite] [/print]\n");
            Console.WriteLine("Для вывода справки используйте ключ /?");
        }
        static public void PrintHelp()
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
        static private string GetAssemblyVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            return version;
        }
        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth * (Console.WindowHeight-7)));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
