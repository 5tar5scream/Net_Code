using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STAF.ML;
using STAF.Automation.Utility;

namespace DsManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            List<string> toAdd = new List<string>();
            toAdd.Add(textBox1.Text);
            foreach (string item in Classifier.InputToList(textBox1.Text))
            {
                toAdd.Add(item);
            }
            toAdd.Add(cb.Text);
            CSVHelper.AppendToCSV(toAdd);
        }
    }
}
