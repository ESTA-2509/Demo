using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Demo;

namespace Demo
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void loadUserData()
        {
            DataTable userData = Data.executeSQL("SELECT Name, Username FROM LoginTable");
            dataGridView1.DataSource = userData;
            dataGridView1.Columns[0].HeaderText = "Name";
            dataGridView1.Columns[1].HeaderText = "Username";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
        }
        private void register_Load(object sender, EventArgs e)
        {
            loadUserData();
            textBox1.Select();
        }

        private void save_Click(object sender, EventArgs e)
        {
            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBoxIcon ico = MessageBoxIcon.Information;
            string caption = "Save Data";

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please enter Name.", caption, btn, ico);
                textBox1.Select();
                return;
            }
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please enter Phone.", caption, btn, ico);
                textBox2.Select();
                return;
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please enter Username.", caption, btn, ico);
                textBox3.Select();
                return;
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please enter Password.", caption, btn, ico);
                textBox4.Select();
                return;
            }                   
            string SQL = "SELECT Username FROM LoginTable WHERE Username = '" + textBox3.Text + "'";
            DataTable checkDuplicates = Demo.Data.executeSQL(SQL);
            if (checkDuplicates.Rows.Count > 0)
            {
                MessageBox.Show("The username already exists. Please try another username.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.SelectAll();
                return;
            }

            string SQL_1 = "SELECT Username FROM LoginTable WHERE Phone = '" + textBox2.Text + "'";
            DataTable checkDuplicates_1 = Demo.Data.executeSQL(SQL_1);
            if (checkDuplicates_1.Rows.Count > 0)
            {
                MessageBox.Show("The phone number already exists. Please try another phone number.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.SelectAll();
                return;
            }

            DialogResult result;
            result = MessageBox.Show("Do you want to save your data?", "Save Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string mySQL = string.Empty;
                mySQL += "INSERT INTO LoginTable (Name, Phone, Username, Password) ";
                mySQL += "VALUES ('" + textBox1.Text + "','" + textBox2.Text + "',";
                mySQL += "'" + textBox3.Text + "','" + textBox4.Text + "')";
                Demo.Data.executeSQL(mySQL);
                MessageBox.Show("Your data has been saved successfully!",
                                "Save Data", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                loadUserData();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
