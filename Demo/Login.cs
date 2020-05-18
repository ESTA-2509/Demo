using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using Demo;

namespace Demo
{
    
    public partial class Login : Form
    {
        public string phone, pass, user;
        public Login()
        {
            InitializeComponent();
        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                string mySQL = string.Empty;
                mySQL += "SELECT * FROM LoginTable ";
                mySQL += "WHERE Username = '" + textBox1.Text + "' ";
                mySQL += "AND Phone = '" + textBox3.Text + "'";
                mySQL += "AND Password = '" + textBox2.Text + "'";
                phone = textBox3.Text;
                pass = textBox2.Text;
                user = textBox1.Text;
                DataTable userData = Data.executeSQL(mySQL);
                if (userData.Rows.Count > 0)
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    this.Hide();
                    OTP formOTP = new OTP(this);
                    formOTP.ShowDialog();
                    formOTP = null;
                    this.Show();
                    this.textBox1.Select();
                }
                else
                {
                    MessageBox.Show("The username or password is incorrect. Try again.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Please enter username and password.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox1.Select();
            }
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            register register = new register();
            register.ShowDialog();
        }

        
    }
}

