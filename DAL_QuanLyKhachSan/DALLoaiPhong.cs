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
    public class DALLoaiPhong
    {
        public List<DTO_LoaiPhong> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<DTO_LoaiPhong> list = new List<DTO_LoaiPhong>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    DTO_LoaiPhong entity = new DTO_LoaiPhong();
                    entity.MaLoaiPhong = reader.GetString("MaLoaiPhong");
                    entity.TenLoaiPhong = reader.GetString("TenLoaiPhong");
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
        public List<DTO_LoaiPhong> selectAll()
        {
            String sql = "SELECT * FROM LoaiPhong";
            return SelectBySql(sql, new List<object>());
        }
        public void Insert(DTO_LoaiPhong entity)
        {
            string sql = "INSERT INTO LoaiPhong (MaLoaiPhong, TenLoaiPhong, NgayTao, TrangThai, GhiChu) " +
                         "VALUES (@0, @1, @2, @3, @4)";
            List<object> args = new List<object>
            {
                entity.MaLoaiPhong,
                entity.TenLoaiPhong,
                entity.NgayTao,
                entity.TrangThai,
                entity.GhiChu
            };
            DBUtil.Update(sql, args);
        }

        public void Update(DTO_LoaiPhong entity)
        {
            string sql = "UPDATE LoaiPhong SET TenLoaiPhong = @1, NgayTao = @2, TrangThai = @3, GhiChu = @4 " +
                         "WHERE MaLoaiPhong = @0";
            List<object> args = new List<object>
            {
                entity.MaLoaiPhong,
                entity.TenLoaiPhong,
                entity.NgayTao,
                entity.TrangThai,
                entity.GhiChu
                
            };
            DBUtil.Update(sql, args);
        }
        public void Delete(string maLoaiPhong)
        {
            string sql = "DELETE FROM LoaiPhong WHERE MaLoaiPhong = @0";
            List<object> args = new List<object> { maLoaiPhong };
            DBUtil.Query(sql, args);
        }
        public List<DTO_LoaiPhong> SearchByKeyWord(string keyword)
        {
            keyword = keyword.Trim().ToLower();

            var dp = selectAll();

            return dp.Where(KH =>
                (!string.IsNullOrEmpty(KH.MaLoaiPhong) && KH.MaLoaiPhong.ToLower().Contains(keyword)) ||
                (!string.IsNullOrEmpty(KH.TenLoaiPhong) && KH.TenLoaiPhong.ToLower().Contains(keyword) )
            ).ToList();


        }
        public string generateLoaiPhong()
        {
            string prefix = "LP";
            string sql = "SELECT MAX(MaLoaiPhong) FROM LoaiPhong";
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



    }
}
