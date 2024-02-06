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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bool answer = radioButton1.Checked;
            if (answer)
            {
                Form1.marks += 1;
            }
                Form4 obj = new Form4();
                obj.Show();
                this.Hide();
            
        }
    }
}
