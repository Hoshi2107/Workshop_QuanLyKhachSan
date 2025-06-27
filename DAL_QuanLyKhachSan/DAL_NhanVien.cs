using DAL_QuanLyKhachSan;
using DTO_QuanLyKhachSan;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.PortableExecutable;

namespace DAL_QuanLyKhachSan
{
    public class DAL_NhanVien
    {
        public DTO_NhanVien? GetNhanVien1(string email, string password)
        {
            string sql = "SELECT Top 1 * FROM NhanVien WHERE Email=@0 AND MatKhau=@1";
            List<object> thamSo = new List<object>();
            thamSo.Add(email);
            thamSo.Add(password);
            SqlDataReader reader = DBUtil.Query(sql, thamSo);
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                    DTO_NhanVien nv = new DTO_NhanVien();
                    nv.MaNV = reader["MaNV"].ToString();
                    nv.HoTen = reader["HoTen"].ToString();
                    nv.GioiTinh = reader["GioiTinh"].ToString();    
                    nv.Email = reader["Email"].ToString();
                    nv.DiaChi = reader["DiaChi"].ToString();
                    nv.MatKhau = reader["MatKhau"].ToString();
                    nv.VaiTro = bool.Parse(reader["VaiTro"].ToString());
                    nv.TinhTrang = bool.Parse(reader["TinhTrang"].ToString());

                    return nv;
                }
            }
            return null;
        }
        public List<DTO_NhanVien> seletAll()
        {
            string sql = "SELECT * FROM NhanVien";
            return SelectBySql(sql, new List<object>());
        }

        public List<DTO_NhanVien> SelectBySql(string sql, List<object> args, CommandType cmdType = CommandType.Text)
        {
            List<DTO_NhanVien> list = new List<DTO_NhanVien>();
            try
            {
                SqlDataReader reader = DBUtil.Query(sql, args);
                while (reader.Read())
                {
                    DTO_NhanVien entity = new DTO_NhanVien();
                    entity.MaNV = reader.GetString("MaNV");
                    entity.HoTen = reader.GetString("HoTen");
                    entity.GioiTinh = reader.GetString("GioiTinh");
                    entity.Email = reader.GetString("Email");
                    entity.DiaChi = reader.GetString("DiaChi");
                    entity.MatKhau = reader.GetString("MatKhau");

                    entity.TinhTrang = reader.GetBoolean("TinhTrang");
                    entity.VaiTro = reader.GetBoolean("VaiTro");
                    list.Add(entity);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return list;
        }

        public List<DTO_NhanVien> selectAll()
        {
            String sql = "SELECT * FROM NhanVien";
            return SelectBySql(sql, new List<object>());
        }

        public void updateNhanVien(DTO_NhanVien nv)
        {
            try
            {
                string sql = @"UPDATE NhanVien
                                   SET HoTen = @1, Email = @2, MatKhau = @3, VaiTro = @4, TrangThai = @5
                                    WHERE MaNhanVien = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(nv.MaNV);
                thamSo.Add(nv.HoTen);
                thamSo.Add(nv.Email);
                thamSo.Add(nv.MatKhau);
                thamSo.Add(nv.VaiTro);
                thamSo.Add(nv.TinhTrang);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void insertNhanVien(DTO_NhanVien nv)
        {
            try
            {
                string sql = @"INSERT INTO NhanVien (MaNV, HoTen,GioiTinh, Email,DiaChi, MatKhau, VaiTro, TinhTrang) 
                   VALUES (@0, @1, @2, @3, @4, @5, @6, @7)";
                List<object> thamSo = new List<object>();
                thamSo.Add(nv.MaNV); 
                thamSo.Add(nv.HoTen);
                thamSo.Add(nv.GioiTinh);
                thamSo.Add(nv.Email);
                thamSo.Add (nv.DiaChi);
                thamSo.Add(nv.MatKhau);
                thamSo.Add(nv.VaiTro);
                thamSo.Add(nv.TinhTrang);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void deleteNhanVien(string maNv)
        {
            try
            {
                string sql = "DELETE FROM NhanVien WHERE MaNhanVien = @0";
                List<object> thamSo = new List<object>();
                thamSo.Add(maNv);
                DBUtil.Update(sql, thamSo);
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public string generateMaNhanVien()
        {
            string prefix = "NV";
            string sql = "SELECT MAX(MaNV) FROM NhanVien";
            List<object> thamSo = new List<object>();
            object result = DBUtil.Query(sql, thamSo);
            if (result != null && result.ToString().StartsWith(prefix))
            {
                string maxCode = result.ToString().Substring(2);
                int newNumber = int.Parse(maxCode) + 1;
                return $"{prefix}{newNumber:D3}";
            }

            return $"{prefix}001";
        }
    }
}
