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
            try
            {
                List<string> toAdd = new List<string>();
                toAdd.Add(txtInput.Text);
                foreach (string item in Classifier.InputToList(txtInput.Text))
                {
                    toAdd.Add(item);
                }
                if (txtClass.Text == "")
                {
                    toAdd.Add(cb_Class.Text);
                }
                else
                {
                    toAdd.Add(txtClass.Text);
                }
                CSVHelper.AppendToCSV(toAdd);
                MessageBox.Show("Success! Input " + txtInput.Text + " added to dataset");

                txtInput.Text = "";
                txtClass.Text = "";
                cb_Class.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }
        }

        private void txtClass_TextChanged(object sender, EventArgs e)
        {
            cb_Class.Text = "";
        }

        private void cb_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtClass.Text = "";
        }
    }
}
