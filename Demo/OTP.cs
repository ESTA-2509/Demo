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


namespace Demo
{
    public partial class OTP : Form
    {
        public Login parent;
        public string randomNumber;
        public OTP(Form f)
        {
            this.parent = f as Login;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {         

            
            if (textBox1.Text == randomNumber)
            {
                MessageBox.Show("Logined successfully");
                main formmain = new main();
                formmain.ShowDialog();
                formmain = null;
                this.Show();
            }
            else
            {

                MessageBox.Show("error");
            }

        }

        private void OTP_Load(object sender, EventArgs e)
        {
            String result;
            string apiKey = "g0qe6oR+hHY-erKX8HEJfq7RiotvRy5ykoz3o1q85w";
            string numbers = parent.phone; // in a comma seperated list            
            string send = "Hung";
            Random rnd = new Random();
            randomNumber = (rnd.Next(100000, 999999)).ToString();
            string message = "Your otp is " + randomNumber;
            String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + send;
            //refer to parameters to complete correct url string

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
            }
            catch (Exception eX)
            {
                MessageBox.Show(eX.Message);
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            MessageBox.Show("OTP send successfully   ");
        }
    }
}
