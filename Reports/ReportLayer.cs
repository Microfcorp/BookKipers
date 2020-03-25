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

namespace Библиотеки.Reports
{
    public partial class ReportLayer : Form
    {
        public ReportLayer(IReports rp)
        {
            InitializeComponent();

            tableLayoutPanel1.RowCount = rp.CSV.Array.Length;
            tableLayoutPanel1.ColumnCount = rp.CSV.Array.Select(tmp => tmp).Max(tmp => tmp.Length);
            for (int i = 0; i < rp.CSV.Array.Length; i++)
            {             
                for (int ia = 0; ia < rp.CSV.Array[i].Length; ia++)
                {
                    Label lb = new Label()
                    {
                        AutoSize = true,
                        Text = rp.CSV.Array[i][ia],
                       // Location = new Point(i*2, ia*(Text.Length)),
                    };

                    tableLayoutPanel1.Controls.Add(lb, ia, i);
                }               
            }

            сохранитьToolStripMenuItem.Click += (o, e) =>
            {
                SaveFileDialog svf = new SaveFileDialog();
                svf.Filter = "CSV файл|*.csv";
                svf.FileName = rp.Name;
                if(svf.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(svf.FileName, rp.CSV.ToString(), Encoding.UTF8);
                }
            };
        }

        private void ReportLayer_Load(object sender, EventArgs e)
        {

        }

        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.Document = new System.Drawing.Printing.PrintDocument();
        }
    }
}
