using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Библиотеки.Books;

namespace Библиотеки
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateTree();
        }

        private void просмотрСпискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateTree();
        }

        private void UpdateTree()
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            var t = Settings.Load<Categories>(Categories.FileArrayName);

            foreach (var ca in t)
            {
                var btn = new CategoryTreeNode(ca, contextMenuStrip1);
                treeView1.Nodes.Add(btn);
            }
            treeView1.EndUpdate();
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UI.AddCategory cnv = new UI.AddCategory();
            if (cnv.ShowDialog() == DialogResult.OK)
                UpdateTree();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.AddBook cnv = new UI.AddBook();
            if(cnv.ShowDialog() == DialogResult.OK)
                UpdateTree();
        }
        TreeNode tn;
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tn = e.Node;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(tn is BooksTreeNode)
            {
                var btn = tn as BooksTreeNode;
                Settings.DeleteToFile<Book>(Book.FileArrayName, Settings.GetID<Book>(btn.Book, Book.FileArrayName));
            }
            else if (tn is CategoryTreeNode)
            {
                var btn = tn as CategoryTreeNode;
                Settings.DeleteToFile<Categories>(Categories.FileArrayName, Settings.GetID<Categories>(btn.Categories, Categories.FileArrayName));
            }
            UpdateTree();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tn is BooksTreeNode)
            {
                var btn = tn as BooksTreeNode;
                var id = Settings.GetID<Book>(btn.Book, Book.FileArrayName);

                UI.AddBook cnv = new UI.AddBook((uint)id);
                if (cnv.ShowDialog() == DialogResult.OK)
                    UpdateTree();
            }
            else if (tn is CategoryTreeNode)
            {
                var btn = tn as CategoryTreeNode;
                var id = Settings.GetID<Categories>(btn.Categories, Categories.FileArrayName);

                UI.AddCategory cnv = new UI.AddCategory((uint)id);
                if (cnv.ShowDialog() == DialogResult.OK)
                    UpdateTree();
            }
        }

        private void реализоватьКнигиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.AddRealiz cnv = new UI.AddRealiz();
            if (cnv.ShowDialog() == DialogResult.OK)
                UpdateTree();
        }

        private void вернутьКникуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.AddVozvr cnv = new UI.AddVozvr();
            if (cnv.ShowDialog() == DialogResult.OK)
                UpdateTree();
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (tn is BooksTreeNode)
            {
                var btn = tn as BooksTreeNode;
                var id = Settings.GetID<Book>(btn.Book, Book.FileArrayName);

                UI.AddBook cnv = new UI.AddBook((uint)id);
                if (cnv.ShowDialog() == DialogResult.OK)
                    UpdateTree();
            }
            else if (tn is CategoryTreeNode)
            {
                var btn = tn as CategoryTreeNode;
                var id = Settings.GetID<Categories>(btn.Categories, Categories.FileArrayName);

                UI.AddCategory cnv = new UI.AddCategory((uint)id);
                if (cnv.ShowDialog() == DialogResult.OK)
                    UpdateTree();
            }
        }

        private bool AdminMode { get => режимПравкиДокументовToolStripMenuItem.Checked; set => режимПравкиДокументовToolStripMenuItem.Checked = value; }

        private void режимПравкиДокументовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminMode = !AdminMode;
            удалитьДокументыToolStripMenuItem.Visible = AdminMode;
        }

        private void реализацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.RemoveRealiz cnv = new UI.RemoveRealiz();
            if (cnv.ShowDialog() == DialogResult.OK)
                UpdateTree();
        }

        private void возвратаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.RemoveVosvr cnv = new UI.RemoveVosvr();
            if (cnv.ShowDialog() == DialogResult.OK)
                UpdateTree();
        }

        private void остаткиКнигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.RBalance bl = new Reports.RBalance();
            var csv = bl.CSV.ToString();

            Reports.ReportLayer rl = new Reports.ReportLayer(bl);
            rl.ShowDialog();
            //File.WriteAllText("t.csv", csv, Encoding.UTF8);
        }

        private void реализацияКнигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.RRealiz bl = new Reports.RRealiz();
            var csv = bl.CSV.ToString();

            Reports.ReportLayer rl = new Reports.ReportLayer(bl);
            rl.ShowDialog();
        }

        private void возвратКнигToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.RVosvr bl = new Reports.RVosvr();
            var csv = bl.CSV.ToString();

            Reports.ReportLayer rl = new Reports.ReportLayer(bl);
            rl.ShowDialog();
        }
    }
}
