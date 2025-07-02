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
using UTIL_QuanLyKhachSan;
namespace GUI_QuanLyKhachSan
{
    public partial class LoaiDichVu : Form
    {
        BUSLoaiDV busLoaiDichVu = new BUSLoaiDV();
        public LoaiDichVu()
        {
            InitializeComponent();
        }

        private void LoaiDichVu_Load(object sender, EventArgs e)
        {
            loadLoaiDV();
            ClearFrom();
        }
        private void ClearFrom()
        {
            txtLoaiDichVuID.Clear();
            txtTenDV.Clear();
            TextGiaDV.Clear();
            txtdonvitinh.Clear();
            txtghichu.Clear();
            txtTimKiem.Clear();
            dtpNgayTao.Value = DateTime.Now;

            rdoConHoatDong.Checked = true; // mặc định là còn hoạt động

            // Trạng thái nút
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            // Cho phép tạo mã tự động
            txtLoaiDichVuID.Enabled = false;
        }
        private void loadLoaiDV()
        {
            try
            {
                BUSLoaiDV bus = new BUSLoaiDV();
                dgrLoaiDV.DataSource = bus.GetLoaiDVList();

                // Tùy chọn: tự động căn lại cột cho đẹp
                dgrLoaiDV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dgrLoaiDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo không click vào header
            {
                DataGridViewRow row = dgrLoaiDV.Rows[e.RowIndex];

                txtLoaiDichVuID.Text = row.Cells["LoaiDichVuID"].Value.ToString();
                txtTenDV.Text = row.Cells["TenDichVu"].Value.ToString();
                TextGiaDV.Text = row.Cells["GiaDichVu"].Value.ToString();
                txtdonvitinh.Text = row.Cells["DonViTinh"].Value.ToString();
                dtpNgayTao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
                txtghichu.Text = row.Cells["GhiChu"].Value.ToString();

                bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
                rdoConHoatDong.Checked = trangThai;
                rdoKhongHoatDong.Checked = !trangThai;

                // Bật/tắt các nút phù hợp
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;

                txtLoaiDichVuID.Enabled = false; // Không cho sửa mã
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BUSLoaiDV service = new BUSLoaiDV();

            // Tự động tạo mã nếu bạn không nhập thủ công
            string loaiDichVuID = txtLoaiDichVuID.Text.Trim();
            if (string.IsNullOrEmpty(loaiDichVuID))
            {
                loaiDichVuID = service.GenerateNewLoaiDichVuID(); // cần có hàm này trong BUS
                txtLoaiDichVuID.Text = loaiDichVuID;
            }

            string tenDichVu = txtTenDV.Text.Trim();
            string giaDichVutext = TextGiaDV.Text.Trim();
            string donViTinh = txtdonvitinh.Text.Trim();
            DateTime ngayTao = dtpNgayTao.Value;
            bool trangThai = rdoConHoatDong.Checked;

            if (string.IsNullOrEmpty(tenDichVu) || string.IsNullOrEmpty(giaDichVutext) || string.IsNullOrEmpty(donViTinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(giaDichVutext, out decimal giaDichVu))
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ghiChu = txtghichu.Text.Trim();

            DTO_LoaiDichVu ldv = new DTO_LoaiDichVu
            {
                LoaiDichVuID = loaiDichVuID,
                TenDichVu = tenDichVu,
                GiaDichVu = giaDichVu,
                DonViTinh = donViTinh,
                NgayTao = ngayTao,
                TrangThai = trangThai,
                GhiChu = ghiChu
            };

            string result = service.AddLoaiDichVu(ldv);

            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Thêm mới loại dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadLoaiDV();    // đảm bảo bạn gọi đúng hàm (không bị typo)
            ClearFrom();     // xóa form để nhập tiếp

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            loadLoaiDV();
            ClearFrom();
        }



        private void dgrLoaiDV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgrLoaiDV.Rows[e.RowIndex];

            txtLoaiDichVuID.Text = row.Cells["LoaiDichVuID"].Value.ToString();
            txtTenDV.Text = row.Cells["TenDichVu"].Value.ToString();
            TextGiaDV.Text = row.Cells["GiaDichVu"].Value.ToString();
            txtdonvitinh.Text = row.Cells["DonViTinh"].Value.ToString();
            dtpNgayTao.Text = row.Cells["NgayTao"].Value.ToString();
            txtghichu.Text = row.Cells["GhiChu"].Value.ToString();
            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai)
            {
                rdoConHoatDong.Checked = true;
            }
            else
            {
                rdoKhongHoatDong.Checked = true;
            }


        }

        private void btnSưa_Click(object sender, EventArgs e)
        {
            string loaiDichVuID = txtLoaiDichVuID.Text.Trim();
            string tenDichVu = txtTenDV.Text.Trim();
            string giaDichVutext = TextGiaDV.Text.Trim();
            string donViTinh = txtdonvitinh.Text.Trim();
            DateTime ngayTao = dtpNgayTao.Value;
            bool trangThai = rdoConHoatDong.Checked;

            if (string.IsNullOrEmpty(loaiDichVuID) || string.IsNullOrEmpty(tenDichVu) || string.IsNullOrEmpty(giaDichVutext) || string.IsNullOrEmpty(donViTinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(giaDichVutext, out decimal giaDichVu))
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string ghiChu = txtghichu.Text.Trim();

            DTO_LoaiDichVu ldv = new DTO_LoaiDichVu
            {
                LoaiDichVuID = loaiDichVuID,
                TenDichVu = tenDichVu,
                GiaDichVu = giaDichVu,
                DonViTinh = donViTinh,
                NgayTao = ngayTao,
                TrangThai = trangThai,
                GhiChu = ghiChu
            };

            BUSLoaiDV service = new BUSLoaiDV();
            string result = service.UpdateLoaiDichVu(ldv);

            if (!string.IsNullOrEmpty(result))
            {
                MessageBox.Show(result, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Cập nhật loại dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadLoaiDV();
            ClearFrom();
        }

        private void textTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string loaiDichVuID = txtLoaiDichVuID.Text.Trim();

            if (string.IsNullOrEmpty(loaiDichVuID))
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                BUSLoaiDV service = new BUSLoaiDV();
                string result = service.DeleteLoaiDichVu(loaiDichVuID);

                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show("Lỗi: " + result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Xóa loại dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadLoaiDV();
                ClearFrom();
            }
        }

    }

}
