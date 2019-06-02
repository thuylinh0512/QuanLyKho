using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyKho.Object;

namespace QuanLyKho.Model
{
    class KhachHangModTH
    {
        ConnectToSQLTH con = new ConnectToSQLTH();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select * from KhachHang";
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
        public bool AddData(KhachHangObjTH Obj)
        {

            cmd.CommandText = " insert into KhachHang (MaKH,TenKH,DiaChi,SDT,KieuThanhToan) values('" + Obj.makh + "',N'" + Obj.tenkh + "',N'" + Obj.diachi + "','" + Obj.sdt + "', N'"+Obj.kieuthanhtoan+"')";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.OpenConn();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }

            return false;
        }
        public bool UpDate(KhachHangObjTH Obj)
        {

            cmd.CommandText = " update KhachHang set TenKH = N'" + Obj.tenkh + "' , DiaChi = N'" + Obj.diachi + "' , SDT = '" + Obj.sdt + "' , KieuThanhToan = N'"+Obj.kieuthanhtoan+"'where MaKH = '" + Obj.makh + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;


            try
            {

                con.OpenConn();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }

            return false;
        }

        public bool DelData(string ma)
        {
            DataTable dt = new DataTable();

            cmd.CommandText = " delete KhachHang where MaKH =  '" + ma + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con.Connection;

            try
            {
                con.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                con.CloseConn();
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                cmd.Dispose();
                con.CloseConn();
            }
            return false;
        }
    }
}
