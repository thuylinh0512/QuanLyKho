using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKho.Model;
using QuanLyKho.Object;
using QuanLyKho.Control;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.IO;

namespace QuanLyKho.View
{
    public partial class frmPhieuXuat : Form
    {
        int check,check1;
        int fl = 0;
        DataTable dt1,dt2;
        public frmPhieuXuat()
        {
            InitializeComponent();
        }
        private Font printFont;
        private StreamReader streamToPrint;

        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDataKhachHang();
            LoadDataNhanVien();
          
           
        }
        public void LoadData ()
        {
            dt1 = new DataTable();
            dt1 = PhieuXuatCtrl.GetData();
            dgvPhieuXuat.DataSource = dt1;
            txtMaPhieu.Enabled = false;
            cboKhachHang.Enabled = false;
            cboNhanVien.Enabled = false;
            dtpNgay.Enabled = false;
            txtTimKiem.Enabled = true;



            btnHuy.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;

            HuyChucNang();

            
        }
        public void LoadDataNhanVien ()
        {
            cboNhanVien.DataSource = PhieuXuatCtrl.GetDataNhanVien();
            cboNhanVien.ValueMember = "MaNV";
            cboNhanVien.DisplayMember = "TenNV";
        }
        public void LoadDataKhachHang()
        {
            cboKhachHang.DataSource = PhieuXuatCtrl.GetDataKhachHang();
            cboKhachHang.ValueMember = "MaKH";
            cboKhachHang.DisplayMember = "TenKH";
        }

        private void dgvPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtMaPhieu.Text = Convert.ToString(dgvPhieuXuat.CurrentRow.Cells["MaPX"].Value);
                cboNhanVien.Text = Convert.ToString(dgvPhieuXuat.CurrentRow.Cells["TenNV"].Value);

