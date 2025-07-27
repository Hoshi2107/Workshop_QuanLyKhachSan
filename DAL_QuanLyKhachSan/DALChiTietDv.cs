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
        public List<DTO_ChiTietDichVu> SelectBySql(string sql, List<object> args)
        {
            List<DTO_ChiTietDichVu> list = new List<DTO_ChiTietDichVu>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    DTO_ChiTietDichVu entity = new DTO_ChiTietDichVu();
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

        public List<DTO_ChiTietDichVu> SelectAll()
        {
            string sql = "SELECT * FROM ChiTietDichVu";
            return SelectBySql(sql, new List<object>());
        }
        public void Insert(DTO_ChiTietDichVu entity)
        {
            string sql = "INSERT INTO ChiTietDichVu (ChiTietDichVuID, HoaDonThueID, DichVuID, LoaiDichVuID, SoLuong, NgayBatDau, NgayKetThuc, GhiChu) " +
                         "VALUES (@0, @1, @2, @3, @4, @5, @6, @7)";
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
        public void delete(string ChiTietDichVu)
        {
            string sql = "DELETE FROM ChiTietDichVu WHERE ChiTietDichVuID = @0";
            List<object> args = new List<object> { ChiTietDichVu };
            DBUtil.Query(sql, args);
        }
        public void update(DTO_ChiTietDichVu entity)
        {
            string sql = "UPDATE ChiTietDichVu SET HoaDonThueID = @1, DichVuID = @2, LoaiDichVuID = @3, " +
                         "SoLuong = @4, NgayBatDau = @5, NgayKetThuc = @6, GhiChu = @7 " +
                         "WHERE ChiTietDichVuID = @0";
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
        public List<DTO_ChiTietDichVu> searchByKeyword(string keyword)
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


