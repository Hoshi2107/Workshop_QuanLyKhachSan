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
    public class DALTrangThaiDatPhong
    {
        public List<DTO_TrangThaiDatPhong> SelectBySql(string sql, List<object> args)
        {
            List<DTO_TrangThaiDatPhong> list = new List<DTO_TrangThaiDatPhong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    DTO_TrangThaiDatPhong entity = new DTO_TrangThaiDatPhong();

                    entity.TrangThaiID = reader.GetString("TrangThaiID");
                    entity.HoaDonThueID = reader.GetString("HoaDonThueID");
                    entity.LoaiTrangThaiID = reader.GetString("LoaiTrangThaiID");
                    entity.NgayCapNhat = reader.GetDateTime("NgayCapNhat");

                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }

        public List<DTO_TrangThaiDatPhong> SelectAll()
        {
            string sql = "SELECT * FROM TrangThaiDatPhong";
            return SelectBySql(sql, new List<object>());
        }
        public void insertTrangThaiDatPhong(DTO_TrangThaiDatPhong trangThai)
        {
            try
            {
                string sql = @"INSERT INTO TrangThaiDatPhong (TrangThaiID, HoaDonThueID, LoaiTrangThaiID, NgayCapNhat) 
                               VALUES (@0, @1, @2, @3)";
                List<object> thamSo = new List<object>
                {
                    trangThai.TrangThaiID,
                    trangThai.HoaDonThueID,
                    trangThai.LoaiTrangThaiID,
                    trangThai.NgayCapNhat
                };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm trạng thái đặt phòng: " + ex.Message);
            }
        }
        public void updateTrangThaiDatPhong(DTO_TrangThaiDatPhong trangThai)
        {
            try
            {
                string sql = @"UPDATE TrangThaiDatPhong 
                               SET HoaDonThueID = @1, LoaiTrangThaiID = @2, NgayCapNhat = @3 
                               WHERE TrangThaiID = @0";
                List<object> thamSo = new List<object>
                {
                    trangThai.TrangThaiID,
                    trangThai.HoaDonThueID,
                    trangThai.LoaiTrangThaiID,
                    trangThai.NgayCapNhat
                };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật trạng thái đặt phòng: " + ex.Message);
            }
        }
        public void deleteTrangThaiDatPhong(string trangThaiID)
        {
            try
            {
                string sql = "DELETE FROM TrangThaiDatPhong WHERE TrangThaiID = @0";
                List<object> args = new List<object> { trangThaiID };
                DBUtil.Update(sql, args);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa trạng thái đặt phòng: " + ex.Message);
            }
        }
        public List<DTO_TrangThaiDatPhong> searchByKeyword(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            var dp = SelectAll();

            return dp.Where(KH =>
                (!string.IsNullOrEmpty(KH.TrangThaiID) && KH.TrangThaiID.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(KH.HoaDonThueID) && KH.HoaDonThueID.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(KH.LoaiTrangThaiID) && KH.LoaiTrangThaiID.ToLower().Contains(keyword))
            ).ToList();
        }
        public string GenerateNewTrangThaiDatPhong()
        {
            string prefix = "TTDP";
            string sql = "SELECT MAX(TrangThaiID) FROM TrangThaiDatPhong";
            object result = DBUtil.ScalarQuery(sql, new List<object>());

            if (result != null && result != DBNull.Value)
            {
                string currentMaxID = result.ToString();

                if (currentMaxID.StartsWith(prefix))
                {
                    string numberPart = currentMaxID.Substring(prefix.Length); 
                    if (int.TryParse(numberPart, out int number))
                    {
                        int newNumber = number + 1;
                        return $"{prefix}{newNumber:D3}";
                    }
                }
            }

            return $"{prefix}001";
        }


    }
}