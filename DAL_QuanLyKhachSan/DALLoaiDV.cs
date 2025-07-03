using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DTO_QuanLyKhachSan;
namespace DAL_QuanLyKhachSan
{
    public class DALLoaiDV
    {
        public List<DTO_LoaiDichVu> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<DTO_LoaiDichVu> list = new List<DTO_LoaiDichVu>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    DTO_LoaiDichVu entity = new DTO_LoaiDichVu();
                    entity.LoaiDichVuID = reader.GetString("LoaiDichVuID");
                    entity.TenDichVu = reader.GetString("TenDichVu");
                    entity.GiaDichVu = reader.GetDecimal("GiaDichVu");
                    entity.DonViTinh = reader.GetString("DonViTinh");
                    entity.NgayTao = reader.GetDateTime("NgayTao");
                    entity.TrangThai = reader.GetBoolean("TrangThai");
                    entity.GhiChu = reader.GetString("GhiChu");
                    list.Add(entity);
                }
               
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public List<DTO_LoaiDichVu> selectAll()
        {
            String sql = "SELECT * FROM LoaiDichVu";
            return SelectBySql(sql, new List<object>());
        }
        public string genereteMaLoaiDV()
        {
            string prefix = "DV";
            string sql = "SELECT MAX(LoaiDichVuID) FROM LoaiDichVu";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(3);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }
        public void addLoaiDichVu(DTO_LoaiDichVu ldv)
        {
            try
            {
                string sql = @"INSERT INTO LoaiDichVu(LoaiDichVuID, TenDichVu, GiaDichVu, DonViTinh, NgayTao, TrangThai, GhiChu) 
                       VALUES(@0, @1, @2, @3, @4, @5, @6)";

                List<object> thamso = new List<object>
        {
            ldv.LoaiDichVuID,
            ldv.TenDichVu,
            ldv.GiaDichVu,
            ldv.DonViTinh,
            ldv.NgayTao,
            ldv.TrangThai,
            ldv.GhiChu
        };

                DBUtil.Update(sql, thamso);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm loại dịch vụ: " + ex.Message);
            }
        }

        public void updateLoaiDichVu(DTO_LoaiDichVu ldv)
        {
            try
            {
                string sql = @"UPDATE LoaiDichVu 
                       SET TenDichVu = @1, GiaDichVu = @2, DonViTinh = @3, NgayTao = @4, TrangThai = @5, GhiChu = @6 
                       WHERE LoaiDichVuID = @0";

                List<object> thamso = new List<object>
        {
            ldv.LoaiDichVuID,
            ldv.TenDichVu,
            ldv.GiaDichVu,
            ldv.DonViTinh,
            ldv.NgayTao,
            ldv.TrangThai,
            ldv.GhiChu
        };

                DBUtil.Update(sql, thamso);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật loại dịch vụ: " + ex.Message);
            }
        }
        public void deleteLoaiDichVu(DTO_LoaiDichVu loaiDichVuID)
        {
            try
            {
                string sql = @"DELETE FROM LoaiDichVu WHERE LoaiDichVuID = @0";
                List<object> thamso = new List<object> { loaiDichVuID };

                DBUtil.Update(sql, thamso);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa loại dịch vụ: " + ex.Message);
            }
        }
    }
}
