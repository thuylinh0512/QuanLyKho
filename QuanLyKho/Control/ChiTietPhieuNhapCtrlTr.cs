using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Object;
using QuanLyKho.Model;
using System.Data.SqlClient;
using System.Data;
namespace QuanLyKho.Control
{
    class ChiTietPhieuNhapCtrlTr
    {
        public static DataTable GetListCTPhieuNhap(ChiTietPhieuNhapObjTr ct)
        {
            return ChiTietPhieuNhapModTr.GetListData(ct);

        }
        public static DataTable GetListTuDongThemGia(SanPhamObjTr sp)
        {
            return ChiTietPhieuNhapModTr.GetListTuDongThemGia(sp);
        }
        public static int InsertPhieuNhap(ChiTietPhieuNhapObjTr ctd)
        {
            return ChiTietPhieuNhapModTr.InsertPCThieuNhap(ctd);
        }

        public static int UpdatePhieuNhap(ChiTietPhieuNhapObjTr ctd)
        {
            return ChiTietPhieuNhapModTr.UpdateCTPhieuNhap(ctd);

        }

        public static int DeletePhieuNhap(ChiTietPhieuNhapObjTr ctd)
        {
            return ChiTietPhieuNhapModTr.DeleteCTPhieuNhap(ctd);

        }
    }
}
