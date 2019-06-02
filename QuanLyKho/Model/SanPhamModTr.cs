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
    class SanPhamModTr
    {

        public static DataTable GetListSanPham()
        {
            return ConnectToSQLTr.GetData(" select * from SanPham ");
        }
    }
}
