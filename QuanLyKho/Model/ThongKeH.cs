using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKho.Model
{
    class ThongKeH
    {
        ConnectToSQLH con = new ConnectToSQLH();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetData(string s)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = s;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conn;

            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.CloseConn();
            }
            catch
            {
                cmd.Dispose();
                con.CloseConn();
            }
            return dt;
        }
        public bool ThucHienLenh(string s)
        {
            cmd.CommandText = s;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.conn;
            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
    }
}
