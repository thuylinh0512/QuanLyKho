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
using QuanLyKho.Object;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
namespace QuanLyKho.View
{
    public partial class frmNhapHang : Form
    {
        public frmNhapHang()
        {
            InitializeComponent();
        }

        private Font printFont;
        private StreamReader streamToPrint;

        DataTable dt = new DataTable();
        string m_chucnang = "";
        DataTable dtDSCT = new DataTable();
        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            cmbNhaCC.DataSource = NhaCCCtrlTr.GetListNhaCC();
            cmbNhaCC.DisplayMember = "TenNCC";
            cmbNhaCC.ValueMember = "MaNCC";

            cmbNhanVien.DataSource = NhanVienCtrlTr.GetListNhanVien();
            cmbNhanVien.DisplayMember = "TenNV";
            cmbNhanVien.ValueMember = "MaNV";

            cmbSanPham.DataSource = SanPhamCtrlTr.GetListSSanPham();
            cmbSanPham.DisplayMember = "TenSP";
            cmbSanPham.ValueMember = "MaSP";

          
            ChiTietPhieuNhapObjTr cthddvobj = new ChiTietPhieuNhapObjTr();
            cthddvobj.MaPN = lblMaPN.Text;

            dt = ChiTietPhieuNhapCtrlTr.GetListCTPhieuNhap(cthddvobj);
            dtvChiTietPhieuNhap.DataSource = dt;

            nudSoluong.Value = 0;
            lblthanhtien.Text = "0";

            dtDSCT.Rows.Clear();
            dtDSCT.Columns.Add("MaSP");
            dtDSCT.Columns.Add("TenSP");
            dtDSCT.Columns.Add("ChungLoai");
            dtDSCT.Columns.Add("SoLuong");
            dtDSCT.Columns.Add("dongia");
            dtDSCT.Columns.Add("thanhtien");

          

        }
        private void dtvChiTietHoaDonDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void lblMaPN_TextChanged(object sender, EventArgs e)
        {
            PhieuNhapObjTr hddvobj = new PhieuNhapObjTr();
            hddvobj.MaPN = label.Text.Trim();
        }
      
