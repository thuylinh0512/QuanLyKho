using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKho.Control;

namespace QuanLyKho.View
{
    public partial class frmThongKeHangHoa : Form
    {
        ThongKeCtrlH tke = new ThongKeCtrlH();
        DataTable dt = new DataTable();
        public frmThongKeHangHoa()
        {
            InitializeComponent();
        }

        private void frmThongKeHangHoa_Load(object sender, EventArgs e)
        {
            dt = tke.GetData("select * from sanpham");
            dgvHangHoa.DataSource = dt;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                string str = string.Format("MaSP like '%{0}%' or TenSP like '%{1}%' or ChungLoai like '%{2}%'", txtTimKiem.Text, txtTimKiem.Text, txtTimKiem.Text);
                dt.DefaultView.RowFilter = str;
            }
        }
    }
}
