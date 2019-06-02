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
    class NhanVienCtrlTH
    {

        NhanVienModTH nvMod = new NhanVienModTH();
        public DataTable GetData()
        {
            return nvMod.GetData();
        }
        public bool addData(NhanVienObjTH nvObj)
        {
            return nvMod.AddData(nvObj);
        }
        public bool upData(NhanVienObjTH nvObj)
        {
            return nvMod.UpDate(nvObj);
        }
        public bool delData(string ma)
        {
            return nvMod.DelData(ma);
        }
    }
}
