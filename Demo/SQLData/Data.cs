using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Demo
{
    class Data
    {
        public static string stringConnect = "Data source = LAPTOP-PH56EDQV;" + //Thay đổi tên đúng với server chứ table LoginTable
            "Initial Catalog = LoginDatabase; Integrated Security = True";
        public static DataTable executeSQL(string sql)
        {

            SqlConnection connection = new SqlConnection();
            SqlDataAdapter adapter = default(SqlDataAdapter);
            DataTable dt = new DataTable();

            try
            {

                connection.ConnectionString = stringConnect;
                connection.Open();

                adapter = new SqlDataAdapter(sql, connection);
                adapter.Fill(dt);

                connection.Close();
                connection = null;
                return dt;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("An error occured: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dt = null;
            }

            return dt;

        }
    }
}
