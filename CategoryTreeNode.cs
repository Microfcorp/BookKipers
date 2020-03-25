using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Библиотеки
{
    class CategoryTreeNode : TreeNode
    {
        public CategoryTreeNode(Books.Categories category, ContextMenuStrip cnx) : base(category.Name)
        {
            Categories = category;

            Name = category.ID.ToString();
            foreach (var item in category.BooksFromCategory)
                Nodes.Add(new BooksTreeNode(item, cnx));

            ContextMenuStrip = cnx;
        }

        /// <summary>
        /// Категория
        /// </summary>
        public Books.Categories Categories
        {
            get;
            set;
        }
    }
}
