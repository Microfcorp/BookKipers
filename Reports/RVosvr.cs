using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Библиотеки.Books;
using Библиотеки.Operators;

namespace Библиотеки.Reports
{
    public class RVosvr : IReports
    {
        public RVosvr()
        {
            Tiles = new List<string>() { "Номер акта возврата", "Дата", "Номер акта реализации" };
        }

        public string Name => "Отчет о возвратах";

        public string Title => "Отчет о возврате книг";

        public List<string> Tiles { get; set; }

        public CSVDocument CSV
        {
            get
            {
                List<List<string>> vs = new List<List<string>>();
                vs.Add(Tiles);

                var t = Settings.Load<Vozvr>(Vozvr.FileArrayName);
                for (int ia = 0; ia < t.Length; ia++)
                {
                    //vs.Add(new List<string>() { cat.ID + "Категория: " + cat.Name });

                    var vozvr = Settings.Load<Vozvr>(Vozvr.FileArrayName).ToList().FindIndex(tmp => tmp.IDRealiz == ia);
                    vs.Add(new List<string>() { ia.ToString(), t[ia].Date.ToString(), t[ia].IDRealiz.ToString() });
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
