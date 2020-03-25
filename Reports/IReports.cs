using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Библиотеки.Reports
{
    /// <summary>
    /// Интерфейс для всех отчетов
    /// </summary>
    public interface IReports
    {
        /// <summary>
        /// Название отчета
        /// </summary>
        string Name
        {
            get;
        }
        /// <summary>
        /// Заголовок отчета
        /// </summary>
        string Title
        {
            get;
        }
        /// <summary>
        /// Шапка отчета
        /// </summary>
        List<string> Tiles
        {
            get;
            set;
        }
        /// <summary>
        /// CSV версия документа
        /// </summary>
        CSVDocument CSV
        {
            get;
        }
    }
}
