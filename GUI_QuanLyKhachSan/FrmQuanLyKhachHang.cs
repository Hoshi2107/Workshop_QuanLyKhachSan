using DAL_QuanLyKhachSan;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLyKhachSan
{
    public partial class FrmQuanLyKhachHang : Form
    {
        public FrmQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void gnDgv_KhachHang_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = gnDgv_KhachHang.Rows[e.RowIndex];
            gnTxt_KhachHangID.Text = row.Cells["MaKhachHang"].Value.ToString();
            gnTxt_HoTen.Text = row.Cells["HoTen"].Value.ToString();
            gnTxt_DiaChi.Text = row.Cells["DiaChi"].Value.ToString();
            gnTxt_GioiTinh.Text = row.Cells["GioiTinh"].Value.ToString();
            gnTxt_SDT.Text = row.Cells["SoDienThoai"].Value.ToString();
            gnDtp_NgayTao.Value = Convert.ToDateTime(row.Cells["NgayTao"].Value);
            bool trangThai = Convert.ToBoolean(row.Cells["TrangThai"].Value);
            if (trangThai)
            {
                gnrdo_True.Checked = true;
            }
            else
            {
                gnrdo_False.Checked = true;
            }
            gnTxt_GhiChu.Text = row.Cells["GhiChu"].Value.ToString();
            



        }

        //private void FrmQuanLyKhachHang_Load(object sender, EventArgs e)
        //{
        //    LoadDanhSachKhachHang();
        //}
        private void LoadDanhSachKhachHang()
        {
            BLL_QuanLyKhachSan.BusKhachHang busKhachHang = new BLL_QuanLyKhachSan.BusKhachHang();
            gnDgv_KhachHang.DataSource = busKhachHang.GetKhachHangList();
        }

        private void FrmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachKhachHang();
        }
    }
}
