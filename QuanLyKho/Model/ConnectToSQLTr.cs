using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QuanLyKho.Model
{
    class ConnectToSQLTr
    {
        public static SqlConnection conn;
        public static SqlConnection Connect()
        {
            try
            {

                string str_conn = @"Data Source=DESKTOP-KBSLCQ1\TRIPRO;Initial Catalog=QuanLyKhoL;Integrated Security=True";
                SqlConnection conn = new SqlConnection(str_conn);
                conn.Open();
                return conn;
            }
            catch
            {
                return null;
            }
        }

        public static DataTable GetData(string proc)
        {
            try
            {
                conn = Connect();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(proc, conn);
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch (SqlException)
            {
                conn.Close();
                return null;
            }
        }

        public static int ExecuteNonQuery(string proc, SqlParameter[] para)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn = Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = proc;
                cmd.CommandType = CommandType.StoredProcedure;
                if (para != null)
                    cmd.Parameters.AddRange(para);

                int val = cmd.ExecuteNonQuery();
                conn.Close();
                return val;
            }
            catch (SqlException)
            {
                return 0;
            }
        }
    }
}
