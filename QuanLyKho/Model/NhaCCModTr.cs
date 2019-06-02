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
    class NhaCCModTr
    {

        public static DataTable GetListNhaCC()
        {
            return ConnectToSQLTr.GetData(" select * from NhaCC ");
        }
    }
}