        private void btnSanPham_Click(object sender, EventArgs e)
        {

            this.cmbChungLoai.Enabled = false;
            
            this.btnLuu.Enabled = true;
                this.btnHuy.Enabled = true;
                if (!string.IsNullOrEmpty(lblMaPN.Text))
                {
                    if (!checktrung(cmbSanPham.SelectedValue.ToString()))
                    {
                        DataRow dr = dtDSCT.NewRow();
                        dr[0] = cmbSanPham.SelectedValue.ToString();
                        dr[1] = cmbSanPham.Text;
                        dr[2] = cmbChungLoai.Text;
                        dr[3] = nudSoluong.Value;
                        dr[4] = txtDonGia.Text;
                        dr[5] = (float.Parse(txtDonGia.Text) * int.Parse(nudSoluong.Text)).ToString();
                        dtDSCT.Rows.Add(dr);
                   
                }
                    else
                    {
                  
                    CapnhatSL(cmbSanPham.SelectedValue.ToString(), int.Parse(nudSoluong.Text));
                    }
                    dtvChiTietPhieuNhap.DataSource = dtDSCT;
                }
                lblthanhtien.Text = (float.Parse(txtDonGia.Text) * int.Parse(nudSoluong.Text)).ToString();
                tinhtongtien();
            

        }
        private void CapnhatSL(string mahh, int SL)
        {

            for (int i = 0; i < dtDSCT.Rows.Count; i++)
                if (dtDSCT.Rows[i][0].ToString() == mahh)
                {
                    int soluong = int.Parse(dtDSCT.Rows[i][3].ToString());
                    dtDSCT.Rows[i][3] = soluong + SL;
                    float dongia = float.Parse(dtDSCT.Rows[i][4].ToString());
                    dtDSCT.Rows[i][5] = (dongia * int.Parse(dtDSCT.Rows[i][3].ToString())).ToString();


                    break;
                }

        }
        private bool checktrung(string mapn)
        {
            for (int i = 0; i < dtDSCT.Rows.Count; i++)
                if (dtDSCT.Rows[i][0].ToString() == mapn)
                {

                    return true;
                }
            return false;
        }
        private void tinhtongtien()
        {
            int sc = dtvChiTietPhieuNhap.Rows.Count;
            float thanhtien = 0;
            for (int j = 0; j < sc; j++)
                thanhtien += float.Parse(dtvChiTietPhieuNhap.Rows[j].Cells["thanhtien"].Value.ToString());
            lbltongtien.Text = thanhtien.ToString();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            this.cmbSanPham.Enabled = true;
            this.cmbChungLoai.Enabled = true;
            this.nudSoluong.Enabled = true;
            this.btnLuu.Enabled =false;
            this.btnSanPham.Enabled = true;
            this.btnXoa.Enabled = true;
            this.btnHuy.Enabled = true;
            this.btnSanPham.Visible = true;
            this.btnLuu.Visible = true;
            this.btnHuy.Visible = true;
            this.btnThem.Visible = false;
            this.btnSua.Visible = false;
            this.btnXoa.Visible = true;
            this.btnIn.Visible = false;
            this.btntrolai.Visible = false;
            this.cmbNhaCC.Enabled = true;
            this.cmbNhanVien.Enabled = true;
            this.cmbChungLoai.Enabled = true;
            m_chucnang = "them";
            this.cmbNhanVien.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbNhaCC.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbChungLoai.DropDownStyle = ComboBoxStyle.DropDown;
            DataTable dtpn = new DataTable();
            dtpn = PhieuNhapCtrlTr.GetListPhieuNhap();
            string s = "";
            if (dtpn.Rows.Count <= 0)
            {
                s = "0";
            }
            else
            {
                s = "HBL";
                s = (int.Parse(dtpn.Rows[dtpn.Rows.Count - 1][0].ToString().Trim()) + 1).ToString();
            }
            lblMaPN.Text = s;
          

            cmbSanPham.ResetText();
                cmbChungLoai.ResetText();
                lblthanhtien.Text = "0";
                lbltongtien.Text = "0";
               nudSoluong.Value = 0;
                cmbNhanVien.ResetText();
                cmbNhaCC.ResetText();

            ChiTietPhieuNhapObjTr cthddvobj = new ChiTietPhieuNhapObjTr();
            cthddvobj.MaPN = lblMaPN.Text;

            dt = ChiTietPhieuNhapCtrlTr.GetListCTPhieuNhap(cthddvobj);
            dtvChiTietPhieuNhap.DataSource = dt;
            // dtDSCT.Rows.Clear();
          
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            this.cmbNhanVien.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbNhaCC.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbChungLoai.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbSanPham.Enabled = true;
            this.cmbChungLoai.Enabled = true;
            this.nudSoluong.Enabled = true;
            this.btnSanPham.Visible = true;
            this.btnLuu.Visible = true;
            this.btnHuy.Visible = true;
            this.btnThem.Visible = false;
            this.btnSua.Visible = false;
            this.btnXoa.Visible = true;
            this.btnIn.Visible = false;
            this.btntrolai.Visible = false;
            this.btnSanPham.Enabled = false;
            this.btnXoa.Enabled = false;
            this.btnLuu.Enabled = true;
            this.btnHuy.Enabled = true;
            this.cmbNhaCC.Enabled = true;
            this.cmbNhanVien.Enabled = true;
            this.cmbChungLoai.Enabled = true;
            m_chucnang = "sua";
            cmbSanPham.Focus();
            txtDonGia.Focus();


            // cmbSoLuong.ResetText();
            //txtGiaNhap.ResetText();
            lblMaPN.Focus();
            if (lblMaPN.Text == "")
            {
                this.cmbNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbNhaCC.DropDownStyle = ComboBoxStyle.DropDownList;
                this.cmbChungLoai.DropDownStyle = ComboBoxStyle.DropDownList;
                MessageBox.Show("Chưa chọn thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnSanPham.Visible = false;
                this.btnLuu.Visible = false;
                this.btnHuy.Visible = false;
                this.btnThem.Visible = true;
                this.btnSua.Visible = true;
                this.btnXoa.Visible = false;
                this.btnIn.Visible = true;
                this.btntrolai.Visible = true;
                this.cmbNhaCC.Enabled = false;
                this.cmbNhanVien.Enabled = false;
                this.cmbChungLoai.Enabled = false;
                return;
            }
        }
        int vitriClick = 0;
        private void btnXoa_Click(object sender, EventArgs e)
        {
            //nv.MaPhongBan = cmbMaPhongBan.SelectedText;
            if (MessageBox.Show(string.Format("Xóa Sản Phẩm {0} ", cmbSanPham.Text), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (vitriClick < dtDSCT.Rows.Count)
                {
                    dtDSCT.Rows.RemoveAt(vitriClick);
                    dtvChiTietPhieuNhap.DataSource = dtDSCT;
                    MessageBox.Show("Xóa thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                lblthanhtien.Text = "0";
                tinhtongtien();
            }
        }

        private void dtvChiTietPhieuNhap_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            dtvChiTietPhieuNhap.Rows[e.RowIndex].Cells["stt"].Value = e.RowIndex + 1;
        }

        private void cmbSanPham_TextChanged(object sender, EventArgs e)
        {
            this.cmbChungLoai.Enabled = true;
        }

        private void btntrolai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            DVPrintPreviewDialog.Document = DVPrintDocument;
            DVPrintPreviewDialog.ShowDialog();
        }

       


        private void nudSoluong_Click(object sender, EventArgs e)
        {
            lblthanhtien.Text = (float.Parse(txtDonGia.Text) * int.Parse(nudSoluong.Text)).ToString();
        }

        private void cmbSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                
                PhieuNhapCtrlTr hddvctr = new PhieuNhapCtrlTr();
                SanPhamObjTr dvobj = new SanPhamObjTr();
                dvobj.MaSP = cmbSanPham.SelectedValue.ToString();
                DataTable dt = ChiTietPhieuNhapCtrlTr.GetListTuDongThemGia(dvobj);

                if (dt.Rows.Count > 0)
                {
                    double gia = double.Parse(dt.Rows[0][1].ToString());
                    txtDonGia.Text = gia.ToString();

                    lblthanhtien.Text = (float.Parse(txtDonGia.Text) * int.Parse(nudSoluong.Text)).ToString();
                }
                //if (dt.Rows.Count > 0)
                //{
                //    double gia = double.Parse(dt.Rows[0][1].ToString());
                //    txtDonGia.Text = gia.ToString();
                //    txtDonGia.Text = string.Format( "{0:0,0}", float.Parse(txtDonGia.Text) + " VNĐ");
                //}


            }
            catch
            {

            }
        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {
          txtDonGia.Text = string.Format("{0:0,0 }", (float.Parse(txtDonGia.Text)));
        }

        private void lblthanhtien_TextChanged(object sender, EventArgs e)
        {
            lblthanhtien.Text = string.Format("{0:0,0 }", (float.Parse(lblthanhtien.Text)));
        }

        private void lbltongtien_TextChanged(object sender, EventArgs e)
        {
            lbltongtien.Text = string.Format("{0:0,0 }", (float.Parse(lbltongtien.Text)));
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
           

            try
            {
                if (m_chucnang == "them")
                {

                    if (lblMaPN.Text == "" || cmbNhanVien.Text == "" || cmbNhaCC.Text == "")
                    {
                        MessageBox.Show("Chưa chọn thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                       PhieuNhapObjTr hddvobj = new PhieuNhapObjTr();
                        hddvobj.MaPN= lblMaPN.Text.Trim();
                        hddvobj.TongTien = float.Parse(lbltongtien.Text.Trim());
                        hddvobj.NgayNhap = dtpNgayLap.Value;
                        hddvobj.MaNV= cmbNhanVien.SelectedValue.ToString();
                        hddvobj.MaNCC = cmbNhaCC.SelectedValue.ToString();
                   
                        if (MessageBox.Show(string.Format("Thêm Phiếu Nhập Hàng Có Mã Số Hóa Đơn {0}", hddvobj.MaPN), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (PhieuNhapCtrlTr.InsertPhieuNhap(hddvobj) > 0)
                            {
                                for (int i = 0; i < dtvChiTietPhieuNhap.Rows.Count; i++)
                                {



                                    ChiTietPhieuNhapObjTr cthddvobj = new ChiTietPhieuNhapObjTr();

                                    cthddvobj.MaSP = dtvChiTietPhieuNhap.Rows[i].Cells[1].Value.ToString().Trim();
                                    cthddvobj.MaPN = lblMaPN.Text;
                                    cthddvobj.ChungLoai= dtvChiTietPhieuNhap.Rows[i].Cells[3].Value.ToString().Trim();
                                    cthddvobj.SoLuong = int.Parse(dtvChiTietPhieuNhap.Rows[i].Cells[4].Value.ToString());
                                    cthddvobj.DonGia = float.Parse(dtvChiTietPhieuNhap.Rows[i].Cells[5].Value.ToString());
                                    cthddvobj.ThanhTien = float.Parse(dtvChiTietPhieuNhap.Rows[i].Cells[6].Value.ToString());
                                    ChiTietPhieuNhapCtrlTr.InsertPhieuNhap(cthddvobj) ;
                                }
                               
                                MessageBox.Show("Thêm Phiếu Nhập thành công.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                                this.cmbSanPham.Enabled = false;
                                this.cmbChungLoai.Enabled = false;
                                this.nudSoluong.Enabled = false;
                                this.btnSanPham.Visible = false;
                                this.btnLuu.Visible = false;
                                this.btnHuy.Visible = false;
                                this.btnThem.Visible = true;
                                this.btnSua.Visible = true;
                                this.btnXoa.Visible = false;
                                this.btnIn.Visible = true;
                                this.btntrolai.Visible = true;
                                this.cmbNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
                                this.cmbNhaCC.DropDownStyle = ComboBoxStyle.DropDownList;
                                this.cmbChungLoai.DropDownStyle = ComboBoxStyle.DropDownList;
                                this.cmbNhaCC.Enabled = false;
                                this.cmbNhanVien.Enabled = false;
                                this.cmbChungLoai.Enabled = false;
                                frmNhapHang_Load(sender, e);
                              
                                

                               

                            }
                            else MessageBox.Show("Mã Phiếu Nhập Đã Có,Vui Lòng Nhập Lại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
                if (m_chucnang == "sua")
                {
                    if (lblMaPN.Text == "" || cmbNhanVien.Text == "" || cmbNhaCC.Text == "")
                    {
                        MessageBox.Show("Chưa chọn thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        PhieuNhapObjTr hddvobj = new PhieuNhapObjTr();
                        hddvobj.MaPN = lblMaPN.Text.Trim();
                        hddvobj.TongTien = float.Parse(lbltongtien.Text.Trim());
                        hddvobj.NgayNhap = dtpNgayLap.Value;
                        hddvobj.MaNV = cmbNhanVien.SelectedValue.ToString();
                        hddvobj.MaNCC = cmbNhaCC.SelectedValue.ToString();
                        if (MessageBox.Show(string.Format("Sửa Phiếu Nhập Có Mã Số Hóa Đơn {0}", hddvobj.MaPN), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            if (PhieuNhapCtrlTr.UpdatePhieuNhap(hddvobj)>0)
                            {
                                MessageBox.Show("Sửa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.cmbSanPham.Enabled = false;
                                this.cmbChungLoai.Enabled = false;
                                this.nudSoluong.Enabled = false;
                                this.btnSanPham.Visible = false;
                                this.btnLuu.Visible = false;
                                this.btnHuy.Visible = false;
                                this.btnThem.Visible = true;
                                this.btnSua.Visible = true;
                                this.btnXoa.Visible = false;
                                this.btnIn.Visible = true;
                                this.btntrolai.Visible = true;
                                this.cmbNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
                                this.cmbNhaCC.DropDownStyle = ComboBoxStyle.DropDownList;
                                this.cmbChungLoai.DropDownStyle = ComboBoxStyle.DropDownList;
                                this.cmbNhaCC.Enabled = false;
                                this.cmbNhanVien.Enabled = false;
                                this.cmbChungLoai.Enabled = false;

                            }
                            else MessageBox.Show("Không Sửa Được!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.cmbSanPham.Enabled = false;
            this.cmbChungLoai.Enabled = false;
            this.nudSoluong.Enabled = false;
            this.btnSanPham.Visible = false;
            this.btnLuu.Visible = false;
            this.btnHuy.Visible = false;
            this.btnThem.Visible = true;
            this.btnSua.Visible = true;
            this.btnXoa.Visible = false;
            this.btnIn.Visible = true;
            this.btntrolai.Visible = true;
            this.cmbNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbNhaCC.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbChungLoai.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbNhaCC.Enabled = false;
            this.cmbNhanVien.Enabled = false;
            this.cmbChungLoai.Enabled = false;
            cmbSanPham.ResetText();
            cmbChungLoai.ResetText();
            lblthanhtien.Text = "0";
            lbltongtien.Text = "0";
            nudSoluong.Value = 0;
            cmbNhanVien.ResetText();
            cmbNhaCC.ResetText();

            ChiTietPhieuNhapObjTr cthddvobj = new ChiTietPhieuNhapObjTr();
            cthddvobj.MaPN = lblMaPN.Text;

            dt = ChiTietPhieuNhapCtrlTr.GetListCTPhieuNhap(cthddvobj);
            dtvChiTietPhieuNhap.DataSource = dt;
        }

        private void dtvChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)


                {
                    cmbSanPham.Text = Convert.ToString(dtvChiTietPhieuNhap.CurrentRow.Cells["sanpham"].Value);
                    cmbChungLoai.Text = Convert.ToString(dtvChiTietPhieuNhap.CurrentRow.Cells["chungloai"].Value);
                    txtDonGia.Text = Convert.ToString(dtvChiTietPhieuNhap.CurrentRow.Cells["dongia"].Value);
                    nudSoluong.Value = Convert.ToInt32(dtvChiTietPhieuNhap.CurrentRow.Cells["soluong"].Value);
                    lblthanhtien.Text = Convert.ToString(dtvChiTietPhieuNhap.CurrentRow.Cells["thanhtien"].Value);

                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void DVPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Phiếu Nhập Hàng", new Font("Arial", 50, FontStyle.Regular), Brushes.Black, new Point(150, 50));
      

            e.Graphics.DrawString("Mã Phiếu Nhập :" + lblMaPN.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(50, 200));
            e.Graphics.DrawString("Ngày Lập :" + dtpNgayLap.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(50, 240));
            e.Graphics.DrawString("Nhà Cung Cấp :" + cmbNhaCC.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(50, 280));
            e.Graphics.DrawString("Nhân Viên :" + cmbNhanVien.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(50, 320));
            e.Graphics.DrawString(LalCham.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, 330));
            int a = 50;
            if (dtvChiTietPhieuNhap.RowCount >= 1)
            {

                e.Graphics.DrawString("STT ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, 400));
                e.Graphics.DrawString("Sản Phẩm ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(80, 400));
                e.Graphics.DrawString("Chủng Loại ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(250, 400));
                e.Graphics.DrawString("Số Lượng ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(400, 400));
                e.Graphics.DrawString("Đơn Giá ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(550, 400));
                e.Graphics.DrawString("Thành Tiền ", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(700, 400));
                e.Graphics.DrawString(LalCham.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, 420));

                int S = 450;

                for (int i = 0; i < dtvChiTietPhieuNhap.Rows.Count; i++)
                {
                    e.Graphics.DrawString(LalCham.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, 470));
                    e.Graphics.DrawString(LalCham.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(25, S + 70));

                    e.Graphics.DrawString("" + dtvChiTietPhieuNhap.Rows[i].Cells["stt"].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(25, S));
                    e.Graphics.DrawString("" + dtvChiTietPhieuNhap.Rows[i].Cells["sanpham"].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(75, S));
                    e.Graphics.DrawString("" + dtvChiTietPhieuNhap.Rows[i].Cells["chungloai"].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(250, S));
                    e.Graphics.DrawString("" + dtvChiTietPhieuNhap.Rows[i].Cells["soluong"].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(400, S));
                    e.Graphics.DrawString("" + dtvChiTietPhieuNhap.Rows[i].Cells["dongia"].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(550, S));
                    e.Graphics.DrawString("" + dtvChiTietPhieuNhap.Rows[i].Cells["thanhtien"].Value.ToString(), new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(700, S));


                    S = S + a;


                }
               

                e.Graphics.DrawString("Tổng Tiền :" + lbltongtien.Text + "VND", new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(50, 50 + S));
                e.Graphics.DrawString("Cảm Ơn Quý Khách", new Font("Arial", 25, FontStyle.Regular), Brushes.Black, new Point(200, 90 + S));
            }


        }

        private void cmbNhanVien_TextChanged(object sender, EventArgs e)
        {
        }

        private void dtvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
