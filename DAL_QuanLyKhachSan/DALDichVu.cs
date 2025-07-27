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
    public class DALDichVu
    {
        public List<DTO_DichVU> SelectBySql(string sql, List<object> args)
        {
            List<DTO_DichVU> list = new List<DTO_DichVU>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    DTO_DichVU entity = new DTO_DichVU();
                    entity.DichVuID = reader.GetString("DichVuID");
                    entity.HoaDonThueID = reader.GetString("HoaDonThueID");
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

        public List<DTO_DichVU> SelectAll()
        {
            string sql = "SELECT * FROM DichVu";
            return SelectBySql(sql, new List<object>());
        }

        public List<DTO_DichVU> GetByHoaDonThueID(string hoaDonThueID)
        {
            string sql = "SELECT * FROM DichVu WHERE HoaDonThueID LIKE '%' + @0 + '%'";
            return SelectBySql(sql, new List<object> { hoaDonThueID });
        }

        public void Add(DTO_DichVU dv)
        {
            string sql = @"INSERT INTO DichVu (DichVuID, HoaDonThueID, NgayTao, TrangThai, GhiChu)
                           VALUES (@0, @1, @2, @3, @4)";
            List<object> args = new List<object> { dv.DichVuID, dv.HoaDonThueID, dv.NgayTao, dv.TrangThai, dv.GhiChu };
            DBUtil.Update(sql, args);
        }

        public void Update(DTO_DichVU dv)
        {
            string sql = @"UPDATE DichVu 
                           SET HoaDonThueID = @1, NgayTao = @2, TrangThai = @3, GhiChu = @4 
                           WHERE DichVuID = @0";
            List<object> args = new List<object> { dv.DichVuID, dv.HoaDonThueID, dv.NgayTao, dv.TrangThai, dv.GhiChu };
            DBUtil.Update(sql, args);
        }

        public void Delete(string dichVuID)
        {
            string sql = "DELETE FROM DichVu WHERE DichVuID = @0";
            DBUtil.Query(sql, new List<object> { dichVuID });
        }

        public string GenerateNewDichVuID()
        {
            string prefix = "DVHD";
            string sql = "SELECT MAX(DichVuID) FROM DichVu";
            object result = DBUtil.ScalarQuery(sql, new List<object>());

            if (result != null && result != DBNull.Value)
            {
                string currentMaxID = result.ToString();

                if (currentMaxID.StartsWith(prefix))
                {
                    string numberPart = currentMaxID.Substring(prefix.Length); // Cắt đúng sau tiền tố
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
