using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL_QuanLyKhachSan;
using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;

namespace GUI_QuanLyKhachSan
{
    public partial class fromDichVu : Form
    {
        public fromDichVu()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
        private void LoaddichVu()
        {
            BUSDichVu bUSDichVu = new BUSDichVu();
            dgvDichVu.DataSource = bUSDichVu.GetDichVuList();
        }
        private void DichVu_Load(object sender, EventArgs e)
        {
            LoaddichVu();
            loadCombobox();
            ClearFrom();
        }
        private void loadCombobox()
        {
            BusDatPhong busDatPhong = new BusDatPhong();
            cboHoaDonThueID.DataSource = busDatPhong.GetDatPhongList();
            cboHoaDonThueID.DisplayMember = "HoaDonThueID"; 
            cboHoaDonThueID.ValueMember = "HoaDonThueID"; 
           
        }
        private void ClearFrom()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = true;
            txtIDDichVu.Clear();
            txtGhiChu.Clear();
            cboHoaDonThueID.SelectedIndex = -1;
            textTimKiem.Clear();
            dtpNgayTao.Value = DateTime.Now;
            txtIDDichVu.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string DichVuID = txtIDDichVu.Text.Trim();
            string HoaDonThueID = cboHoaDonThueID.Text.Trim();
            DateTime ngayTao = dtpNgayTao.Value;
            bool trangThai = rdoDaThanhToan.Checked;

            if (string.IsNullOrEmpty(HoaDonThueID))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ghiChu = txtGhiChu.Text.Trim();

            DTO_DichVU dichvu = new DTO_DichVU
            {
                DichVuID = DichVuID,
                HoaDonThueID = HoaDonThueID,
                NgayTao = ngayTao,
                TrangThai = trangThai,
                GhiChu = ghiChu
            };

            BUSDichVu busDichVu = new BUSDichVu(); // đổi tên biến
            string result = busDichVu.AddDichVu(dichvu); // gọi đúng tên biến DTO

            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Thêm dịch vụ thành công!");
                LoaddichVu();
                ClearFrom();
            }
            else
            {
                MessageBox.Show("Lỗi: " + result);
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            if (dgvDichVu.SelectedRows.Count > 0)
            {
                string dichvu = dgvDichVu.SelectedRows[0].Cells["DichVuID"].Value.ToString();
                BUSDichVu busDv = new BUSDichVu(); // đổi tên biến
                string result = busDv.DeleteDichVu(dichvu);

                if (string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Xóa dịch vụ thành công!");
                    LoaddichVu();
                }
                else
                {
                    MessageBox.Show("Lỗi khi xóa: " + result);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng cần xóa!");
            }


        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            string DichVuID = txtIDDichVu.Text.Trim();
            string HoaDonThueID = cboHoaDonThueID.Text.Trim();

            DateTime ngayTao = dtpNgayTao.Value;
            bool trangThai = rdoDaThanhToan.Checked;

            if (string.IsNullOrEmpty(HoaDonThueID))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ghiChu = txtGhiChu.Text.Trim();
            DTO_DichVU dichvu = new DTO_DichVU
            {
                DichVuID = DichVuID,
                HoaDonThueID = HoaDonThueID,

                NgayTao = ngayTao,
                TrangThai = trangThai,
                GhiChu = ghiChu
            };

            BUSDichVu service = new BUSDichVu();
            string result = service.UpdateDichVu(dichvu);
            if (string.IsNullOrEmpty(result))
            {
                MessageBox.Show("Sửa dịch vụ thành công!");
                LoaddichVu();
                ClearFrom();
            }
            else
            {
                MessageBox.Show("Lỗi: " + result);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearFrom();
            LoaddichVu();
        }

        private void dgrDichVu_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDichVu.Rows[e.RowIndex];
            txtIDDichVu.Text = row.Cells["DichVuID"].Value.ToString();
            cboHoaDonThueID.Text = row.Cells["HoaDonThueID"].Value.ToString();
            txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();            
            dtpNgayTao.Text = row.Cells["NgayTao"].Value.ToString();
            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai)
            {
                rdoDaThanhToan.Checked = true;
            }
            else
            {
                rdoChuaThanhToan.Checked = true;
            }
            btnThem.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtIDDichVu.Enabled = false;

        }

        private void guna2DgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDichVu.Rows[e.RowIndex];
                txtIDDichVu.Text = row.Cells["DichVuID"].Value.ToString();
                cboHoaDonThueID.Text = row.Cells["HoaDonThueID"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu"].Value.ToString();
                dtpNgayTao.Text = row.Cells["NgayTao"].Value.ToString();

                bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
                if (trangThai)
                {
                    rdoDaThanhToan.Checked = true;
                }
                else
                {
                    rdoChuaThanhToan.Checked = true;
                }

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtIDDichVu.Enabled = false;
            }
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
