using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLyKhachSan
{
    public class DTO_ThongKePhong
    {
        //public string PhongID { get; set; }
        //public string TenPhong { get; set; }
        //public string MaLoaiPhong { get; set; }
        //public int GiaPhong { get; set; }
        //public DateTime NgayBatDau { get; set; }
        //public DateTime NgayKetThuc { get; set; }
        //public bool TinhTrang { get; set; }
        //public string GhiChu { get; set; }
        public string MaLoaiPhong { get; set; }
        public string TenLoaiPhong { get; set; }
        public int SoLuongPhong { get; set; }
        public int SoLuongDat { get; set; }
        public decimal DoanhThu { get; set; }
    }
}
