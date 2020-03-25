using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Библиотеки.Books;

namespace Библиотеки.Reports
{
    /// <summary>
    /// Балансовый отчет
    /// </summary>
    class RBalance : IReports
    {
        public RBalance()
        {
            Tiles = new List<string>() { "Номер", "Категория", "Название", "Артикул", "Всего", "В реализации", "Остаток", "Количество использований" };
        }

        public string Name { get => "Балансовый отчет"; }
        public string Title { get => "Отчет о балансе всех книг"; }
        public List<string> Tiles { get; set; }
        public CSVDocument CSV 
        { 
            get 
            {
                List<List<string>> vs = new List<List<string>>();                             
                vs.Add(Tiles);

                var t = Settings.Load<Categories>(Categories.FileArrayName);
                foreach (var cat in t)
                {
                    //vs.Add(new List<string>() { cat.ID + "Категория: " + cat.Name });

                    for (int i = 0; i < cat.BooksFromCategory.Length; i++)
                    {
                        var c = cat.BooksFromCategory[i];
                        vs.Add(new List<string>() { Settings.Load<Book>(Book.FileArrayName).ToList().FindIndex(tmp => tmp.Articul == c.Articul).ToString(), cat.Name, c.Name, c.Articul.ToString(), c.Count.ToString(), c.GetRealizCount().ToString(), c.GetFreeCount().ToString(), c.GetRealization().Length.ToString() });
                    }
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
