using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QuanLyKhachSan
{
    public class BLL_ThongKePhong
    {
        DAL_ThongKePhong dalThongKePhong = new DAL_ThongKePhong();
        public List<DTO_ThongKePhong> LayThongKePhong(string phongID, DateTime ngayBatDau, DateTime ngayKetThuc)
        {
            return dalThongKePhong.LayThongKePhong(phongID, ngayBatDau, ngayKetThuc);
        }
    }
}
