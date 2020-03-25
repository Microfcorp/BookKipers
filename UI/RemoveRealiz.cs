using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Библиотеки.UI
{
    public partial class RemoveRealiz : Form
    {
        public RemoveRealiz()
        {
            InitializeComponent();
            var t = Settings.Load<Operators.Realization>(Operators.Realization.FileArrayName);

            for (int i = 0; i < t.Length; i++)
            {
                comboBox1.Items.Add(i + " - " + t[i].Persons);
            }
        }

        private void RemoveRealiz_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var id = int.Parse(comboBox1.Text.Split('-').First());
            Settings.DeleteToFile<Operators.Realization>(Operators.Realization.FileArrayName, id);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
