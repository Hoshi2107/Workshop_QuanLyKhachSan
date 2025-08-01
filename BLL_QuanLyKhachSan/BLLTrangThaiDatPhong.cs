using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;


namespace BLL_QuanLyKhachSan
{
    public class BLLTrangThaiDatPhong
    {
        DALTrangThaiDatPhong dalTrangThaiDatPhong = new DALTrangThaiDatPhong();
        public List<DTO_TrangThaiDatPhong> GetAllTrangThai()
        {
            return dalTrangThaiDatPhong.SelectAll();
        }
        public string insertTrangThai(DTO_TrangThaiDatPhong trangThai)
        {
            //try
            //{
            //    if (string.IsNullOrWhiteSpace(trangThai.TrangThaiID))
            //    {
            //        trangThai.TrangThaiID = dalTrangThaiDatPhong.GenerateNewTrangThaiDatPhong();
            //    }
            //    if (string.IsNullOrEmpty(trangThai.LoaiTrangThaiID) || string.IsNullOrEmpty(trangThai.HoaDonThueID))
            //    {
            //        return "Mã hóa đơn thuê và loại trạng thái không được để trống.";
            //    }
            //    dalTrangThaiDatPhong.insertTrangThaiDatPhong(trangThai);
            //    return string.Empty;
            //}
            //catch (Exception ex)
            //{
            //    return "Lỗi: " + ex.Message;
            //}
            try
            {
                if (string.IsNullOrWhiteSpace(trangThai.TrangThaiID))
                {
                    trangThai.TrangThaiID = dalTrangThaiDatPhong.GenerateNewTrangThaiDatPhong();
                }
                if (string.IsNullOrEmpty(trangThai.HoaDonThueID))
                {
                    return "Họ tên không được để trống.";
                }
                dalTrangThaiDatPhong.insertTrangThaiDatPhong(trangThai);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string updateTrangThai(DTO_TrangThaiDatPhong trangThai)
        {
            try
            {
                if (string.IsNullOrEmpty(trangThai.TrangThaiID))
                {
                    return "Mã trạng thái không được để trống.";
                }
                dalTrangThaiDatPhong.updateTrangThaiDatPhong(trangThai);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string deleteTrangThai(string trangThaiID)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(trangThaiID))
                {
                    return "Chưa chọn trạng thái để xóa.";
                }
                dalTrangThaiDatPhong.deleteTrangThaiDatPhong(trangThaiID);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public List<DTO_TrangThaiDatPhong> TimKiem(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    return dalTrangThaiDatPhong.SelectAll();
                }
                keyword = keyword.Trim().ToLower();
                return dalTrangThaiDatPhong.searchByKeyword(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm trạng thái đặt phòng: " + ex.Message);
            }
        }
    }
}
