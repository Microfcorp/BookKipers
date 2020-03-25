using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Библиотеки.Books;
using Библиотеки.Operators;

namespace Библиотеки.Reports
{
    /// <summary>
    /// Отчет о реализации
    /// </summary>
    public class RRealiz : IReports
    {
        public RRealiz()
        {
            Tiles = new List<string>() { "Номер акта реализации", "Дата", "Книги", "Кому реализовано", "Акт возврата" };
        }

        public string Name => "Отчет о реализации";

        public string Title => "Отчет о реализации книг";

        public List<string> Tiles { get; set; }

        public CSVDocument CSV
        { 
            get 
            {
                List<List<string>> vs = new List<List<string>>();
                vs.Add(Tiles);

                var t = Settings.Load<Realization>(Realization.FileArrayName);
                for (int ia = 0; ia < t.Length; ia++)
                {
                    //vs.Add(new List<string>() { cat.ID + "Категория: " + cat.Name });

                    var kn = "";
                    for (int i = 0; i < t[ia].Articuls.Length; i++)
                    {
                        var c = Settings.Load<Book>(Book.FileArrayName).Where(tmp => tmp.Articul == t[ia].Articuls[i]).First();
                        kn += c.Name + " ("+c.Articul+"), ";
                    }
                    kn = kn.Substring(0, kn.Length - 2);

                    var vozvr = Settings.Load<Vozvr>(Vozvr.FileArrayName).ToList().FindIndex(tmp => tmp.IDRealiz == ia);
                    vs.Add(new List<string>() { ia.ToString(), t[ia].Date.ToString(), kn, t[ia].Persons, vozvr != -1 ? "Есть акт возврата №"+vozvr+" От "+ Settings.Load<Vozvr>(Vozvr.FileArrayName)[vozvr].Date.ToString()+ "" : "Нет акта возврата"});
                }

                var csv = new CSVDocument()
                {
                    Title = Title,
                    Data = vs.Select(tmp => tmp.ToArray()).ToArray(),
                };

                return csv;
            } 
        }
    }
}
