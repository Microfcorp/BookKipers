using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Библиотеки.Reports
{
     /// <summary>
     /// CSV документ отчета
     /// </summary>
    public class CSVDocument
    {
        /// <summary>
        /// Строки и столбики
        /// </summary>
        public string[][] Data;
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title;

        /// <summary>
        /// Возвращает итоговое значение массива с данными
        /// </summary>
        public string[][] Array
        {
            get
            {
                return ToString().Split('\n').Select(tmp => tmp.Trim().Split(';').Where(tmpa => tmpa != "").ToArray()).ToArray();
            }
        }

        public override string ToString()
        {
            for (int i = Title.Count(tmpa => tmpa == ';'); i < Data.Select(tmpq => tmpq).Max(tmpw => tmpw.Length); i++)
                Title += ";\t";

            string tmp = Title + Environment.NewLine;
            foreach (var item in Data)
            {
                foreach (var item1 in item)
                    tmp += item1 + ";";
                tmp += Environment.NewLine;
            }
            return tmp.Remove(tmp.Length-2,2);
        }
    }
}
