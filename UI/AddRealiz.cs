using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Библиотеки.Books;

namespace Библиотеки.UI
{
    public partial class AddRealiz : Form
    {
        public AddRealiz()
        {
            InitializeComponent();

            var t = Settings.Load<Book>(Book.FileArrayName);
            foreach (var item in t)
                checkedListBox1.Items.Add(item.Name + " (" + item.Articul + ")");
        }

        private void AddRealiz_Load(object sender, EventArgs e)
        {

        }

        public Operators.Realization Return
        {
            get
            {
                List<long> ln = new List<long>();
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    ln.Add(long.Parse(item.ToString().Split('(').Last().Split(')').First()));
                }
                return new Operators.Realization(ln.ToArray(), textBox1.Text, DateTime.Now);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var t = Settings.Load<Book>(Book.FileArrayName);
            foreach (var item in checkedListBox1.CheckedItems)
            {
                long art = long.Parse(item.ToString().Split('(').Last().Split(')').First());             

                if(t.Where(tmp => tmp.Articul == art).First().GetFreeCount() <= 0)
                {
                    MessageBox.Show("На складе недостаточно книг");
                    return;
                }
            }

            Settings.AddToFile<Operators.Realization>(Return, Operators.Realization.FileArrayName);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
