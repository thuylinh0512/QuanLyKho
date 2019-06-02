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
    class PhieuXuatChiTietMod
    {
        public static SqlConnection conn;
        public static DataTable GetData(string s)
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select s.TenSP,p.SoLuong,p.ChungLoai from PhieuXuatChiTiet p right join SanPham s on p.MaSP=s.MaSP where p.MaPX ='"+s+"'";
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
        public static DataTable GetDataSanPham()
        {
            try
            {
                DataTable dt = new DataTable();
                string sql = "select MaSP,TenSP from SanPham ";
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
        public static int InsertProfile(ChiTietPhieuXuatObj qh)
        {
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@ma", qh.MaPX),
                new SqlParameter("@masp",qh.MaSP),
                new SqlParameter("@sl",qh.SoLuong),
                 new SqlParameter("@ChungLoai", qh.ChungLoai)

             };

            return ConectToSQL_Datvd.Execute_NonQuery("ThemPHieuXuatCT", para);
        }
        public static int UpdateProfile(ChiTietPhieuXuatObj qh)
        {
            SqlParameter[] para = new SqlParameter[]
            {  new SqlParameter("@ma", qh.MaPX),
                new SqlParameter("@masp",qh.MaSP),
                new SqlParameter("@sl",qh.SoLuong),
                 new SqlParameter("@ChungLoai", qh.ChungLoai)
            };

            return ConectToSQL_Datvd.Execute_NonQuery("SuaPhieuXuatCT", para);
        }
        public static int DeleteProfile(ChiTietPhieuXuatObj qh)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ma", qh.MaPX),
                new SqlParameter("@masp",qh.MaSP)

            };

            return ConectToSQL_Datvd.Execute_NonQuery("XoaPhieuXuatCT", para);
        }

    }
}
