using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1_hareem
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool answer = radioButton2.Checked;
            if (answer)
            {
                Form1.marks += 1;
            }
                Form5 obj = new Form5();
                obj.Show();
                this.Hide();
            
        }
    }
}
