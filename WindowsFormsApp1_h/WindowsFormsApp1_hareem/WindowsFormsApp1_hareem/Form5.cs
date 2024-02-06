using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1_hareem
{
    public partial class Form5 : Form
    {
        public Form5()
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
               
            SqlConnection obj = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\USERS\ASP\DESKTOP\WINDOWSFORMSAPP1_HAREEM\WINDOWSFORMSAPP1\DATABASE1.MDF");
            obj.Open();
            SqlCommand cmd = new SqlCommand("insert into users (marks) values('" + Form1.marks + "')",obj);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data inserted");
        }
    }
}