                cboKhachHang.Text = Convert.ToString(dgvPhieuXuat.CurrentRow.Cells["TenKH"].Value);
                dtpNgay.Text = Convert.ToString(dgvPhieuXuat.CurrentRow.Cells["NgayXuat"].Value);
            }
        }

        private void dgvPhieuXuat_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvPhieuXuat.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string str = string.Format("MaPX like '%{0}%' or TenKH like '%{0}%' or TenNV like '%{0}%'", txtTimKiem.Text);
           dt1.DefaultView.RowFilter = str;
        }
       
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            DataTable db = new DataTable();
            db = PhieuXuatCtrl.GetData();
            string a = "";
            if (db.Rows.Count <= 0)
            {
                a = "PX01";
            }
            else
            {
                int k;
                a = "px";
                k = int.Parse(db.Rows[db.Rows.Count - 1][0].ToString().Trim().Substring(2, 2));
                k = k + 1;
                string tam = k.ToString();
                for (int i = 0; i < (2 - tam.Length); i++)
                {
                    a += "0";
                }
                a = a + k.ToString();
            }
            txtMaPhieu.Text = a;
            
            check = 1;
            txtMaPhieu.Enabled = false;
            dtpNgay.Enabled = true;
            cboKhachHang.Enabled = true;
            cboNhanVien.Enabled = true;
            txtTimKiem.Enabled = false;
          

            btnHuy.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;

            dgvPhieuXuat.Enabled = false;

           
            dtpNgay.Text = "";
            cboNhanVien.Text = "";
            cboKhachHang.Text = "";
            //
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            check = 2;
            if (txtMaPhieu.Text == "")
                MessageBox.Show("Bạn cần chọn Phiếu để sửa !", "Thông Báo");
            else
            {
                txtMaPhieu.Enabled = false;
                dtpNgay.Enabled = true;
                cboKhachHang.Enabled = true;
                cboNhanVien.Enabled = true;
                txtTimKiem.Enabled = false;

                btnHuy.Enabled = true;
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                btnLuu.Enabled = true;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text == "")
                MessageBox.Show("Bạn cần chọn Phiếu để xóa !", "Thông Báo");
            else
              if (MessageBox.Show("Bạn có chắc chắn muốn xóa PHiếu " + txtMaPhieu.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                PhieuXuatObj qh = new PhieuXuatObj();
                qh.MaPX = txtMaPhieu.Text;
                if (PhieuXuatCtrl.DeleteProfile(qh) > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    frmPhieuXuat_Load(sender, e);



                }
                else MessageBox.Show("Không thể Xóa");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaPhieu.Text == "" || cboNhanVien.Text == "" || cboKhachHang.Text == "" || dtpNgay.Text == "" )
            {
                MessageBox.Show("Bạn Cần Điền Đầy Đủ Thông Tin Trước Khi Lưu", "Thông Báo");
            }
            else
                if (check == 1)
            {
                PhieuXuatObj qh = new PhieuXuatObj();
                qh.MaPX = txtMaPhieu.Text;
                qh.MaNV = cboNhanVien.SelectedValue.ToString();
                qh.MaKH = cboKhachHang.SelectedValue.ToString();
                qh. NgayXuat = DateTime.Parse(dtpNgay.Text);
              
              
                if (PhieuXuatCtrl.InsertProfile(qh) > 0)
                {
                    MessageBox.Show("Thêm mới thành công");
                    frmPhieuXuat_Load(sender, e);
                    dgvPhieuXuat.Enabled = true;

                }
                else MessageBox.Show("Không thể thêm mới");

            }

            else
            {
                PhieuXuatObj qh = new PhieuXuatObj();
                qh.MaPX = txtMaPhieu.Text;
                qh.MaNV = cboNhanVien.SelectedValue.ToString();
                qh.MaKH = cboKhachHang.SelectedValue.ToString();
                qh.NgayXuat = DateTime.Parse(dtpNgay.Text);
                if (PhieuXuatCtrl.UpdateProfile(qh) > 0)
                {
                    MessageBox.Show("Sửa thành công");
                    frmPhieuXuat_Load(sender, e);
                    dgvPhieuXuat.Enabled = true;

                }
                else MessageBox.Show("Không thể Sửa");

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaPhieu.Enabled = false;
            dtpNgay.Enabled = false;
            cboKhachHang.Enabled = false;
            cboNhanVien.Enabled = false;
            txtTimKiem.Enabled = true;
           

            btnHuy.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;

            dgvPhieuXuat.Enabled = true;

            txtMaPhieu.Text = "";
            dtpNgay.Text = "";
            cboNhanVien.Text = "";
            cboKhachHang.Text = "";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaPhieu_TextChanged(object sender, EventArgs e)
        {
            LoadDataChiTiet();
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                cboTenSP.Text = Convert.ToString(dgvChiTiet.CurrentRow.Cells["TenSP"].Value);
                txtSL.Text = Convert.ToString(dgvChiTiet.CurrentRow.Cells["SoLuong"].Value);
                comboBox1.Text = Convert.ToString(dgvChiTiet.CurrentRow.Cells["ChungLoai"].Value);
                
            }
        }

        private void dgvChiTiet_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgvChiTiet.Rows[e.RowIndex].Cells["STT1"].Value = e.RowIndex + 1;
        }

        private void txtTimKiem1_TextChanged(object sender, EventArgs e)
        {
            string str = string.Format("TenSP like '%{0}%' ", txtTimKiem1.Text);
            dt2.DefaultView.RowFilter = str;
        }
    

        public void LoadDataSanPham()
        {
            cboTenSP.DataSource = PhieuXuatChiTietCtrl.GetDataSanPham();
            cboTenSP.ValueMember = "MaSP";
            cboTenSP.DisplayMember = "TenSP";
        }
        public void LoadDataChiTiet ()
        {
            btnThoat1.Enabled = true;
            LoadDataSanPham();
            cboTenSP.Text = "";
            dt2 = new DataTable();
            dt2 = PhieuXuatChiTietCtrl.GetData(txtMaPhieu.Text);
            dgvChiTiet.DataSource = dt2;
            btnThem1.Enabled = true;
            btnSua1.Enabled = true;
            btnXoa1.Enabled = true;
            txtTimKiem1.Enabled = true;
            dgvChiTiet.Enabled = true;
        }

        private void btnThem1_Click(object sender, EventArgs e)
        {
            check1 = 1;
            cboTenSP.Enabled = true;
            txtSL.Enabled = true;
            comboBox1.Enabled = true;
           
            txtTimKiem1.Enabled = false;


            btnHuy1.Enabled = true;
            btnThem1.Enabled = false;
            btnSua1.Enabled = false;
            btnXoa1.Enabled = false;
            btnLuu1.Enabled = true;

            dgvChiTiet.Enabled = false;

            cboTenSP.Text = "";
            txtSL.Text = "";
            comboBox1.Text = "";
            
        }

        private void btnSua1_Click(object sender, EventArgs e)
        {
            check1 = 2;
            if (cboTenSP.Text == "")
                MessageBox.Show("Bạn cần chọn Sản Phẩm để sửa !", "Thông Báo");
            else
            {
                
                txtSL.Enabled = true;
                comboBox1.Enabled = true;

                txtTimKiem1.Enabled = false;


                btnHuy1.Enabled = true;
                btnThem1.Enabled = false;
                btnSua1.Enabled = false;
                btnXoa1.Enabled = false;
                btnLuu1.Enabled = true;
            }
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            if (cboTenSP.Text == "")
                MessageBox.Show("Bạn cần chọn Sản Phẩm để xóa !", "Thông Báo");
            else
             if (MessageBox.Show("Bạn có chắc chắn muốn xóa Sản Phẩm " + cboTenSP.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ChiTietPhieuXuatObj qh = new ChiTietPhieuXuatObj();
                qh.MaPX = txtMaPhieu.Text;
                qh.MaSP = cboTenSP.SelectedValue.ToString();
                if (PhieuXuatChiTietCtrl.DeleteProfile(qh) > 0)
                {
                    MessageBox.Show("Xóa thành công");
                    LoadDataChiTiet();



                }
                else MessageBox.Show("Không thể Xóa");
            }
        }

        private void btnHuy1_Click(object sender, EventArgs e)
        {
            cboTenSP.Enabled = false;
            txtSL.Enabled = false;
            comboBox1.Enabled = false;
            txtTimKiem.Enabled = true;


            btnHuy1.Enabled = false;
            btnThem1.Enabled = true;
            btnSua1.Enabled = true;
            btnXoa1.Enabled = true;
            btnLuu1.Enabled = false;

            dgvChiTiet.Enabled = true;

            cboTenSP.Text = "";
            txtSL.Text = "";
            comboBox1.Text = "";
            
        }

        private void btnThoat1_Click(object sender, EventArgs e)
        {
            DVPrintPreviewDialog.Document = DVPrintDocument;
            DVPrintPreviewDialog.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void DVPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Phiếu Xuất Hàng", new Font("Arial", 50, FontStyle.Regular), Brushes.Black, new Point(150, 50));


            e.Graphics.DrawString("Mã Phiếu Nhập :" + txtMaPhieu.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(50, 200));
            e.Graphics.DrawString("Ngày Lập :" + dtpNgay.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(50, 240));
            e.Graphics.DrawString("Khách Hàng :" +cboKhachHang.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(50, 280));
            e.Graphics.DrawString("Nhân Viên :" + cboNhanVien.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(50, 320));
            e.Graphics.DrawString("------------------------------------------------------------------------------------------", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, 350));
            int a = 50;
            if (dgvChiTiet.RowCount >= 1)
            {

                e.Graphics.DrawString("STT ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, 400));
                e.Graphics.DrawString("Sản Phẩm ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(250, 400));
                e.Graphics.DrawString("Chủng Loại ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(450, 400));
                e.Graphics.DrawString("Số Lượng ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(700, 400));
               
                e.Graphics.DrawString("------------------------------------------------------------------------------------------", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, 420));

                int S = 450;

                for (int i = 0; i < dgvChiTiet.Rows.Count; i++)
                {
                  
                    e.Graphics.DrawString("------------------------------------------------------------------------------------------", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, S+20));

                    e.Graphics.DrawString("" + dgvChiTiet.Rows[i].Cells["STT1"].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(25, S));
                    e.Graphics.DrawString("" + dgvChiTiet.Rows[i].Cells["TenSP"].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(250, S));
                    e.Graphics.DrawString("" + dgvChiTiet.Rows[i].Cells["ChungLoai"].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(450, S));
                    e.Graphics.DrawString("" + dgvChiTiet.Rows[i].Cells["SoLuong"].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(700, S));
                  


                    S = S + a;


                }


            
            }

        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void btnLuu1_Click(object sender, EventArgs e)
        {
            if (cboTenSP.Text == "" || comboBox1.Text == "" || txtSL.Text == "" )
            {
                MessageBox.Show("Bạn Cần Điền Đầy Đủ Thông Tin Trước Khi Lưu", "Thông Báo");
            }
            else
                if (check1 == 1)
            {
                ChiTietPhieuXuatObj qh = new ChiTietPhieuXuatObj();
                qh.MaPX = txtMaPhieu.Text;
                qh.MaSP = cboTenSP.SelectedValue.ToString();
                qh.SoLuong = int.Parse(txtSL.Text);
                qh.ChungLoai = comboBox1.Text;


                if (PhieuXuatChiTietCtrl.InsertProfile(qh) > 0)
                {
                    MessageBox.Show("Thêm mới thành công");
                    frmPhieuXuat_Load(sender, e);
                    LoadDataChiTiet();
                    dgvPhieuXuat.Enabled = true;

                }
                else MessageBox.Show("Không thể thêm mới");

            }

            else
            {
                ChiTietPhieuXuatObj qh = new ChiTietPhieuXuatObj();
                qh.MaPX = txtMaPhieu.Text;
                qh.MaSP = cboTenSP.SelectedValue.ToString();
                qh.SoLuong = int.Parse(txtSL.Text);
                qh.ChungLoai = comboBox1.Text;
                if (PhieuXuatChiTietCtrl.UpdateProfile(qh) > 0)
                {
                    MessageBox.Show("Sửa thành công");
                    frmPhieuXuat_Load(sender, e);
                    LoadDataChiTiet();
                    dgvPhieuXuat.Enabled = true;

                }
                else MessageBox.Show("Không thể Sửa");

            }
        }

        public void HuyChucNang ()
        {
            cboTenSP.Enabled = false;
            txtSL.Enabled = false;
            comboBox1.Enabled = false;

            txtTimKiem1.Enabled = false;


            dgvChiTiet.Enabled = false;
            btnHuy1.Enabled = false;
            btnLuu1.Enabled = false;
            btnThem1.Enabled = false;
            btnSua1.Enabled = false;
            btnXoa1.Enabled = false;
            btnThoat1.Enabled = false;
        }
    }
}
