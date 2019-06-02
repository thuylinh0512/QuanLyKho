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
    public partial class frmNhaCC : Form
    {
        DataTable dt = new DataTable();
        ThongKeCtrlH tke = new ThongKeCtrlH();
        private bool checkAdd = false;
        public frmNhaCC()
        {
            InitializeComponent();
        }

        private void frmNhaCC_Load(object sender, EventArgs e)
        {
            dt = tke.GetData("select * from NhaCC");
            dgvNhaCC.DataSource = dt;
            enable(true);
            if (dgvNhaCC.Rows.Count == 0)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }

            txtMaNhaCC.DataBindings.Clear();
            txtMaNhaCC.DataBindings.Add("Text", dt, "MaNCC");
            txtTenNhaCC.DataBindings.Clear();
            txtTenNhaCC.DataBindings.Add("Text", dt, "TenNCC");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dt, "DiaChi");

            
        }
        private void enable(bool e)
        {
            txtDiaChi.Enabled = !e;
            txtTenNhaCC.Enabled = !e;
            btnThem.Enabled = e;
            btnSua.Enabled = e;
            btnXoa.Enabled = e;
            btnHuy.Enabled = !e;
            btnLuu.Enabled = !e;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            enable(false);
            txtTenNhaCC.Select();
            txtTenNhaCC.Clear();
            txtDiaChi.Clear();
            DataTable dtHd = new DataTable();
            dtHd = tke.GetData("select MaNCC from NhaCC");
            string s = "";
            if (dtHd.Rows.Count <= 0)
            {
                s = "0";
            }
            else
            {
                s = (int.Parse(dtHd.Rows[dtHd.Rows.Count - 1][0].ToString().Trim()) + 1).ToString();
            }
            txtMaNhaCC.Text = s;
            checkAdd = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            enable(false);
            txtTenNhaCC.Select();
            checkAdd = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            frmNhaCC_Load(sender, e);
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xóa nhà cung cấp này ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK )
            {
                if (tke.ThucHienLenh("delete NhaCC where MaNCC = '"+txtMaNhaCC.Text.Trim()+"'") == true)
                {
                    MessageBox.Show("Thành công");
                }
                else
                {
                    MessageBox.Show("Nhà cung cấp này vẫn còn trong các phiếu nhập hàng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmNhaCC_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkAdd == true)
            {
                if (txtTenNhaCC.Text != "")
                {
                    if (tke.ThucHienLenh("insert into nhacc values ('"+txtMaNhaCC.Text.Trim()+"','"+txtTenNhaCC.Text+"','"+txtDiaChi.Text+"')") == true)
                    {
                        MessageBox.Show("Thêm thành công");
                        frmNhaCC_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenNhaCC.Select();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNhaCC.Select();
                }
            }
            else
            {
                if (txtTenNhaCC.Text != "")
                {
                    if (tke.ThucHienLenh("update NhaCC set TenNCC = '"+txtTenNhaCC.Text +"', DiaChi = '"+txtDiaChi.Text+"' where MaNCC = '"+txtMaNhaCC.Text.Trim()+"'") == true)
                    {
                        MessageBox.Show("Sửa thành công");
                        frmNhaCC_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTenNhaCC.Select();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenNhaCC.Select();
                }
            }
            
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                string str = string.Format("MaNCC like '%{0}%' or TenNCC like '%{1}%' or DiaChi like '%{2}%'", txtTimKiem.Text, txtTimKiem.Text, txtTimKiem.Text);
                dt.DefaultView.RowFilter = str;
            }
            if (dgvNhaCC.Rows.Count == 0)
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
        }
    }
}
