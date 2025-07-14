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
    public class DALDatPhong
    {
        public List<DatPhong> SelectBySql(string sql, List<object> args)
        {
            List<DatPhong> list = new List< DatPhong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    DatPhong entity = new DatPhong();
                    entity.HoaDonThueID = reader.GetString("HoaDonThueID");
                    entity.MaKhachHang = reader.GetString("KhachHangID");
                    entity.MaPhong = reader.GetString("PhongID");
                    entity.NgayDen = reader.GetDateTime("NgayDen");
                    entity.NgayDi = reader.GetDateTime("NgayDi");
                    entity.MaNV = reader.GetString("MaNV");
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

        public List<DatPhong> SelectAll()
        {
            string sql = "SELECT * FROM DatPhong";
            return SelectBySql(sql, new List<object>());
        }
        public void insertDatPhong(DatPhong dp)
        {
            try
            {
                string sql = @"INSERT INTO DatPhong (HoaDonThueID, KhachHangID, PhongID, MaNV, NgayDen, NgayDi, GhiChu) 
                       VALUES (@0, @1, @2, @3, @4, @5, @6)";

                List<object> parameters = new List<object>
        {
            dp.HoaDonThueID,
            dp.MaKhachHang,
            dp.MaPhong,
            dp.MaNV,
            dp.NgayDen,
            dp.NgayDi,
            dp.GhiChu
        };

                DBUtil.Update(sql, parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string generateDatPhongID()
        {
            string prefix = "DP";
            string sql = "SELECT MAX(HoaDonThueID) FROM DatPhong";
            List<object> thamSo = new List<object>();

            object result = DBUtil.ScalarQuery(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(prefix.Length); // bỏ tiền tố "DP"
                if (int.TryParse(maxCode, out int number))
                {
                    int newNumber = number + 1;
                    return $"{prefix}{newNumber:D3}";
                }
            }

            return $"{prefix}001";
        }
        public List<DatPhong> searchByKeyword(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            var dp = SelectAll();

            return dp.Where(KH =>
                (!string.IsNullOrEmpty(KH.HoaDonThueID) && KH.HoaDonThueID.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(KH.MaKhachHang) && KH.MaKhachHang.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(KH.MaNV) && KH.MaNV.ToLower().Contains(keyword))
            ).ToList();
        }


    }
}
