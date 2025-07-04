using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QuanLyKhachSan
{

    public class BusDatPhong
    {
        DALDatPhong dalDatPhong = new DALDatPhong();
        public List<DatPhong> GetDatPhongList()
        {
            return dalDatPhong.SelectAll();
        }
        public string insertDatPhong(DatPhong dp)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dp.HoaDonThueID))
                {
                    dp.HoaDonThueID = dalDatPhong.generateDatPhongID();
                }
                if (string.IsNullOrEmpty(dp.MaKhachHang) || string.IsNullOrEmpty(dp.MaPhong) || string.IsNullOrEmpty(dp.MaNV))
                {
                    return "Vui lòng nhập đầy đủ thông tin bắt buộc (Khách hàng, Phòng, Nhân viên)!";
                }
                dalDatPhong.insertDatPhong(dp);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi khi thêm đặt phòng: " + ex.Message;
            }
        }

    }
}
