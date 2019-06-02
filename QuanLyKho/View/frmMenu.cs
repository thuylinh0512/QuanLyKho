using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKho.View
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            new frm_KhachHang().ShowDialog();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            new frm_QLNV().ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new frmNhaCC().ShowDialog();
        }

        private void btnPX_Click(object sender, EventArgs e)
        {
            new frmPhieuXuat().ShowDialog();
        }

        private void btnTKHH_Click(object sender, EventArgs e)
        {
            new frmThongKeHangHoa().ShowDialog();
        }

        private void btnTKNH_Click(object sender, EventArgs e)
        {
            new frmThongKeNhapHang().ShowDialog();
        }

        private void btnTKXH_Click(object sender, EventArgs e)
        {
            new frmThongKeXuatHang().ShowDialog();
        }
    }
}
