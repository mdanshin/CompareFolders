using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareFolders
{
    //Создаём таблицу хешей первой папки (CreateTable (string filePath, int tableID))
    //Создаём таблицу хешей второй папки (CreateTable (string filePath))
    //Сравниваем две таблицы
    //  Возвращаем разницу (GetDiff)
    //  Возвращаем только уникальные (GetUnique)
    //  Возвращаем одинаковые (GetSame)
    public class Compare
    {
        Hashtable Table1 = new Hashtable();
        Hashtable Table2 = new Hashtable();

        public void CreateTable(string filePath, int tableID)
        {
            if (tableID == 1)
            {

            }
            if (tableID == 2)
            {

            }
        }



    }
}
