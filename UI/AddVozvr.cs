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
    public partial class AddVozvr : Form
    {
        public AddVozvr()
        {
            InitializeComponent();
            var t = Settings.Load<Operators.Realization>(Operators.Realization.FileArrayName);
            var v = Settings.Load<Operators.Vozvr>(Operators.Vozvr.FileArrayName);

            for (int i = 0; i < t.Length; i++)
            {
                if(v.Length <= i || v[i] == null || !(v.Where(tmp => tmp.IDRealiz == i).Count() > 0))
                    comboBox1.Items.Add(i + " - " + t[i].Persons);
            }
        }

        Operators.Vozvr Return
        {
            get
            {
                return new Operators.Vozvr(uint.Parse(comboBox1.Text.Split('-').First()), DateTime.Now);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.AddToFile<Operators.Vozvr>(Return, Operators.Vozvr.FileArrayName);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
