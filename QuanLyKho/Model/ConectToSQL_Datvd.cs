using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyKho.Model
{
    class ConectToSQL_Datvd
    {
        public static SqlConnection conn;
        public static SqlConnection Connect()
        {
            try
            {
                string str_conn = @"Data Source=DESKTOP-CKP2M1U\SERVER;Initial Catalog=QuanLyKhoL;Integrated Security=True";
                SqlConnection conn = new SqlConnection(str_conn);
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }
        }

        public static int Execute_NonQuery(string proc, SqlParameter[] para)
        {
            try
            {
                conn = Connect();
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    cmd.Parameters.AddRange(para);
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                return i;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
