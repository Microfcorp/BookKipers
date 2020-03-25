using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Библиотеки.Operators;

namespace Библиотеки.Books
{
    /// <summary>
    /// Книга
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Book : IEquatable<Book>
    {
        public Book(string name, uint articul, string description, Image image, int categoryID)
        {
            Name = name;
            if (Articul != 0x00) Articul = articul;
            else
            {
                if (!Settings.IsFile(FileArrayName)) Articul = 0;
                else Articul = Settings.Load<Book>(FileArrayName).Select(tmp => tmp.Articul).ToArray().Max() + 1;
            }
            Description = description;
            Image = image;
            CategoryID = categoryID;
        }
        /// <summary>
        /// Название книги
        /// </summary>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Артикул книги
        /// </summary>
        public long Articul
        {
            get;
            set;
        }
        /// <summary>
        /// Описание книги
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// Картинка
        /// </summary>
        public Image Image
        {
            get;
            set;
        }
        /// <summary>
        /// Номер категории
        /// </summary>
        public int CategoryID
        {
            get;
            set;
        }
        /// <summary>
        /// Количество книг
        /// </summary>
        public int Count
        {
            get;
            set;
        }

        /// <summary>
        /// Категории, в который содержится данная книга
        /// </summary>
        /// <returns></returns>
        public Categories[] GetCategories()
        {
            return Settings.Load<Categories>(Categories.FileArrayName).Where(tmp => tmp.ID == CategoryID).ToArray();
        }
        /// <summary>
        /// Акты ревлизации с данной книгой
        /// </summary>
        /// <returns></returns>
        public Realization[] GetRealization()
        {
            if (Settings.IsFile(Realization.FileArrayName))
                return Settings.Load<Realization>(Realization.FileArrayName).Where(tmp => tmp.Articuls.Contains(Articul)).ToArray();
            else return new Realization[] { };
        }
        /// <summary>
        /// Акты возврата с данной книгой
        /// </summary>
        /// <returns></returns>
        public Vozvr[] GetReturns()
        {
            if (Settings.IsFile(Vozvr.FileArrayName))
                return Settings.Load<Vozvr>(Vozvr.FileArrayName).Where(tmp => Settings.Load<Realization>(Realization.FileArrayName)[tmp.IDRealiz].Articuls.Contains(Articul)).ToArray();
            else return new Vozvr[] { };
        }

        /// <summary>
        /// Возвращает количество оставшихся книг
        /// </summary>
        public int GetFreeCount()
        {
            var realizc = GetRealization().Length;
            var vozvr = GetReturns().Length;

            return Count - (realizc - vozvr);
        }
        /// <summary>
        /// Возвращает количество реализованных книг
        /// </summary>
        public int GetRealizCount()
        {
            return Count - GetFreeCount();
        }

        public override bool Equals(object obj)
        {
            return (obj is Book bk) && (bk.Articul == Articul);
        }

        public bool Equals(Book other)
        {
            return other != null &&
                   Name == other.Name &&
                   Articul == other.Articul &&
                   Description == other.Description &&
                   EqualityComparer<Image>.Default.Equals(Image, other.Image) &&
                   CategoryID == other.CategoryID;
        }

        public override int GetHashCode()
        {
            var hashCode = 1145259212;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Articul.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<Image>.Default.GetHashCode(Image);
            hashCode = hashCode * -1521134295 + CategoryID.GetHashCode();
            return hashCode;
        }

        /*/// <summary>
        /// Загружает массив книг из настроек
        /// </summary>
        /// <returns></returns>
        public static Book[] Load()
        {
            return Load<Book>(FileArrayName);
        }*/

        /// <summary>
        /// Константа названия файла
        /// </summary>
        public const string FileArrayName = "books";
    }
}
