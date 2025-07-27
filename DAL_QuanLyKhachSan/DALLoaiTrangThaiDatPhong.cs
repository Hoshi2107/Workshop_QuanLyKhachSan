using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;

namespace DAL_QuanLyKhachSan
{
    public class DALLoaiTrangThaiDatPhong
    {
        public List<DTO_LoaiTrangThaiDatPhong> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<DTO_LoaiTrangThaiDatPhong> list = new List<DTO_LoaiTrangThaiDatPhong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    DTO_LoaiTrangThaiDatPhong entity = new DTO_LoaiTrangThaiDatPhong();
                    entity.LoaiTrangThaiID = reader.GetString("LoaiTrangThaiID");
                    entity.TenTrangThai = reader.GetString("TenTrangThai");
                    list.Add(entity);
                }

            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }
        public List<DTO_LoaiTrangThaiDatPhong> selectAll()
        {
            String sql = "SELECT * FROM LoaiTrangThaiDatPhong";
            return SelectBySql(sql, new List<object>());
        }
        public void insertLoaiTrangThaiDatPhong(DTO_LoaiTrangThaiDatPhong loaiTrangThai)
        {
            try
            {
                string sql = @"INSERT INTO LoaiTrangThaiDatPhong (LoaiTrangThaiID, TenTrangThai) 
                               VALUES (@0, @1)";
                List<object> thamSo = new List<object>
                {
                    loaiTrangThai.LoaiTrangThaiID,
                    loaiTrangThai.TenTrangThai
                };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm loại trạng thái đặt phòng: " + ex.Message);
            }
        }
        public void updateLoaiTrangThaiDatPhong(DTO_LoaiTrangThaiDatPhong loaiTrangThai)
        {
            try
            {
                string sql = @"UPDATE LoaiTrangThaiDatPhong 
                               SET TenTrangThai = @1 
                               WHERE LoaiTrangThaiID = @0";
                List<object> thamSo = new List<object>
                {
                    loaiTrangThai.LoaiTrangThaiID,
                    loaiTrangThai.TenTrangThai
                };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật loại trạng thái đặt phòng: " + ex.Message);
            }
        }
        public void deleteLoaiTrangThaiDatPhong(DTO_LoaiTrangThaiDatPhong loaiTrangThai)
        {
            try
            {
                string sql = @"DELETE FROM LoaiTrangThaiDatPhong 
                               WHERE LoaiTrangThaiID = @0";
                List<object> thamSo = new List<object>
                {
                    loaiTrangThai.LoaiTrangThaiID
                };
                DBUtil.Query(sql, thamSo);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa loại trạng thái đặt phòng: " + ex.Message);
            }
        }
        public string generateLoaiTrangThai()
        {
            string prefix = "TT";
            string sql = "SELECT MAX(LoaiTrangThaiID) FROM LoaiTrangThaiDatPhong";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(2);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }
        public List<DTO_LoaiTrangThaiDatPhong> searchByKeyword(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            var dsloaitrangthai = selectAll();

            return dsloaitrangthai.Where(TT =>
                (!string.IsNullOrEmpty(TT.LoaiTrangThaiID) && TT.LoaiTrangThaiID.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(TT.TenTrangThai) && TT.TenTrangThai.ToLower().Contains(keyword)) 
            ).ToList();
        }


    }
}
