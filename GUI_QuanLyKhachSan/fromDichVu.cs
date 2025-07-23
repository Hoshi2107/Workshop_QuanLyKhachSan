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
            ClearFrom();
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

            DichVu dichvu = new DichVu
            {
                DichVuID = DichVuID,
                HoaDonThueID = HoaDonThueID,
                NgayTao = ngayTao,
                TrangThai = trangThai,
                GhiChu = ghiChu
            };

            BUSDichVu busDichVu = new BUSDichVu(); // đổi tên biến
            string result = busDichVu.AddDichVu(dichvu); // gọi đúng tên biến DTO

            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result);
                return;
            }

            MessageBox.Show("Thêm mới dịch vụ thành công!");
            LoaddichVu();
            ClearFrom();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            string DichVuID = txtIDDichVu.Text.Trim();

            if (string.IsNullOrEmpty(DichVuID))
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa loại dịch vụ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                BUSDichVu dichVu = new BUSDichVu();
                string result = dichVu.DeleteDichVu(DichVuID);

                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Có lỗi xảy ra: " + result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Xóa loại dịch vụ thành công!");
                LoaddichVu();
                ClearFrom();
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
            DichVu dichvu = new DichVu
            {
                DichVuID = DichVuID,
                HoaDonThueID = HoaDonThueID,

                NgayTao = ngayTao,
                TrangThai = trangThai,
                GhiChu = ghiChu
            };

            BUSDichVu service = new BUSDichVu();
            string result = service.UpdateDichVu(dichvu);
            if (result == "Vui lòng nhập đủ thông tin hợp lệ!")
            {
                MessageBox.Show(result);
                return;
            }

            if (string.IsNullOrEmpty(result) || result == "")
            {
                MessageBox.Show("Cập nhật loại dịch vụ thành công");
                LoaddichVu();
                ClearFrom();
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
