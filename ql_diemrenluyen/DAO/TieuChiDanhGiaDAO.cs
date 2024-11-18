using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace ql_diemrenluyen.DAO
{
    public class TieuChiDanhGiaDAO
    {
        // Lấy tất cả tiêu chí đánh giá
        public static List<TieuChiDanhGiaDTO> GetAllTieuChiDanhGia()
        {
            List<TieuChiDanhGiaDTO> tieuChiList = new List<TieuChiDanhGiaDTO>();
            string sql = "SELECT * FROM tieuchidanhgia"; // Cập nhật tên bảng thành 'nnuhw'

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                TieuChiDanhGiaDTO tieuChi = new TieuChiDanhGiaDTO(
                    Convert.ToInt64(row[0]),
                    Convert.ToString(row[1]), 
                    row[2] != DBNull.Value ? Convert.ToInt32(row[2]) : 0,
                    row[3] != DBNull.Value ? Convert.ToInt64(row[3]) : null, 
                    row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null, 
                    row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                    row[6] != DBNull.Value ? Convert.ToInt32(row[6]) : 0 
                );

                tieuChiList.Add(tieuChi);
            }


            return tieuChiList;
        }

        // Thêm tiêu chí đánh giá mới
        public static bool AddTieuChiDanhGia(TieuChiDanhGiaDTO tieuChi)
        {
            string sql = "INSERT INTO tieuchidanhgia (name, diem_max, parent_id, created_at, updated_at, status) " +
                         "VALUES (@name, @diemMax, @parentId, @createdAt, @updatedAt, @status)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", tieuChi.Name);
            cmd.Parameters.AddWithValue("@diemMax", tieuChi.DiemMax);
            cmd.Parameters.AddWithValue("@parentId", tieuChi.ParentId);
            cmd.Parameters.AddWithValue("@createdAt", tieuChi.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", tieuChi.UpdatedAt);
            cmd.Parameters.AddWithValue("@status", tieuChi.status); 

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin tiêu chí đánh giá
        public static bool UpdateTieuChiDanhGia(TieuChiDanhGiaDTO tieuChi)
        {
            string sql = "UPDATE tieuchidanhgia SET name = @name, diem_max = @diemMax, parent_id = @parentId, " +
                         "created_at = @createdAt, updated_at = @updatedAt, status = @status WHERE id = @id"; 

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", tieuChi.Id);
            cmd.Parameters.AddWithValue("@name", tieuChi.Name);
            cmd.Parameters.AddWithValue("@diemMax", tieuChi.DiemMax);
            cmd.Parameters.AddWithValue("@parentId", tieuChi.ParentId);
            cmd.Parameters.AddWithValue("@createdAt", tieuChi.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", tieuChi.UpdatedAt);
            cmd.Parameters.AddWithValue("@status", tieuChi.status); 

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa tiêu chí đánh giá
        public static bool DeleteTieuChiDanhGia(long id)
        {
            string sql = "UPDATE tieuchidanhgia SET status = 0 WHERE id = @id"; 

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
        public static List<TieuChiDanhGiaDTO> SearchTieuChiDanhGia(int? parentId, int status, string search)
        {
            List<TieuChiDanhGiaDTO> tieuChiList = new List<TieuChiDanhGiaDTO>();

            // Câu truy vấn SQL: bỏ qua các tiêu chí có parent_id là NULL và áp dụng các điều kiện lọc
            string sql = @"
SELECT * FROM tieuchidanhgia
WHERE
    parent_id IS NOT NULL
    AND (@parentId IS NULL OR parent_id = @parentId)
    AND (@status IS NULL OR status = @status)
    AND (@search IS NULL OR name LIKE CONCAT('%', @search, '%') OR id LIKE CONCAT('%', @search, '%'))";

            MySqlCommand cmd = new MySqlCommand(sql);

            try
            {
                // Thêm các tham số vào câu lệnh SQL
                cmd.Parameters.AddWithValue("@parentId", parentId.HasValue ? (object)parentId.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@status", status == -1 ? (object)DBNull.Value : status);
                cmd.Parameters.AddWithValue("@search", string.IsNullOrEmpty(search) ? (object)DBNull.Value : search);

                // Thực thi câu truy vấn và lấy kết quả
                List<List<object>> result = DBConnection.ExecuteReader(cmd);

                // Duyệt qua từng dòng kết quả và ánh xạ sang đối tượng `TieuChiDanhGiaDTO`
                foreach (var row in result)
                {
                    TieuChiDanhGiaDTO tieuChi = new TieuChiDanhGiaDTO
                    {
                        Id = Convert.ToInt64(row[0]), // id
                        Name = Convert.ToString(row[1]), // name
                        DiemMax = row[2] != DBNull.Value ? Convert.ToInt32(row[2]) : 0, // diem_max
                        ParentId = row[3] != DBNull.Value ? Convert.ToInt64(row[3]) : (long?)null, // parent_id
                        CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null, // created_at
                        UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null, // updated_at
                        status = row[6] != DBNull.Value ? Convert.ToInt32(row[6]) : 0 // status
                    };

                    tieuChiList.Add(tieuChi);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm tiêu chí đánh giá: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối và giải phóng tài nguyên
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Dispose();
            }

            return tieuChiList;
        }

        public static List<TieuChiDanhGiaDTO> SearchTieuChiDanhGiaWithoutParentId(int status, string search)
        {
            List<TieuChiDanhGiaDTO> tieuChiList = new List<TieuChiDanhGiaDTO>();

            // Câu truy vấn SQL: tìm kiếm theo status và search trên tên hoặc id
            string sql = @"
    SELECT * FROM tieuchidanhgia
    WHERE
        (@status IS NULL OR status = @status)
        AND (@search IS NULL OR name LIKE CONCAT('%', @search, '%') OR id LIKE CONCAT('%', @search, '%'))";

            MySqlCommand cmd = new MySqlCommand(sql);

            try
            {
                // Thêm các tham số vào câu lệnh SQL
                cmd.Parameters.AddWithValue("@status", status == -1 ? (object)DBNull.Value : status);
                cmd.Parameters.AddWithValue("@search", string.IsNullOrEmpty(search) ? (object)DBNull.Value : $"%{search}%");

                // Thực thi câu truy vấn và lấy kết quả
                List<List<object>> result = DBConnection.ExecuteReader(cmd);

                // Duyệt qua từng dòng kết quả và ánh xạ sang đối tượng `TieuChiDanhGiaDTO`
                foreach (var row in result)
                {
                    TieuChiDanhGiaDTO tieuChi = new TieuChiDanhGiaDTO
                    {
                        Id = Convert.ToInt64(row[0]), // id
                        Name = Convert.ToString(row[1]), // name
                        DiemMax = row[2] != DBNull.Value ? Convert.ToInt32(row[2]) : 0, // diem_max
                        ParentId = row[3] != DBNull.Value ? Convert.ToInt64(row[3]) : null, // parent_id
                        CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null, // created_at
                        UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null, // updated_at
                        status = row[6] != DBNull.Value ? Convert.ToInt32(row[6]) : 0 // status
                    };

                    tieuChiList.Add(tieuChi);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm tiêu chí đánh giá: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối và giải phóng tài nguyên
                if (cmd.Connection != null && cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Dispose();
            }

            return tieuChiList;
        }


    }
}
