using BLL_QuanLyKhachSan;
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
    public partial class ChiTietDichVu : Form
    {
        public ChiTietDichVu()
        {
            InitializeComponent();
        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChiTietDichVu_Load(object sender, EventArgs e)
        {
            LoadchitetdichVu();
            loadCombobox();
        }
        private void loadCombobox()
        {
            BusDatPhong busDatPhong = new BusDatPhong();
            cbx_HoaDonThue.DataSource = busDatPhong.GetDatPhongList();
            cbx_HoaDonThue.DisplayMember = "HoaDonThueID";
            cbx_HoaDonThue.ValueMember = "HoaDonThueID";
            BUSDichVu bUSDichVu = new BUSDichVu();
            cbxDichVuID.DataSource = bUSDichVu.GetDichVuList();
            cbxDichVuID.DisplayMember = "TenDichVu";
            cbxDichVuID.ValueMember = "DichVuID";
            BUSLoaiDV bUSLoaiDichVu = new BUSLoaiDV();
            cbx_LoaiDichVu.DataSource = bUSLoaiDichVu.GetLoaiDVList();
            cbx_LoaiDichVu.DisplayMember = "TenLoaiDichVu";
            cbx_LoaiDichVu.ValueMember = "LoaiDichVuID";

        }
        private void LoadchitetdichVu()
        {
            BUSChiTietDV bUSchitietDichVu = new BUSChiTietDV();
            guna2DataGridView1.DataSource = bUSchitietDichVu.GetchitietDichVuList();
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbx_HoaDonThue_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}