using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;

namespace BLL_QuanLyKhachSan
{
    public class BUSLoaiTrangThaiDatPhong
    {
        DALLoaiTrangThaiDatPhong dalloaiTrangThaiDatPhong = new DALLoaiTrangThaiDatPhong();
        public List<LoaiTrangThaiDatPhong> GetLoaiTrangThaiDatPhongList()
        {
            return dalloaiTrangThaiDatPhong.selectAll();
        }
        public string insertLoaiTrangThaiDatPhong(LoaiTrangThaiDatPhong loaiTrangThai)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loaiTrangThai.LoaiTrangThaiID))
                {
                    loaiTrangThai.LoaiTrangThaiID = dalloaiTrangThaiDatPhong.generateLoaiTrangThai();
                }
                if (string.IsNullOrWhiteSpace(loaiTrangThai.TenTrangThai))
                {
                    return "Tên trạng thái không được để trống.";
                }
                dalloaiTrangThaiDatPhong.insertLoaiTrangThaiDatPhong(loaiTrangThai);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string updateLoaiTrangThaiDatPhong(LoaiTrangThaiDatPhong loaiTrangThai)
        {
            try
            {
                if (string.IsNullOrEmpty(loaiTrangThai.TenTrangThai))
                {
                    return "Tên trạng thái không được để trống.";
                }
                dalloaiTrangThaiDatPhong.updateLoaiTrangThaiDatPhong(loaiTrangThai);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string deleteLoaiTrangThaiDatPhong(LoaiTrangThaiDatPhong loaiTrangThai)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(loaiTrangThai.LoaiTrangThaiID))
                {
                    return "Mã loại trạng thái không hợp lệ ! ! !";
                }
                dalloaiTrangThaiDatPhong.deleteLoaiTrangThaiDatPhong(loaiTrangThai);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public List<LoaiTrangThaiDatPhong> SearchLoaiTrangThaiDatPhong(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    return dalloaiTrangThaiDatPhong.selectAll();
                }
                keyword = keyword.Trim().ToLower();
                return dalloaiTrangThaiDatPhong.searchByKeyword(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
            }

        }
    }
}
