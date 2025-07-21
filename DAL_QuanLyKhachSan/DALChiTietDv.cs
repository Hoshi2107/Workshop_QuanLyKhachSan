using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLyKhachSan
{
    public class DALChiTietDv
    {
        public List<ChiTietDichVu> SelectBySql(string sql, List<object> args)
        {
            List<ChiTietDichVu> list = new List<ChiTietDichVu>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    ChiTietDichVu entity = new ChiTietDichVu();
                    entity.ChiTietDichVuID = reader.GetString("ChiTietDichVuID");
                    entity.HoaDonThueID = reader.GetString("HoaDonThueID");
                    entity.DichVuID = reader.GetString("DichVuID");
                    entity.LoaiDichVuID = reader.GetString("LoaiDichVuID");
                    entity.SoLuong = reader.GetInt32("SoLuong");
                    entity.NgayBatDau = reader.GetDateTime("NgayBatDau");
                    entity.NgayKetThuc = reader.GetDateTime("NgayKetThuc");
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

        public List<ChiTietDichVu> SelectAll()
        {
            string sql = "SELECT * FROM ChiTietDichVu";
            return SelectBySql(sql, new List<object>());
        }
        public void Insert(ChiTietDichVu entity)
        {
            string sql = "INSERT INTO ChiTietDichVu (ChiTietDichVuID, HoaDonThueID, DichVuID, LoaiDichVuID, SoLuong, NgayBatDau, NgayKetThuc, GhiChu) " +
                         "VALUES (@ChiTietDichVuID, @HoaDonThueID, @DichVuID, @LoaiDichVuID, @SoLuong, @NgayBatDau, @NgayKetThuc, @GhiChu)";
            List<object> args = new List<object>
            {
                entity.ChiTietDichVuID,
                entity.HoaDonThueID,
                entity.DichVuID,
                entity.LoaiDichVuID,
                entity.SoLuong,
                entity.NgayBatDau,
                entity.NgayKetThuc,
                entity.GhiChu
            };
            DBUtil.Update(sql, args);
        }
        public void delete(ChiTietDichVu CT)
        {
            string sql = "DELETE FROM ChiTietDichVu WHERE ChiTietDichVuID = @ChiTietDichVuID";
            List<object> args = new List<object> { CT.ChiTietDichVuID };
            DBUtil.Update(sql, args);
        }
        public void update(ChiTietDichVu entity)
        {
            string sql = "UPDATE ChiTietDichVu SET HoaDonThueID = @HoaDonThueID, DichVuID = @DichVuID, LoaiDichVuID = @LoaiDichVuID, " +
                         "SoLuong = @SoLuong, NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc, GhiChu = @GhiChu " +
                         "WHERE ChiTietDichVuID = @ChiTietDichVuID";
            List<object> args = new List<object>
            {
                entity.HoaDonThueID,
                entity.DichVuID,
                entity.LoaiDichVuID,
                entity.SoLuong,
                entity.NgayBatDau,
                entity.NgayKetThuc,
                entity.GhiChu,
                entity.ChiTietDichVuID
            };
            DBUtil.Update(sql, args);
        }
        public string generateChiTietDichVu()
        {
            string prefix = "CTDV";
            string sql = "SELECT MAX(ChiTietDichVuID) FROM ChiTietDichVu";
            List<object> thamSo = new List<object>();
            object result = DBUtil.ScalarQuery(sql, thamSo);

            if (result != null && result != DBNull.Value && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(prefix.Length); 
                if (int.TryParse(maxCode, out int number))
                {
                    number += 1;
                    return $"{prefix}{number:D3}";
                }
            }

            return $"{prefix}001";
        }
        public List<ChiTietDichVu> searchByKeyword(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            var dsCtDichVu = SelectAll();

            return dsCtDichVu.Where(CT =>
                (!string.IsNullOrEmpty(CT.ChiTietDichVuID) && CT.ChiTietDichVuID.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(CT.HoaDonThueID) && CT.HoaDonThueID.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(CT.DichVuID) && CT.DichVuID.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(CT.LoaiDichVuID) && CT.LoaiDichVuID.ToLower().Contains(keyword))
            ).ToList();
        }


    }
}


