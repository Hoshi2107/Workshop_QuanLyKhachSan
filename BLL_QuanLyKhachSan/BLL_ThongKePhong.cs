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
        //public List<DTO_ThongKePhong> LayThongKePhong(DateTime ngayBatDau, DateTime ngayKetThuc)
        //{
        //    return dalThongKePhong.LayThongKePhong(ngayBatDau, ngayKetThuc);
        //}
        //public List<DTO_ThongKePhong> LayThongKeTheoLoaiPhong(DateTime ngayBD, DateTime ngayKT)
        //{
        //    return dalThongKePhong.LayThongKeTheoLoaiPhong(ngayBD, ngayKT);
        //}
        public List<DTO_ThongKePhong> LayThongKeTheoLoaiPhong(DateTime ngayBD, DateTime ngayKT, string maLoaiPhong)
        {
            return dalThongKePhong.LayThongKeTheoLoaiPhong(ngayBD, ngayKT, maLoaiPhong);
        }

    }
}
