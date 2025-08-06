using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLyKhachSan
{
    public class DALKhachHang
    {
        public List<KhachHang> SelectBySql(string sql, List<object> args)
        {
            List<KhachHang> list = new List<KhachHang>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    KhachHang entity = new KhachHang();
                    entity.KhachHangID = reader["KhachHangID"].ToString();
                    entity.HoTen = reader["HoTen"].ToString();
                    entity.DiaChi = reader["DiaChi"].ToString();
                    entity.GioiTinh = reader["GioiTinh"].ToString();
                    entity.SoDienThoai = reader["SoDienThoai"].ToString();
                    entity.CCCD = reader["CCCD"].ToString();
                    entity.NgayTao = DateTime.Parse(reader["NgayTao"].ToString());
                    entity.TrangThai = bool.Parse(reader["TrangThai"].ToString());
                    entity.GhiChu = reader["GhiChu"].ToString();
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<KhachHang> SelectAll()
        {
            string sql = "SELECT * FROM KhachHang";
            return SelectBySql(sql, new List<object>());
        }
        public void insertKhachHang(KhachHang kh)
        {
            try
            {
                string sql = @"INSERT INTO KhachHang (KhachHangID, HoTen, DiaChi, GioiTinh, SoDienThoai, CCCD, NgayTao, TrangThai, GhiChu) 
                               VALUES (@0, @1, @2, @3, @4, @5, @6, @7, @8)";
                List<object> thamSo = new List<object>
                {
                    kh.KhachHangID,
                    kh.HoTen,
                    kh.DiaChi,
                    kh.GioiTinh,
                    kh.SoDienThoai,
                    kh.CCCD,
                    kh.NgayTao,
                    kh.TrangThai,
                    kh.GhiChu
                };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void deleteKhachHang(string khachHangID)
        {
            try
            {
                string sql = "DELETE FROM KhachHang WHERE KhachHangID = @0";
                List<object> thamSo = new List<object> { khachHangID};
                DBUtil.Query(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void updateKhachHang(KhachHang kh)
        {
            try
            {
                string sql = @"UPDATE KhachHang
                               SET HoTen = @1, DiaChi = @2, GioiTinh = @3, SoDienThoai = @4, CCCD = @5, NgayTao = @6, TrangThai = @7, GhiChu = @8
                               WHERE KhachHangID = @0";
                List<object> thamSo = new List<object>
                {
                    kh.KhachHangID,
                    kh.HoTen,
                    kh.DiaChi,
                    kh.GioiTinh,
                    kh.SoDienThoai,
                    kh.CCCD,
                    kh.NgayTao,
                    kh.TrangThai,
                    kh.GhiChu
                };
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string generateKhachHangID()
        {
            string prefix = "KH";
            string sql = "SELECT MAX(KhachHangID) FROM KhachHang";
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
        public List<KhachHang> selectAll()
        {
            String sql = "SELECT * FROM KhachHang";
            return SelectBySql(sql, new List<object>());
        }
        public List<KhachHang> searchByKeyword(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            var dsKhachHang = selectAll();

            return dsKhachHang.Where(KH =>
                (!string.IsNullOrEmpty(KH.KhachHangID) && KH.KhachHangID.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(KH.HoTen) && KH.HoTen.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(KH.DiaChi) && KH.DiaChi.ToLower().Contains(keyword))
            ).ToList();
        }
        public bool KiemTraKhachHangTonTai(string khachHangID)
        {
            string sql = "SELECT COUNT(*) FROM KhachHang WHERE KhachHangID = @0";
            List<object> param = new List<object> { khachHangID };
            object result = DBUtil.ScalarQuery(sql, param);

            if (result != null && int.TryParse(result.ToString(), out int count))
            {
                return count > 0;
            }

            return false;
        }
    }
}
    
