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
        public List<DichVu> GetDichVuList()
        {
            return dALDichVu.SelectAll();
        }
        public string AddDichVu(DichVu dichvu)
        {
            try
            {
                dichvu.DichVuID = dALDichVu.GenerateNewDichVuID(); 

                if (string.IsNullOrEmpty(dichvu.DichVuID))
                {
                    return "Mã Loại không hợp lệ!";
                }

                dALDichVu.Add(dichvu); 
                return "Thêm loại dịch vụ thành công!";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm loại dịch vụ: " + ex.Message);
                return "Có lỗi xảy ra! Vui lòng kiểm tra lại.";
            }
        }
        public string UpdateDichVu(DichVu dichvu)
        {
            try
            {
                if (string.IsNullOrEmpty(dichvu.DichVuID)) 
                {
                    return "Mã loại dịch vụ không hợp lệ!";
                }

                dALDichVu.Update(dichvu); 
                return "Cập nhật loại dịch vụ thành công!";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật loại dịch vụ: " + ex.Message);
                return "Có lỗi xảy ra! Vui lòng kiểm tra lại.";
            }
        }
        public string DeleteDichVu(string DichVuID)
        {
            try
            {
                if (string.IsNullOrEmpty(DichVuID))
                {
                    return "Mã loại dịch vụ không hợp lệ.";
                }

                dALDichVu.Delete(DichVuID);
                return "Xóa loại dịch vụ thành công!";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa loại dịch vụ: " + ex.Message);
                return "Có lỗi xảy ra! Vui lòng kiểm tra lại.";
            }
        }
    }
}
