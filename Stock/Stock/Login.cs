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

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //First Validation of UserName And Password
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select * from [Stock].[dbo].[Login] where UserName='"+ textBox1.Text+"' and Password='"+ textBox2.Text+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            //After Connection
            {
                this.Hide();
                StockMain main = new StockMain();
                main.Show();
            }
            else {
                MessageBox.Show("Invalid User Name or Password...","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1_Click(sender,e);
            }
        }

       
    }
}
