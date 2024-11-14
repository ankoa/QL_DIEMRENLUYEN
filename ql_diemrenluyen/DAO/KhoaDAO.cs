using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class KhoaDAO
    {
        // Lấy tất cả khoa
        public static List<KhoaDTO> GetAllKhoa()
        {
            List<KhoaDTO> khoaList = new List<KhoaDTO>();
            string sql = "SELECT * FROM khoa"; 

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                KhoaDTO khoa = new KhoaDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    TenKhoa = Convert.ToString(row[1]),
                    CreatedAt = row[2] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[2]) : null,
                    UpdatedAt = row[3] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[3]) : null,
                    status = Convert.ToInt16(row[4])
                };

                khoaList.Add(khoa);
            }

            return khoaList;
        }

        // Lấy đối tượng khoa từ ID của khoa
        public static KhoaDTO GetKhoaByID(long id)
        {
            string sql = "select * from khoa where khoa.id= @id"; // Câu lệnh SQL
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                List<object> row = result[0];
                KhoaDTO khoa = new KhoaDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    TenKhoa = Convert.ToString(row[1]),
                    CreatedAt = row[2] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[2]) : null,
                    UpdatedAt = row[3] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[3]) : null,
                    status = Convert.ToInt16(row[4])
                };
                return khoa;
            }

            return null;
        }
        public static KhoaDTO GetKhoaByName(string name) {
            String sql = "select * from khoa where khoa.tenkhoa like @name";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", "%"+name+"%");
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if (result.Count > 0) { 
                List<object> row = result[0];
                KhoaDTO khoa = new KhoaDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    TenKhoa = Convert.ToString(row[1]),
                    CreatedAt = row[2] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[2]) : null,
                    UpdatedAt = row[3] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[3]) : null,
                    status = Convert.ToInt16(row[4])
                };
                return khoa;
            }
            return null;
        }
        public static List<KhoaDTO> findAll(String value)
        {
            List<KhoaDTO> list= new List<KhoaDTO>();
            String sql = "SELECT * FROM khoa where khoa.id LIKE @id or khoa.tenkhoa LIKE @name or khoa.created_at LIKE @create or khoa.updated_at LIKE @update";
            var cmd= new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", "%" + value + "%");
            cmd.Parameters.AddWithValue("@name", "%" + value + "%");
            cmd.Parameters.AddWithValue("@create", "%" + value + "%");
            cmd.Parameters.AddWithValue("@update", "%" + value + "%");
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if (result.Count > 0)
            {
                foreach (var row in result)
                {
                    KhoaDTO khoa = new KhoaDTO
                    {
                        Id = Convert.ToInt64(row[0]),
                        TenKhoa = Convert.ToString(row[1]),
                        CreatedAt = row[2] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[2]) : null,
                        UpdatedAt = row[3] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[3]) : null,
                        status = Convert.ToInt16(row[4])
                    };
                    list.Add(khoa);
                }
                return list;
            }
            return null;
        }
        public static List<KhoaDTO> findName(String value)
        {
            List<KhoaDTO> list = new List<KhoaDTO>();
            String sql = "SELECT * FROM khoa where khoa.tenkhoa LIKE @name";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", "%" + value + "%");
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            if (result.Count > 0)
            {
                foreach (var row in result)
                {
                    KhoaDTO khoa = new KhoaDTO
                    {
                        Id = Convert.ToInt64(row[0]),
                        TenKhoa = Convert.ToString(row[1]),
                        CreatedAt = row[2] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[2]) : null,
                        UpdatedAt = row[3] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[3]) : null,
                        status = Convert.ToInt16(row[4])
                    };
                    list.Add(khoa);
                }
                return list;
            }
            return null;
        }
        public static List<KhoaDTO> GetListKhoaByID(long id)
        {
            List<KhoaDTO> list = new List<KhoaDTO>();
            string sql = "select * from khoa where khoa.id LIKE @id"; // Câu lệnh SQL
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", "%"+id+"%");

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                foreach (var row in result) {
                    KhoaDTO khoa = new KhoaDTO
                    {
                        Id = Convert.ToInt64(row[0]),
                        TenKhoa = Convert.ToString(row[1]),
                        CreatedAt = row[2] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[2]) : null,
                        UpdatedAt = row[3] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[3]) : null,
                        status = Convert.ToInt16(row[4])
                    };
                    list.Add(khoa);
                }
                return list;
            }
            return null;
        }

        // Thêm khoa mới
        public static bool AddKhoa(KhoaDTO khoa)
        {
            string sql = "INSERT INTO khoa (id, tenkhoa, created_at, updated_at, status) VALUES (@id, s@tenKhoa, @createdAt, @updatedAt, @status)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", khoa.Id);
            cmd.Parameters.AddWithValue("@tenKhoa", khoa.TenKhoa);
            cmd.Parameters.AddWithValue("@createdAt", khoa.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", khoa.UpdatedAt);
            cmd.Parameters.AddWithValue("@status", khoa.status);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin khoa
        public static bool UpdateKhoa(KhoaDTO khoa)
        {
            string sql = "UPDATE khoa SET tenkhoa = @tenKhoa, created_at = @createdAt, updated_at = @updatedAt, status=@status WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", khoa.Id);
            cmd.Parameters.AddWithValue("@tenKhoa", khoa.TenKhoa);
            cmd.Parameters.AddWithValue("@createdAt", khoa.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", khoa.UpdatedAt);
            cmd.Parameters.AddWithValue("@status", khoa.status);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa khoa
        public static bool DeleteKhoa(long id)
        {
            string sql = "UPDATE khoa SET status=@status WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@status", 0);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
