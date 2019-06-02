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
    public partial class frmThongKeXuatHang : Form
    {
        DataTable dtXuat = new DataTable();
        DataTable dtCT = new DataTable();
        ThongKeCtrlH tke = new ThongKeCtrlH();
        private DateTime tungay, denngay;
        public frmThongKeXuatHang()
        {
            InitializeComponent();
        }

        private void frmThongKeXuatHang_Load(object sender, EventArgs e)
        {
            dtpDenNgay.Value = DateTime.Today;
            btnXoa.Enabled = false;
            btnXoaCT.Enabled = false;
            btnSua.Enabled = false;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            nudSoLuong.Enabled = false;
        }

        private void txtMaPhieu_TextChanged(object sender, EventArgs e)
        {
            cmbNhanVien.DataSource = tke.GetData("select PhieuXuat.MaNV, TenNV from NhanVien, PhieuXuat where PhieuXuat.MaNV = NhanVien.MaNV and MaPX = '" + txtMaPhieu.Text.Trim() + "'");
            cmbNhanVien.DisplayMember = "TenNV";
            cmbNhanVien.ValueMember = "MaNV";

            cmbNhaCC.DataSource = tke.GetData("select PhieuXuat.MaKH, TenKH from KhachHang, PhieuXuat where PhieuXuat.MaKH = KhachHang.MaKH and MaPX = '" + txtMaPhieu.Text.Trim() + "'");
            cmbNhaCC.DisplayMember = "TenKH";
            cmbNhaCC.ValueMember = "MaKH";

            //chi tiet
            dtCT = tke.GetData("select SanPham.MaSP, TenSP, PhieuXuatChiTiet.SoLuong, PhieuXuatChiTiet.ChungLoai from SanPham, PhieuXuatChiTiet where SanPham.MaSP = PhieuXuatChiTiet.MaSP and MaPX = '" + txtMaPhieu.Text.Trim() + "'");
            dgvChiTiet.DataSource = dtCT;

            if (dgvChiTiet.Rows.Count > 0)
            {
                btnXoaCT.Enabled = true;
                btnSua.Enabled = true;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
            }
            else
            {
                btnXoaCT.Enabled = false;
                btnSua.Enabled = false;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
            }

            txtMaSP.DataBindings.Clear();
            txtMaSP.DataBindings.Add("Text", dtCT, "MaSP");
            txtTenSP.DataBindings.Clear();
            txtTenSP.DataBindings.Add("Text", dtCT, "TenSP");
            nudSoLuong.DataBindings.Clear();
            nudSoLuong.DataBindings.Add("Text", dtCT, "SoLuong");
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dtXuat.Rows.Count > 0)
            {
                string str = string.Format("MaPX like '%{0}%'", txtTimKiem.Text);
                dtXuat.DefaultView.RowFilter = str;
            }
        }
        int slcu;
        private void btnSua_Click(object sender, EventArgs e)
        {
            slcu = int.Parse(nudSoLuong.Value.ToString());
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnHuy.Enabled = true;
            btnXoaCT.Enabled = false;
            btnLuu.Enabled = true;
            dgvChiTiet.Enabled = false;
            nudSoLuong.Enabled = true;
            nudSoLuong.Select();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnXoaCT.Enabled = true;
            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            dgvChiTiet.Enabled = true;
            nudSoLuong.Enabled = false;
            dtCT = tke.GetData("select SanPham.MaSP, TenSP, PhieuXuatChiTiet.SoLuong, PhieuXuatChiTiet.ChungLoai from SanPham, PhieuXuatChiTiet where SanPham.MaSP = PhieuXuatChiTiet.MaSP and MaPX = '" + txtMaPhieu.Text.Trim() + "'");
            dgvChiTiet.DataSource = dtCT;
        }

        private void btnXoaCT_Click(object sender, EventArgs e)
        {
            int sl = int.Parse(nudSoLuong.Value.ToString());
            if (MessageBox.Show("Xóa sản phẩm trong phiếu xuất ?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                string s = "delete PhieuXuatChiTiet where MaSP = '" + txtMaSP.Text.Trim() + "' and MaPX = '" + txtMaPhieu.Text.Trim() + "'";
                if (tke.ThucHienLenh(s) == true)
                {
                    MessageBox.Show("Xóa thành công");
                    tke.ThucHienLenh("update SanPham set SoLuong = SoLuong + "+sl+ " where MaSP = '" + txtMaSP.Text.Trim() + "'");

                    DataTable dttemp = new DataTable();
                    dttemp = tke.GetData("select * from PhieuXuatChiTiet where MaPX = '" + txtMaPhieu.Text.Trim() + "'");
                    if (dttemp.Rows.Count == 0)
                    {
                        tke.ThucHienLenh("delete PhieuXuat where MaPX = '" + txtMaPhieu.Text.Trim() + "'");
                    }
                    btnHuy_Click(sender, e);
                    btnTimKiem_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int slmoi = int.Parse(nudSoLuong.Value.ToString());
            string s = "update PhieuXuatChiTiet set SoLuong =" + nudSoLuong.Value.ToString() + " where MaPX = '" + txtMaPhieu.Text.Trim() + "' and MaSP = '" + txtMaSP.Text.Trim() + "' ";
            if (tke.ThucHienLenh(s) == true)
            {
                MessageBox.Show("Sửa thành công");
                tke.ThucHienLenh("update SanPham set SoLuong = SoLuong + " + slcu + " - " + slmoi + " where MaSP = '"+txtMaSP.Text.Trim()+"'");
                dgvChiTiet.Enabled = true;
                dgvPhieuXuat.Enabled = true;
                btnHuy_Click(sender, e);
                btnTimKiem_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Thất bại ");
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Xóa phiếu xuất ?", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                
                if (tke.ThucHienLenh("delete PhieuXuatChiTiet where MaPX = '" + txtMaPhieu.Text.Trim() + "'") == true)
                {
                    for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
                    {
                        string s = "update SanPham set SoLuong = SoLuong+ '" + dgvChiTiet.Rows[i].Cells[2].Value.ToString() + "' where MaSP = '" + dgvChiTiet.Rows[i].Cells[0].Value.ToString() + "'";
                        tke.ThucHienLenh(s);
                    }
                    if (tke.ThucHienLenh("delete PhieuXuat where MaPX = '" + txtMaPhieu.Text.Trim() + "'") == true)
                    {
                        MessageBox.Show("Xóa thành công");
                        btnTimKiem_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");
                    }
                }

            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Clear();
            string s = "select * from PhieuXuat where NgayXuat between '" + dtpTuNgay.Value.ToShortDateString() + "' and '" + dtpDenNgay.Value.ToShortDateString() + "'";
            dtXuat = tke.GetData(s);
            dgvPhieuXuat.DataSource = dtXuat;
            tungay = dtpTuNgay.Value;
            denngay = dtpDenNgay.Value;

            if (dgvPhieuXuat.Rows.Count == 0)
            {
                btnXoa.Enabled = false;
                btnXoaCT.Enabled = false;
                btnSua.Enabled = false;
                btnHuy.Enabled = false;
                btnLuu.Enabled = false;
            }
            else
            {
                btnXoa.Enabled = true;
            }
            
            txtMaPhieu.DataBindings.Clear();
            txtMaPhieu.DataBindings.Add("Text", dtXuat, "MaPX");
            dtpNgayXuat.DataBindings.Clear();
            dtpNgayXuat.DataBindings.Add("Text", dtXuat, "NgayXuat");
        }
    }
}
