using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Библиотеки.Operators
{
    /// <summary>
    /// Возврат книги
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Vozvr : IEquatable<Vozvr>
    {
        public Vozvr(uint iDRealiz, DateTime date)
        {
            IDRealiz = iDRealiz;
            Date = date;
        }

        /// <summary>
        /// ID акта реализации
        /// </summary>
        public uint IDRealiz
        {
            get;
            set;
        }
        /// <summary>
        /// Дата возврата
        /// </summary>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Константа названия файла
        /// </summary>
        public const string FileArrayName = "returns";

        public override bool Equals(object obj)
        {
            return Equals(obj as Vozvr);
        }

        public bool Equals(Vozvr other)
        {
            return other != null &&
                   IDRealiz == other.IDRealiz &&
                   Date == other.Date;
        }

        public override int GetHashCode()
        {
            var hashCode = -28141472;
            hashCode = hashCode * -1521134295 + IDRealiz.GetHashCode();
            hashCode = hashCode * -1521134295 + Date.GetHashCode();
            return hashCode;
        }
    }
}
