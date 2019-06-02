using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Model;
using QuanLyKho.Object;
using System.Data;


namespace QuanLyKho.Control
{
    class PhieuXuatChiTietCtrl
    {
        public static DataTable GetData(string s)
        {
            return PhieuXuatChiTietMod.GetData(s);
        }
        public static DataTable GetDataSanPham()
        {
            return PhieuXuatChiTietMod.GetDataSanPham();
        }
        
        public static int InsertProfile(ChiTietPhieuXuatObj qh)
        {
            return PhieuXuatChiTietMod.InsertProfile(qh);
        }

        public static int UpdateProfile(ChiTietPhieuXuatObj qh)
        {
            return PhieuXuatChiTietMod.UpdateProfile(qh);
        }

        public static int DeleteProfile(ChiTietPhieuXuatObj qh)
        {
            return PhieuXuatChiTietMod.DeleteProfile(qh);
        }
    }
}
