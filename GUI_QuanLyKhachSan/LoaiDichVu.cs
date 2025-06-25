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
            //btnThem.Enabled = true;
            //btnSưa.Enabled = false;
            //btnXóa.Enabled = true;
            //textLoaiDichVuID.Clear();
            //textghichu.Clear();
            //TextGiaDV.Clear();
            //textTimKiem.Clear();
            //textTenDV.Clear();
            //textdonvitinh.Clear();
            //guna2DateTimePicker1.Value = DateTime.Now;
            //textLoaiDichVuID.Enabled = false;
        }
        private void loadLoaiDV()
        {
            BUSLoaiDV service = new BUSLoaiDV();
            dgrLoaiDV.DataSource = service.GetLoaiDVList();
        }


        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dgrLoaiDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string loaiDichVuID = textLoaiDichVuID.Text.Trim();
            string tenDichVu = textTenDV.Text.Trim();
            string giaDichVutext = TextGiaDV.Text.Trim();
            string donViTinh = textdonvitinh.Text.Trim();
            DateTime ngayTao = dtpNgayTao.Value;
            bool trangThai = RdoConHoatDong.Checked;
            if (string.IsNullOrEmpty(tenDichVu) || string.IsNullOrEmpty(giaDichVutext) || string.IsNullOrEmpty(donViTinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ghiChu = textghichu.Text.Trim();
            if (!decimal.TryParse(giaDichVutext, out decimal giaDichVu))
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
            string result = service.AddLoaiDichVu(ldv);

            if (result == "Vui lòng nhập đủ thông tin hợp lệ!")
            {
                MessageBox.Show(result);
                return;
            }

            if (string.IsNullOrEmpty(result) || result == "")
            {
                MessageBox.Show("Thêm mới loại dịch vụ thành công");
                loadLoaiDV();
                ClearFrom();
            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            loadLoaiDV();
            ClearFrom();
        }



        private void dgrLoaiDV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgrLoaiDV.Rows[e.RowIndex];

            textLoaiDichVuID.Text = row.Cells["LoaiDichVuID"].Value.ToString();
            textTenDV.Text = row.Cells["TenDichVu"].Value.ToString();
            TextGiaDV.Text = row.Cells["GiaDichVu"].Value.ToString();
            textdonvitinh.Text = row.Cells["DonViTinh"].Value.ToString();
            dtpNgayTao.Text = row.Cells["NgayTao"].Value.ToString();
            textghichu.Text = row.Cells["GhiChu"].Value.ToString();
            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai)
            {
                RdoConHoatDong.Checked = true;
            }
            else
            {
                RdoKhongHoatDong.Checked = true;
            }


        }

        private void btnSưa_Click(object sender, EventArgs e)
        {
            string loaiDichVuID = textLoaiDichVuID.Text.Trim();
            string tenDichVu = textTenDV.Text.Trim();
            string giaDichVutext = TextGiaDV.Text.Trim();
            string donViTinh = textdonvitinh.Text.Trim();
            DateTime ngayTao = dtpNgayTao.Value;
            bool trangThai = RdoConHoatDong.Checked;

            if (string.IsNullOrEmpty(loaiDichVuID) || string.IsNullOrEmpty(tenDichVu) || string.IsNullOrEmpty(giaDichVutext) || string.IsNullOrEmpty(donViTinh))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ghiChu = textghichu.Text.Trim();

            if (!decimal.TryParse(giaDichVutext, out decimal giaDichVu))
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
            string result = service.UpdateLoaiDichVu(ldv); // Thay đổi phương thức từ AddLoaiDichVu thành UpdateLoaiDichVu

            if (result == "Vui lòng nhập đủ thông tin hợp lệ!")
            {
                MessageBox.Show(result);
                return;
            }

            if (string.IsNullOrEmpty(result) || result == "")
            {
                MessageBox.Show("Cập nhật loại dịch vụ thành công");
                loadLoaiDV();
                ClearFrom();
            }

        }

        private void textTimKiem_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
