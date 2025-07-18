using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLyKhachSan
{
    public class DALPhong
    {
        public List<Phong> SelectAll()
        {
            string sql = "SELECT * FROM Phong";
            return SelectBySql(sql, new List<object>());
        }
        public List<Phong> SelectBySql(string sql, List<object> args)
        {
            List<Phong> list = new List<Phong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    Phong entity = new Phong();
                    entity.MaPhong = reader["PhongID"].ToString();
                    entity.TenPhong = reader["TenPhong"].ToString();
                    entity.MaLoaiPhong = reader["MaLoaiPhong"].ToString();
                    entity.GiaPhong = reader["GiaPhong"] != DBNull.Value ? Convert.ToDecimal(reader["GiaPhong"]) : 0;
                    entity.NgayTao = reader["NgayTao"] != DBNull.Value ? Convert.ToDateTime(reader["NgayTao"]) : DateTime.MinValue;
                    entity.TinhTrang = reader["TinhTrang"] != DBNull.Value ? Convert.ToBoolean(reader["TinhTrang"]) : false;
                    entity.GhiChu = reader["GhiChu"] != DBNull.Value ? reader["GhiChu"].ToString() : "";

                    list.Add(entity);
                }
                reader.Close(); 
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn danh sách Phòng: " + ex.Message);
            }
            return list;
        }
        public List<Phong> selectAll()
        {
            string sql = "SELECT * FROM Phong";
            return SelectBySql(sql, new List<object>());
        }
        public void insertPhong(Phong phong)
        {
            try
            {
                string sql = @"INSERT INTO Phong (PhongID, TenPhong, MaLoaiPhong, GiaPhong, NgayTao, TinhTrang, GhiChu) 
                               VALUES (@0, @1, @2, @3, @4, @5, @6)";
                List<object> thamSo = new List<object>
                {
                    phong.MaPhong,
                    phong.TenPhong,
                    phong.MaLoaiPhong,
                    phong.GiaPhong,
                    phong.NgayTao,
                    phong.TinhTrang,
                    phong.GhiChu
                };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm Phòng: " + ex.Message);
            }
        }
        public void updatePhong(Phong phong)
        {
            try
            {
                string sql = @"UPDATE Phong 
                               SET TenPhong = @1, MaLoaiPhong = @2, GiaPhong = @3, NgayTao = @4, TinhTrang = @5, GhiChu = @6 
                               WHERE PhongID = @0";
                List<object> thamSo = new List<object>
                {
                    phong.MaPhong,
                    phong.TenPhong,
                    phong.MaLoaiPhong,
                    phong.GiaPhong,
                    phong.NgayTao,
                    phong.TinhTrang,
                    phong.GhiChu
                };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật Phòng: " + ex.Message);
            }
        }
        public void deletephong(Phong phong)
        {
            try
            {
                string sql = "DELETE FROM Phong WHERE PhongID = @0";
                List<object> thamSo = new List<object> { phong.MaPhong };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa Phòng: " + ex.Message);
            }
        }
        public string generateMaPhong()
        {
            string prefix = "P";
            string sql = "SELECT MAX(PhongID) FROM Phong";
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
        public List<Phong> searchByKeyword(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            var dsPhong = selectAll();

            return dsPhong.Where(P =>
                (!string.IsNullOrEmpty(P.MaPhong) && P.MaPhong.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(P.TenPhong) && P.TenPhong.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(P.MaLoaiPhong) && P.MaLoaiPhong.ToLower().Contains(keyword))
            ).ToList();
        }

    }
}
