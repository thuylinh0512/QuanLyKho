using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyKho.Model;
using System.Data;

namespace QuanLyKho.Control
{
    class ThongKeCtrlH
    {
        ThongKeH tk = new ThongKeH();
        public DataTable GetData(string s)
        {
            return tk.GetData(s);
        }
        public bool ThucHienLenh(string s)
        {
            return tk.ThucHienLenh(s);
        }
    }
}
