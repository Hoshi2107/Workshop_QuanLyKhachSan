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

namespace GUI_QuanLyKhachSan
{
    public partial class TrangThaiDatphong : Form
    {

        public TrangThaiDatphong()
        {
            InitializeComponent();
        }
        private void TrangThaiDatPhong_Load(object sender, EventArgs e)
        {
           

        }

        private void LoadTrangThaiDatPhong()
        {
            BLLTrangThaiDatPhong bllTrangThai = new BLLTrangThaiDatPhong();




            dgvTrangThaiDatPhong.DataSource = bllTrangThai.GetAllTrangThai();

        }

        private void dgvTrangThaiDatPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTrangThaiDatPhong_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewRow row = dgvTrangThaiDatPhong.Rows[e.RowIndex];
            gntxtTrangThaiID.Text = row.Cells["TrangThaiID"].Value.ToString();
            gnCbo_HoaDonThueID.Text = row.Cells["HoaDonThueID"].Value.ToString();
            gnCbo_LoaiTrangThaiID.Text = row.Cells["LoaiTrangThaiID"].Value.ToString();
            gnDtpNgayCapNhat.Value = Convert.ToDateTime(row.Cells["NgayCapNhat"].Value);

        }

        private void TrangThaiDatphong_Load_1(object sender, EventArgs e)
        {
            LoadTrangThaiDatPhong();
            LoadCombobox();
        }
        private void LoadCombobox()
        {
            BUSLoaiTrangThaiDatPhong bllLoaiTrangThai = new BUSLoaiTrangThaiDatPhong();
            gnCbo_LoaiTrangThaiID.DataSource = bllLoaiTrangThai.GetLoaiTrangThaiDatPhongList();
            gnCbo_LoaiTrangThaiID.DisplayMember = "TenLoai";
            gnCbo_LoaiTrangThaiID.ValueMember = "LoaiTrangThaiID";
            BusDatPhong busDatPhong = new BusDatPhong();
            gnCbo_HoaDonThueID.DataSource = busDatPhong.GetDatPhongList();
            gnCbo_HoaDonThueID.DisplayMember = "HoaDonThueID";
            gnCbo_HoaDonThueID.ValueMember = "HoaDonThueID";
        }
    }
}
