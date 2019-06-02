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
    class NhanVienModTH
    {
        ConnectToSQLTH con = new ConnectToSQLTH();
        SqlCommand cmd = new SqlCommand();
        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            cmd.CommandText = "select * from NhanVien";
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
        public bool AddData(NhanVienObjTH Obj)
        {

            cmd.CommandText = " insert into NhanVien (MaNV,TenNV,NgaySinh,GioiTinh,DiaChi,SDT) values('" + Obj.manv + "',N'" + Obj.tennv + "',convert(date,'" + Obj.ngaysinh + "'),N'"+Obj.gioitinh+"',N'"+Obj.diachi+"','"+Obj.sdt+"')";
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
        public bool UpDate(NhanVienObjTH Obj)
        {

            cmd.CommandText = " update NhanVien set TenNV = N'" + Obj.tennv + "' , NgaySinh = '" + Obj.ngaysinh + "' , GioiTinh = '"+Obj.gioitinh+"' , DiaChi = N'"+Obj.diachi+"' , SDT = '"+Obj.sdt+"' where MaNV = '" + Obj.manv + "'";
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

            cmd.CommandText = " delete NhanVien where MaNv =  '" + ma + "'";
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
