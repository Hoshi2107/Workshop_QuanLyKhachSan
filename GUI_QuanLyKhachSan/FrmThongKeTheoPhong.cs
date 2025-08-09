using BLL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
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
    public partial class FrmThongKeTheoPhong : Form
    {
        private BLL_ThongKePhong bllThongKePhong = new BLL_ThongKePhong();
        private BUSLoaiPhong busLoaiPhong = new BUSLoaiPhong();
        public FrmThongKeTheoPhong()
        {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gnBtn_ThongKe_Click(object sender, EventArgs e)
        {
            //if (cbo_MaPhong.DataSource == null)
            //{
            //    MessageBox.Show("Vui lòng chọn phòng cần thống kê");
            //    return;
            //}
            //string phongID = cbo_MaPhong.SelectedValue?.ToString();
            //DateTime fromDate = gnDtp_NgayBD.Value;
            //DateTime toDate = gnDtp_NgayKT.Value;
            //var thongKeList = bllThongKePhong.LayThongKeTheoLoaiPhong(fromDate, toDate);
            //if (thongKeList == null || thongKeList.Count == 0)
            //{
            //    MessageBox.Show("Không có dữ liệu thống kê cho phòng này trong khoảng thời gian đã chọn.");
            //    return;
            //}
            //dgvThongKe_phong.DataSource = thongKeList;
            if (cbo_MaPhong.DataSource == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần thống kê");
                return;
            }

            string maLoaiPhong = cbo_MaPhong.SelectedValue?.ToString();
            DateTime fromDate = gnDtp_NgayBD.Value;
            DateTime toDate = gnDtp_NgayKT.Value;

            var thongKeList = bllThongKePhong.LayThongKeTheoLoaiPhong(fromDate, toDate, maLoaiPhong);

            if (thongKeList == null || thongKeList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu thống kê cho loại phòng này trong khoảng thời gian đã chọn.");
                return;
            }

            dgvThongKe_phong.DataSource = thongKeList;
        }
        private void loadComboBoxPhong()
        {
            //var phongList = busPhong.GetPhongList();
            //cbo_MaPhong.DataSource = phongList;
            //cbo_MaPhong.DisplayMember = "TenPhong";
            //cbo_MaPhong.ValueMember = "MaPhong";
            //cbo_MaPhong.SelectedIndex = -1;
            var loaiPhongList = busLoaiPhong.GetLoaiPhong();
            cbo_MaPhong.DataSource = loaiPhongList;
            cbo_MaPhong.DisplayMember = "TenLoaiPhong";
            cbo_MaPhong.ValueMember = "MaLoaiPhong";
            cbo_MaPhong.SelectedIndex = -1;
        }
        private void FrmThongKeTheoPhong_Load(object sender, EventArgs e)
        {
            loadComboBoxPhong();
        }

    }
}
