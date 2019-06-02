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
    class NhaCCCtrlTr
    {
        public static DataTable GetListNhaCC()
        {
            return NhaCCModTr.GetListNhaCC();

        }
    }
}
