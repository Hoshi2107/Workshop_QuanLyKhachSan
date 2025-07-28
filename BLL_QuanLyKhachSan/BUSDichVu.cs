using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
namespace BLL_QuanLyKhachSan
{
    public class BUSDichVu
    {
        DALDichVu dALDichVu = new DALDichVu();
        public List<DTO_DichVU> GetDichVuList()
        {
            return dALDichVu.SelectAll();
        }
        public string AddDichVu(DTO_DichVU dichvu)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dichvu.DichVuID))
                {
                    dichvu.DichVuID = dALDichVu.GenerateNewDichVuID();
                }
                if (string.IsNullOrEmpty(dichvu.HoaDonThueID))
                {
                    return "Hóa đơn thuê không được để trống.";
                }
                dALDichVu.Add(dichvu);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }

        public string UpdateDichVu(DTO_DichVU dichvu)
        {
            try
            {
                if (string.IsNullOrEmpty(dichvu.DichVuID))
                {
                    return "Mã nhân viên không hợp lệ ! ! !";
                }

                dALDichVu.Update(dichvu);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
        public string DeleteDichVu(string DichVuID)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(DichVuID))
                {
                    return "Chưa chọn dòng để xóa";
                }
                dALDichVu.Delete(DichVuID);
                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Lỗi: " + ex.Message;
            }
        }
    }
}
