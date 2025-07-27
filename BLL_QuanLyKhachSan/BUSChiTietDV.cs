using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_QuanLyKhachSan
{
    public class BUSChiTietDV
    {
        DALChiTietDv dALchitietDichVu = new DALChiTietDv();
        public List<DTO_ChiTietDichVu> GetchitietDichVuList()
        {
            return dALchitietDichVu.SelectAll();
        }
        public string UpdateCT(DTO_ChiTietDichVu CT)
        {
            try
            {
                if (string.IsNullOrEmpty(CT.HoaDonThueID))
                {
                    return "Mã hóa đơn thuê không được để trống.";
                }

                dALchitietDichVu.update(CT);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string insertCT(DTO_ChiTietDichVu CT)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CT.ChiTietDichVuID))
                {
                    CT.ChiTietDichVuID = dALchitietDichVu.generateChiTietDichVu();
                }
                if (string.IsNullOrEmpty(CT.HoaDonThueID) || string.IsNullOrEmpty(CT.LoaiDichVuID))
                {
                    return "Mã hóa đơn thuê và loại dịch vụ không được để trống.";
                }
                dALchitietDichVu.Insert(CT);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string deleteCT(string CTDV)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CTDV))
                {
                    return string.Empty;
                }
                dALchitietDichVu.delete(CTDV);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public List<DTO_ChiTietDichVu> TimKiem(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                {
                    return dALchitietDichVu.SelectAll();
                }
                keyword = keyword.Trim().ToLower();
                return dALchitietDichVu.searchByKeyword(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm nhân viên: " + ex.Message);
            }
        }


    }
}
