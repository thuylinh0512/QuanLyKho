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
    class NhanVienModTr
    {

        public static DataTable GetListNhanVien()
        {
            return ConnectToSQLTr.GetData(" select * from NhanVien  ");
        }
    }
}
