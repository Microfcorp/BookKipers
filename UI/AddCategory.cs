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
    public partial class AddCategory : Form
    {
        bool IsAdd = true;
        int id;
        public AddCategory()
        {
            InitializeComponent();
        }
        public AddCategory(uint ID) : this()
        {
            Text = "Редактировать категорию";
            textBox1.Text = Settings.Load<Categories>(Categories.FileArrayName)[ID].Name;
            IsAdd = false;
            id = (int)ID;
        }

        public string Return
        {
            get => textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                Settings.AddToFile<Categories>(new Categories(Return), Categories.FileArrayName);
            }
            else
            {
                var c = Settings.Load<Categories>(Categories.FileArrayName)[id];
                c.Name = Return;
                Settings.ReplaceToFile<Categories>(c, Categories.FileArrayName, id);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
