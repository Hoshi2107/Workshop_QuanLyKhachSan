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
        public List<DTO_DatPhong> GetDatPhongList()
        {
            return dalDatPhong.SelectAll();
        }
        public string insertDatPhong(DTO_DatPhong dp)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dp.HoaDonThueID))
                {
                    dp.HoaDonThueID = dalDatPhong.generateDatPhongID();
                }
                if (string.IsNullOrEmpty(dp.KhachHangID) || string.IsNullOrEmpty(dp.MaPhong) || string.IsNullOrEmpty(dp.MaNV))
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
        public List<DTO_DatPhong> TimKiem(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    return dalDatPhong.SelectAll();
                }
                keyword = keyword.Trim().ToLower();
                return dalDatPhong.searchByKeyword(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
            }
        }
        public string updateDatPhong(DTO_DatPhong dp)
        {
            try
            {
                if (string.IsNullOrEmpty(dp.HoaDonThueID))
                {
                    return "Mã hóa đơn thuê không hợp lệ!";
                }

                dalDatPhong.updateDatPhong(dp);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string deleteDatPhong(string HoaDonThueID)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(HoaDonThueID))
                {
                    return "Chưa chọn dòng để xóa";
                }
                dalDatPhong.deleteDatPhong(HoaDonThueID);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
    }
}
