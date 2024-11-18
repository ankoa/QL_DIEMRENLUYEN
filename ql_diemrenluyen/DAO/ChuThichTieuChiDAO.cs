using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace ql_diemrenluyen.DAO
{
    public class ChuThichTieuChiDAO
    {
        public static List<ChuThichTieuChiDTO> GetAllChuThichTieuChi()
        {
            List<ChuThichTieuChiDTO> chuThichList = new List<ChuThichTieuChiDTO>();
            string sql = "SELECT * FROM chuthichtieuchi";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                ChuThichTieuChiDTO chuThich = new ChuThichTieuChiDTO
                {
                    Id = Convert.ToInt32(row[0]), 
                    TieuChiDanhGiaId = Convert.ToInt32(row[1]), 
                    Name = Convert.ToString(row[2]),
                    Diem = Convert.ToInt32(row[3]),
                    CreatedAt = Convert.ToDateTime(row[4]), 
                    UpdatedAt = Convert.ToDateTime(row[5]), 
                    Status = Convert.ToInt32(row[6]) 
                };

                chuThichList.Add(chuThich);
            }

            return chuThichList;
        }


        // Thêm mới chú thích tiêu chí
        public static bool AddChuThichTieuChi(ChuThichTieuChiDTO chuThich)
        {
            try
            {
                string sql = "INSERT INTO chuthichtieuchi (tieuchidanhgia_id, name, diem, created_at, updated_at, status) " +
                             "VALUES (@tieuchidanhgia_id, @name, @diem, @created_at, @updated_at, @status)";
                using (var cmd = new MySqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@tieuchidanhgia_id", chuThich.TieuChiDanhGiaId);
                    cmd.Parameters.AddWithValue("@name", chuThich.Name);
                    cmd.Parameters.AddWithValue("@diem", chuThich.Diem);
                    cmd.Parameters.AddWithValue("@created_at", chuThich.CreatedAt);
                    cmd.Parameters.AddWithValue("@updated_at", chuThich.UpdatedAt);
                    cmd.Parameters.AddWithValue("@status", chuThich.Status);

                    return DBConnection.ExecuteNonQuery(cmd) > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chú thích tiêu chí: " + ex.Message);
                return false;
            }
        }

        // Cập nhật thông tin chú thích tiêu chí
        public static bool UpdateChuThichTieuChi(ChuThichTieuChiDTO chuThich)
        {
            try
            {
                string sql = "UPDATE chuthichtieuchi SET tieuchidanhgia_id = @tieuchidanhgia_id, name = @name, diem = @diem, " +
                             "updated_at = @updated_at, status = @status WHERE id = @id";
                using (var cmd = new MySqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@id", chuThich.Id);
                    cmd.Parameters.AddWithValue("@tieuchidanhgia_id", chuThich.TieuChiDanhGiaId);
                    cmd.Parameters.AddWithValue("@name", chuThich.Name);
                    cmd.Parameters.AddWithValue("@diem", chuThich.Diem);
                    cmd.Parameters.AddWithValue("@updated_at", chuThich.UpdatedAt);
                    cmd.Parameters.AddWithValue("@status", chuThich.Status);

                    return DBConnection.ExecuteNonQuery(cmd) > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chú thích tiêu chí: " + ex.Message);
                return false;
            }
        }

        // Xóa chú thích tiêu chí
        public static bool DeleteChuThichTieuChi(int id)
        {
            try
            {
                string sql = "UPDATE chuthichtieuchi SET status = 0 WHERE id = @id";
                using (var cmd = new MySqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return DBConnection.ExecuteNonQuery(cmd) > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chú thích tiêu chí: " + ex.Message);
                return false;
            }

        }
        public static List<ChuThichTieuChiDTO> SearchChuThich(int? tieuchidanhgia_id, int status, string search)
        {
            List<ChuThichTieuChiDTO> chuThichList = new List<ChuThichTieuChiDTO>();

            // Câu truy vấn SQL: bỏ qua các tiêu chí có parent_id là NULL và áp dụng các điều kiện lọc
            string sql = @"
SELECT * FROM chuthichtieuchi
WHERE
    tieuchidanhgia_id IS NOT NULL
    AND (@tieuchidanhgia_id IS NULL OR tieuchidanhgia_id = @tieuchidanhgia_id)
    AND (@status IS NULL OR status = @status)
    AND (@search IS NULL OR name LIKE CONCAT('%', @search, '%') OR id LIKE CONCAT('%', @search, '%'))";

            MySqlCommand cmd = new MySqlCommand(sql);

            try
            {
                // Thêm các tham số vào câu lệnh SQL
                cmd.Parameters.AddWithValue("@tieuchidanhgia_id", tieuchidanhgia_id.HasValue ? (object)tieuchidanhgia_id.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@status", status == -1 ? (object)DBNull.Value : status);
                cmd.Parameters.AddWithValue("@search", string.IsNullOrEmpty(search) ? (object)DBNull.Value : search);

                // Thực thi câu truy vấn và lấy kết quả
                List<List<object>> result = DBConnection.ExecuteReader(cmd);

                // Duyệt qua từng dòng kết quả và ánh xạ sang đối tượng `TieuChiDanhGiaDTO`
                foreach (var row in result)
                {
                    ChuThichTieuChiDTO chuThich = new ChuThichTieuChiDTO
                    {
                        Id = Convert.ToInt32(row[0]),
                        TieuChiDanhGiaId = Convert.ToInt32(row[1]),
                        Name = Convert.ToString(row[2]),
                        Diem = Convert.ToInt32(row[3]),
                        CreatedAt = Convert.ToDateTime(row[4]),
                        UpdatedAt = Convert.ToDateTime(row[5]),
                        Status = Convert.ToInt32(row[6])
                    };

                    chuThichList.Add(chuThich);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tìm kiếm chú thích tiêu chí đánh giá: " + ex.Message);
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

            return chuThichList;
        }
    }
}
