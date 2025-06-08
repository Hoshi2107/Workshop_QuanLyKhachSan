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
            //BUSDichVu bUSDichVu = new BUSDichVu();
            //dgvDichVu.DataSource = bUSDichVu.GetDichVuList();
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
            textDichVuID.Clear();
            textGhiChu.Clear();
            textHoaDonThueID.Clear();
            textTimKiem.Clear();
            guna2DateTimePicker1.Value = DateTime.Now;
            textDichVuID.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string DichVuID = textDichVuID.Text.Trim();
            string HoaDonThueID = textHoaDonThueID.Text.Trim();

            DateTime ngayTao = guna2DateTimePicker1.Value;
            bool trangThai = RdoDaThanhToan.Checked;
            if (string.IsNullOrEmpty(HoaDonThueID))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ghiChu = textGhiChu.Text.Trim();

            DichVu dichvu = new DichVu
            {
                DichVuID = DichVuID,
                HoaDonThueID = HoaDonThueID,
                NgayTao = ngayTao,
                TrangThai = trangThai,
                GhiChu = ghiChu
            };

            BUSDichVu dichVu = new BUSDichVu();
            string result = dichVu.AddDichVu(dichvu);

            if (result == "Vui lòng nhập đủ thông tin hợp lệ!")
            {
                MessageBox.Show(result);
                return;
            }

            if (string.IsNullOrEmpty(result) || result == "")
            {
                MessageBox.Show("Thêm mới loại dịch vụ thành công");
                LoaddichVu();
                ClearFrom();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            string DichVuID = textDichVuID.Text.Trim();

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
            string DichVuID = textDichVuID.Text.Trim();
            string HoaDonThueID = textHoaDonThueID.Text.Trim();

            DateTime ngayTao = guna2DateTimePicker1.Value;
            bool trangThai = RdoDaThanhToan.Checked;

            if (string.IsNullOrEmpty(HoaDonThueID))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ghiChu = textGhiChu.Text.Trim();
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
            //DataGridViewRow row = dgrDichVu.Rows[e.RowIndex];
            //textDichVuID.Text = row.Cells["DichVuID"].Value.ToString();
            //textHoaDonThueID.Text = row.Cells["HoaDonThueID"].Value.ToString();
            //textGhiChu.Text = row.Cells["GhiChu"].Value.ToString();            
            //guna2DateTimePicker1.Text = row.Cells["NgayTao"].Value.ToString();
            //bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            //if (trangThai)
            //{
            //    RdoDaThanhToan.Checked = true;
            //}
            //else
            //{
            //    RdoChuaThanhToan.Checked = true;
            //}
            //btnThem.Enabled = false;
            //btnSua.Enabled = true;
            //btnXoa.Enabled = true;
            //textDichVuID.Enabled = false;

        }
    }
}
