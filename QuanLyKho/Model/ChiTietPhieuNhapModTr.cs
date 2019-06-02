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
    class ChiTietPhieuNhapModTr
    {
        public static DataTable GetListData(ChiTietPhieuNhapObjTr cthddv)
        {
            return ConnectToSQLTr.GetData("  select PhieuNhapChiTiet.MaSP, TenSP,PhieuNhapChiTiet.ChungLoai,PhieuNhapChiTiet.SoLuong , PhieuNhapChiTiet.DonGia , ThanhTien from PhieuNhap , SanPham , PhieuNhapChiTiet where PhieuNhap.MaPN= PhieuNhapChiTiet.MaPN and SanPham.MaSP =  PhieuNhapChiTiet.MaSP and PhieuNhapChiTiet.MaPN = '" + cthddv.MaPN+"'");
        }

        public static DataTable GetListTuDongThemGia(SanPhamObjTr dvobj)
        {
            return ConnectToSQLTr.GetData("  select  TenSP, DonGia from  SanPham where SanPham.MaSP = '" + dvobj.MaSP+ "'");
        }

        public static int InsertPCThieuNhap(ChiTietPhieuNhapObjTr ctd)
        {

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mapn",ctd.MaPN),
                 new SqlParameter("@masp",ctd.MaSP),
                new SqlParameter("@chungloai", ctd.ChungLoai),
                new SqlParameter("@soluong ", ctd.SoLuong),
                new SqlParameter("@dongia",ctd.DonGia),
                 new SqlParameter("@thanhtien",ctd.ThanhTien)



            };
            return ConnectToSQLTr.ExecuteNonQuery("ThemCTPhieuNhap", para);
        }

        public static int UpdateCTPhieuNhap(ChiTietPhieuNhapObjTr ctd)
        {
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@mapn",ctd.MaPN),
                 new SqlParameter("@masp",ctd.MaSP),
                new SqlParameter("@chungloai", ctd.ChungLoai),
                new SqlParameter("@soluong ", ctd.SoLuong),
                new SqlParameter("@dongia",ctd.DonGia),
                 new SqlParameter("@thanhtien",ctd.ThanhTien)



             };
            return ConnectToSQLTr.ExecuteNonQuery("SuaCTPhieuNhap", para);
        }

        public static int DeleteCTPhieuNhap(ChiTietPhieuNhapObjTr ctd)
        {

            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter("@mapn",ctd.MaPN),
                 new SqlParameter("@masp",ctd.MaSP)
              



             };
            return ConnectToSQLTr.ExecuteNonQuery("XoaCTPhieuNhap", para);
        }

    }
}
