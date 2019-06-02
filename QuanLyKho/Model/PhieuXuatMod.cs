using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Object;
using System.Data.SqlClient;
using System.Data;

namespace QuanLyKho.Model
{
    class PhieuXuatMod
    {
        public static SqlConnection conn;
        public static DataTable GetData()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = " select a.MaPX,a.NgayXuat,a.TenNV,k.TenKH from KhachHang k right join (select p.MaPX,p.NgayXuat,n.TenNV,p.MaKH from PhieuXuat p left join NhanVien n on p.MaNV=n.MaNV) a on a.MaKH=k.MaKH";
                conn = ConectToSQL_Datvd.Connect();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch
            {
                conn.Close();
                return null;
            }
        }
        public static DataTable GetDataNhanVien()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select MaNV,TenNV from NhanVien ";
                conn = ConectToSQL_Datvd.Connect();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch
            {
                conn.Close();
                return null;
            }
        }
        public static DataTable GetDataKhachHang()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = " select MaKH,TenkH from KhachHang";
                conn = ConectToSQL_Datvd.Connect();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();
                return dt;
            }
            catch
            {
                conn.Close();
                return null;
            }
        }
        public static int InsertProfile(PhieuXuatObj qh)
        {
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@ma", qh.MaPX),
                new SqlParameter("@makh",qh.MaKH),
                new SqlParameter("@manv",qh.MaNV),
                 new SqlParameter("@ngay", qh.NgayXuat),
                
             };

            return ConectToSQL_Datvd.Execute_NonQuery("ThemPhieuXuat", para);
        }
        public static int UpdateProfile(PhieuXuatObj qh)
        {
            SqlParameter[] para = new SqlParameter[]
            {   new SqlParameter("@ma", qh.MaPX),
                new SqlParameter("@makh",qh.MaKH),
                new SqlParameter("@manv",qh.MaNV),
                 new SqlParameter("@ngay", qh.NgayXuat),
            };

            return ConectToSQL_Datvd.Execute_NonQuery("SuaPhieuXuat", para);
        }
        public static int DeleteProfile(PhieuXuatObj qh)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ma", qh.MaPX)

            };

            return ConectToSQL_Datvd.Execute_NonQuery("XoaPhieuXuat", para);
        }
    }
}
