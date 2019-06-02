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
    class PhieuXuatCtrl
    {
        public static DataTable GetData()
        {
            return PhieuXuatMod.GetData();
        }
        public static DataTable GetDataNhanVien()
        {
            return PhieuXuatMod.GetDataNhanVien();
        }
        public static DataTable GetDataKhachHang()
        {
            return PhieuXuatMod.GetDataKhachHang();
        }
        public static int InsertProfile(PhieuXuatObj qh)
        {
            return PhieuXuatMod.InsertProfile(qh);
        }

        public static int UpdateProfile(PhieuXuatObj qh)
        {
            return PhieuXuatMod.UpdateProfile(qh);
        }

        public static int DeleteProfile(PhieuXuatObj qh)
        {
            return PhieuXuatMod.DeleteProfile(qh);
        }
    }
}
