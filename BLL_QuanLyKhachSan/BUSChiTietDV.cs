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
        public List<ChiTietDichVu> GetchitietDichVuList()
        {
            return dALchitietDichVu.SelectAll();
        }
        public string UpdateKhachHang(ChiTietDichVu CT)
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
        public string insertCT(ChiTietDichVu CT)
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
        public string deleteCT(ChiTietDichVu CT)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CT.ChiTietDichVuID))
                {
                    return string.Empty;
                }
                dALchitietDichVu.delete(CT);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }


    }
}
