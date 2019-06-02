using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuanLyKho.Model;
using System.Data;
using QuanLyKho.Object;

namespace QuanLyKho.Control
{
    class KhachHangCtrlTH
    {

        KhachHangModTH nvMod = new KhachHangModTH();
        public DataTable GetData()
        {
            return nvMod.GetData();
        }
        public bool addData(KhachHangObjTH khObj)
        {
            return nvMod.AddData(khObj);
        }
        public bool upData(KhachHangObjTH khObj)
        {
            return nvMod.UpDate(khObj);
        }
        public bool delData(string ma)
        {
            return nvMod.DelData(ma);
        }
    }
}
