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
    class PhieuNhapCtrlTr
    {
        public static DataTable GetListPhieuNhap()
        {
            return PhieuNhapTrMod.GetListPhieuNhap();

        }
        public static int InsertPhieuNhap(PhieuNhapObjTr ctd)
        {
            return PhieuNhapTrMod.InsertPhieuNhap(ctd);
        }

        public static int UpdatePhieuNhap(PhieuNhapObjTr ctd)
        {
            return PhieuNhapTrMod.UpdatePhieuNhap(ctd);

        }

        public static int DeletePhieuNhap(PhieuNhapObjTr ctd)
        {
            return PhieuNhapTrMod.DeletePhieuNhap(ctd);

        }
    }
}
