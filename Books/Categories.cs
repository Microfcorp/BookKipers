using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Библиотеки.Books
{
    /// <summary>
    /// Категории
    /// </summary>
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public class Categories : IEquatable<Categories>
    {
        /// <summary>
        /// Название категории
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// ID категории
        /// </summary>
        public uint ID
        {
            get;
            set;
        }

        /// <summary>
        /// Массив из книг этой категории
        /// </summary>
        public Book[] BooksFromCategory
        {
            get
            {
                if (!Settings.IsFile(Book.FileArrayName)) return new Book[] { };
                else return Settings.Load<Book>(Book.FileArrayName).Where(tmp => tmp.CategoryID == ID).ToArray();
            }
        }

        /// <summary>
        /// Константа названия файла
        /// </summary>
        public const string FileArrayName = "categories";

        public Categories(string name, uint iD)
        {
            Name = name;
            ID = iD;
        }
        public Categories(string name)
        {
            Name = name;
            if (!Settings.IsFile(FileArrayName)) ID = 0;
            else ID = Settings.Load<Categories>(FileArrayName).Select(tmp => tmp.ID).Max() + 1;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Categories);
        }

        public bool Equals(Categories other)
        {
            return other != null &&
                   Name == other.Name &&
                   ID == other.ID;
        }

        public override int GetHashCode()
        {
            var hashCode = 1997165910;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + ID.GetHashCode();
            return hashCode;
        }
    }
}
