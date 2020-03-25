using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Библиотеки.Operators
{
    /// <summary>
    /// Реализация книги
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Realization : IEquatable<Realization>
    {
        public Realization(long[] articuls, string persons, DateTime date)
        {
            Articuls = articuls;
            Persons = persons;
            Date = date;
        }

        /// <summary>
        /// Артикулы книг
        /// </summary>
        public long[] Articuls
        {
            get;
            set;
        }
        /// <summary>
        /// Кому отдано
        /// </summary>
        public string Persons
        {
            get;
            set;
        }
        /// <summary>
        /// Время операции
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Константа названия файла
        /// </summary>
        public const string FileArrayName = "realizations";

        public override bool Equals(object obj)
        {
            return Equals(obj as Realization);
        }

        public bool Equals(Realization other)
        {
            return other != null &&
                   EqualityComparer<long[]>.Default.Equals(Articuls, other.Articuls) &&
                   Persons == other.Persons &&
                   Date == other.Date;
        }

        public override int GetHashCode()
        {
            var hashCode = -1177286218;
            hashCode = hashCode * -1521134295 + EqualityComparer<long[]>.Default.GetHashCode(Articuls);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Persons);
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            return hashCode;
        }
    }
}
