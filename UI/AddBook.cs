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
    public partial class AddBook : Form
    {
        bool IsAdd = true;
        uint id;
        Book bok = new Book("", 0,"", null, 0);
        public AddBook()
        {
            InitializeComponent();
            var t = Settings.Load<Categories>(Categories.FileArrayName);
            foreach (var item in t)
                comboBox1.Items.Add(item.Name);
        }
        public AddBook(uint ID) : this()
        {
            Text = "Редактировать книгу";
            bok = Settings.Load<Book>(Book.FileArrayName)[ID];
            textBox1.Text = bok.Name;
            richTextBox1.Text = bok.Description;
            maskedTextBox1.Text = bok.Articul.ToString();
            comboBox1.SelectedIndex = bok.CategoryID;
            pictureBox1.Image = bok.Image;
            numericUpDown1.Value = bok.Count;

            IsAdd = false;
            id = ID;
        }

        Book Return
        {
            get
            {
                var t = bok;
                t.Name = textBox1.Text;
                t.Description = richTextBox1.Text;
                t.Articul = long.Parse(maskedTextBox1.Text);
                t.CategoryID = comboBox1.SelectedIndex;
                t.Image = pictureBox1.Image;
                t.Count = (int)numericUpDown1.Value;
                return t;
            }
        }

        private void AddBook_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsAdd)
            {
                Settings.AddToFile<Book>(Return, Book.FileArrayName);
            }
            else
            {
                Settings.ReplaceToFile<Book>(Return, Book.FileArrayName, (int)id);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void выбратьИзображеиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog opg = new OpenFileDialog();
            opg.Title = "Выбрать изображение";
            opg.Filter = "*.jpg|*.jpg";
            if(opg.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opg.FileName);
            }
        }

        private void отчиститьИзображениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
