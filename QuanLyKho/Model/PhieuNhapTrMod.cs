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
    class PhieuNhapTrMod
    {
        public static DataTable GetListPhieuNhap()
        {
            return ConnectToSQLTr.GetData("select  MaPN,NgayNhap,TenNV,TenNCC,TongTien from PhieuNhap hd,NHANVIEN nv, NhaCC kh where hd.MaNV=nv.MaNV and hd.MaNCC=kh.MaNCC");
        }

        public static int InsertPhieuNhap(PhieuNhapObjTr ctd)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mapn",ctd.MaPN),
                 new SqlParameter("@ngaynhap",ctd.NgayNhap),
                new SqlParameter("@manv", ctd.MaNV),
                new SqlParameter("@mancc ", ctd.MaNCC),
                new SqlParameter("@tongtien",ctd.TongTien)



            };
            return ConnectToSQLTr.ExecuteNonQuery("ThemPhieuNhap", para);
        }

        public static int UpdatePhieuNhap(PhieuNhapObjTr ctd)
        {

            SqlParameter[] para = new SqlParameter[]
            {
                  new SqlParameter("@mapn",ctd.MaPN),
                 new SqlParameter("@ngaynhap",ctd.NgayNhap),
                new SqlParameter("@manv", ctd.MaNV),
                new SqlParameter("@mancc ", ctd.MaNCC),
                new SqlParameter("@tongtien",ctd.TongTien)



            };
            return ConnectToSQLTr.ExecuteNonQuery("SuaPhieuNhap", para);
        }

        public static int DeletePhieuNhap(PhieuNhapObjTr  ctd)
        {
            SqlParameter[] para = new SqlParameter[]
            {

                new SqlParameter("@mapn",ctd.MaPN)
            };
            return ConnectToSQLTr.ExecuteNonQuery("XoaPhieuNhap", para);

        }
    }
}
