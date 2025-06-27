using BLL_QuanLyKhachSan;
using DAL_QuanLyKhachSan;
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
    public partial class LoaiTrangThaiDatphong : Form
    {
        public LoaiTrangThaiDatphong()
        {
            InitializeComponent();
        }

        private void LoadLoaiTrangThaiDatPhong()
        {

        }
        private void LoaiTrangThaiDatphong_Load(object sender, EventArgs e)
        {

        }

        private void LoaiTrangThaiDatphong_Load_1(object sender, EventArgs e)
        {
            loadtrangthaidatphong();
        }
        private void loadtrangthaidatphong()
        {
            BUSLoaiTrangThaiDatPhong busLoaiTrangThaiDatPhong = new BUSLoaiTrangThaiDatPhong();
            dgvloaitrangthaiphong.DataSource = busLoaiTrangThaiDatPhong.GetLoaiTrangThaiDatPhongList();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = guna2DataGridView1.Rows[e.RowIndex];
            gntxtMaLoaiPhong.Text = row.Cells["LoaiTrangThaiID"].Value.ToString();
            gntxtTenLoaiPhong.Text = row.Cells["TenTrangThai"].Value.ToString();
        }
    }
}
