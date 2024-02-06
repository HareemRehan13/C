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
    public partial class Form1 : Form
    {
        public static int marks;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            bool answer = radioButton2.Checked;
            if (answer)
            {
                marks += 1;
            }
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }
    }
}
