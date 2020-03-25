using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Библиотеки.Books;

namespace Библиотеки
{
    /// <summary>
    /// Ветковая нода для книги
    /// </summary>
    class BooksTreeNode : TreeNode
    {
        public BooksTreeNode(Book book, ContextMenuStrip cnx)
        {
            Book = book;
            ContextMenuStrip = cnx;
            Name = book.Articul.ToString();
            Text = book.Name + " (" + book.Articul + ") " + "Осталось: " + book.GetFreeCount();
            ToolTipText = book.Description;
        }

        /// <summary>
        /// Книга
        /// </summary>
        public Books.Book Book
        {
            get;
            set;
        }
    }
}
