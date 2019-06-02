
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyKho.Object;
using QuanLyKho.Control;
namespace QuanLyKho.View
{
    public partial class frm_QLNV : Form
    {
        DataTable db = new DataTable();
        int fl = 0;
        NhanVienObjTH nvObj = new NhanVienObjTH();
        NhanVienCtrlTH nvCtrl = new NhanVienCtrlTH();
        public frm_QLNV()
        {
            InitializeComponent();
        }

        private void frm_QLNV_Load(object sender, EventArgs e)
        {
            db = nvCtrl.GetData();
            dgv_NhanVien.DataSource = db;
            dgv_NhanVien.ReadOnly = true;
            bingding();
            ReadOnly(true);
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = true;
            btn_Sua.Enabled = true;
            txt_TimKiem.ReadOnly = false;
        }
        public void bingding()
        {
            txt_manv.DataBindings.Clear();
            txt_manv.DataBindings.Add("Text", dgv_NhanVien.DataSource, "MaNV");
            txt_tennv.DataBindings.Clear();
            txt_tennv.DataBindings.Add("Text", dgv_NhanVien.DataSource, "TenNV");
            txt_diachi.DataBindings.Clear();
            txt_diachi.DataBindings.Add("Text", dgv_NhanVien.DataSource, "DiaChi");
            txt_sdt.DataBindings.Clear();
            txt_sdt.DataBindings.Add("Text", dgv_NhanVien.DataSource, "SDT");
            cb_gioitinh.DataBindings.Clear();
            cb_gioitinh.DataBindings.Add("Text", dgv_NhanVien.DataSource, "GioiTinh");
            dt_ngaysinh.DataBindings.Clear();
            dt_ngaysinh.DataBindings.Add("Text", dgv_NhanVien.DataSource, "NgaySinh");
        }
        public void ReadOnly(bool e)
        {
            txt_diachi.ReadOnly = e;
            txt_sdt.ReadOnly = e;
            txt_manv.ReadOnly = e;
            txt_tennv.ReadOnly = e;
            cb_gioitinh.Enabled = !e;
            dt_ngaysinh.Enabled = !e;


        }
        void ganDuLieu(NhanVienObjTH Obj)
        {
            Obj.manv = txt_manv.Text.Trim(); ;
            Obj.tennv = txt_tennv.Text.Trim();
            Obj.ngaysinh = dt_ngaysinh.Text.Trim();
            Obj.diachi = txt_diachi.Text.Trim();
            Obj.gioitinh = cb_gioitinh.Text.Trim();
            Obj.sdt = txt_sdt.Text.Trim();

        }
        public void ClearDt()
        {
            txt_manv.Text = "";
            txt_tennv.Text = "";
            txt_diachi.Text = "";
            txt_sdt.Text = "";

        }
        private void txt_sdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void dgv_NhanVien_RowPrePaint_1(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dgv_NhanVien.Rows[e.RowIndex].Cells["STT"].Value = e.RowIndex + 1;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            fl = 0;
            txt_TimKiem.ReadOnly = true;
            ClearDt();
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            ReadOnly(false);
            btn_Them.Enabled = false;
            btn_Huy.Enabled = true;
            btn_Luu.Enabled = true;

            db = nvCtrl.GetData();
            string a = "";
            if (db.Rows.Count <= 0)
            {
                a = "NV01";
            }
            //else
            //{
            //    int k;
            //    a = "NV";
            //    k = int.Parse(db.Rows[db.Rows.Count - 1][0].ToString().Trim().Substring(2, 2));
            //    k = k + 1;
            //    string tam = k.ToString();
            //    for (int i = 0; i < (2 - tam.Length); i++)
            //    {
            //        a += "0";
            //    }
            //    a = a + k.ToString();
            //}
            txt_manv.Text = a;
            this.txt_tennv.Focus();

            string[] s = { "Nam", "Nữ" };
            cb_gioitinh.DataSource = s;
            cb_gioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (txt_sdt.Text == "" || txt_diachi.Text == "" || txt_manv.Text == "" || txt_tennv.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin !");
                txt_tennv.Focus();
            }
            else
            {

                ganDuLieu(nvObj);
                if (fl == 0)
                {

                    if (nvCtrl.addData(nvObj))
                    {

                        MessageBox.Show("Thêm thàng công !", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_QLNV_Load(sender, e);
                    }

                    else
                        MessageBox.Show("Thêm mới không thành công !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_QLNV_Load(sender, e);
                }
                else
                {
                    if (nvCtrl.upData(nvObj))
                    {

                        MessageBox.Show("Sửa thàng công !", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frm_QLNV_Load(sender, e);
                    }

                    else

                        MessageBox.Show("Sửa không thành công !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_QLNV_Load(sender, e);
                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            ReadOnly(false);
            fl = 1;
            txt_manv.ReadOnly = true;
            string[] s = { "Nam", "Nữ" };
            cb_gioitinh.DataSource = s;
            cb_gioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
            dgv_NhanVien.Enabled = false;
            txt_tennv.Focus();
            btn_Them.Enabled = false;
            btn_Sua.Enabled = false;
            btn_Xoa.Enabled = false;
            txt_TimKiem.ReadOnly = true;

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn xóa không ? ", "Xác nhận ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (nvCtrl.delData(txt_manv.Text.Trim()))
                {
                    MessageBox.Show("Xóa thàng công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                frm_QLNV_Load(sender, e);
            }
            else
                return;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            frm_QLNV_Load(sender, e);
        }

        private void btn_TroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_TimKiem_TextChanged(object sender, EventArgs e)
        {

            string str = string.Format("TenNV like '%{0}%'", txt_TimKiem.Text);


            db.DefaultView.RowFilter = str;
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            txt_TimKiem.Text = " ";
            this.txt_TimKiem.Focus();
        }

      

        private void txt_TimKiem_Click(object sender, EventArgs e)
        {
            txt_TimKiem.Text = "";
        }
    }
}
