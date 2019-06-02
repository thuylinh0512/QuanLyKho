using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.Model
{
    class ConnectToSQLH
    {
        public SqlConnection conn { get; set; }
        public SqlCommand cmd { get; set; }
        public string error { get; set; }
        string strCon;

        public ConnectToSQLH()
        {
            strCon = @"Data Source=DESKTOP-CKP2M1U\SERVER;Initial Catalog=QuanLyKhoL;Integrated Security=True";

         
            conn = new SqlConnection(strCon);
        }
        public bool OpenConn()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
        }
        public bool CloseConn()
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
            catch (Exception e)
            {
                error = e.Message;
                return false;
            }
            return true;
        }
    }
}
