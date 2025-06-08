using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyKhachSan
{
    public class DTO_NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public bool VaiTro { get; set; }
        public bool TinhTrang { get; set; }

        public string MatKhau { get; set; }
        public string VaiTroText => VaiTro ? "Quản lý" : "Nhân viên";
        public string TinhTrangText => TinhTrang ? "Đang hoạt động" : "Không hoạt động";
    }
}
