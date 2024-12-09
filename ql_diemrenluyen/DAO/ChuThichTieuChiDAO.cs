using System;
using System.Collections.Generic;
using System.Data;
using ql_diemrenluyen.DTO;
using MySql.Data.MySqlClient;

namespace ql_diemrenluyen.DAO
{
    internal class ChuThichTieuChiDAO
    {
        public static List<ChuThichTieuChiDTO> GetChuThichByTieuChiId(long tieuChiId)
        {
            string sql = $@"
            SELECT 
                id, 
                tieuchidanhgia_id, 
                name, 
                diem, 
                created_at, 
                updated_at, 
                status
            FROM 
                chuthichtieuchi
            WHERE 
                tieuchidanhgia_id = {tieuChiId} AND status = 1";

            var result = DBConnection.ExecuteReader(sql); // Giả định phương thức ExecuteReader trả về List<Dictionary<string, object>>
            List<ChuThichTieuChiDTO> list = new List<ChuThichTieuChiDTO>();

            foreach (var row in result)
            {
                list.Add(new ChuThichTieuChiDTO(
                    id: Convert.ToInt32(row[0]),
                    tieuChiDanhGiaId: Convert.ToInt64(row[1]),
                    name: Convert.ToString(row[2]),
                    diem: Convert.ToInt32(row[3]),
                    createdAt: Convert.ToDateTime(row[4]),
                    updatedAt: Convert.ToDateTime(row[5]),
                    status: Convert.ToInt32(row[6])
                ));
            }
            return list;
        }
        // Lấy tất cả chú thích tiêu chí
        public static List<ChuThichTieuChiDTO> GetAllChuThichTieuChi()
        {
            List<ChuThichTieuChiDTO> chuThichList = new List<ChuThichTieuChiDTO>();
            string sql = @"
                SELECT 
                    id, 
                    tieuchidanhgia_id, 
                    name, 
                    diem, 
                    created_at, 
                    updated_at, 
                    status
                FROM 
                    chuthichtieuchi
                WHERE 
                    status = 1;
            ";
            List<List<object>> result = DBConnection.ExecuteReader(sql);
            foreach (var row in result)
            {
                // Đọc dữ liệu từ kết quả truy vấn
                int id = Convert.ToInt32(row[0]);
                long tieuChiDanhGiaId = Convert.ToInt64(row[1]);
                string name = Convert.ToString(row[2]);
                int diem = Convert.ToInt32(row[3]);
                DateTime createdAt = Convert.ToDateTime(row[4]);
                DateTime updatedAt = Convert.ToDateTime(row[5]);
                int status = Convert.ToInt32(row[6]);
                // Tạo đối tượng DTO và thêm vào danh sách
                ChuThichTieuChiDTO chuThich = new ChuThichTieuChiDTO(
                    id,
                    tieuChiDanhGiaId,
                    name,
                    diem,
                    createdAt,
                    updatedAt,
                    status
                );
                chuThichList.Add(chuThich);
            }
            return chuThichList;
        }
        public static List<ChuThichTieuChiDTO> GetAllChuThichTieuChi2()
        {
            List<ChuThichTieuChiDTO> chuThichList = new List<ChuThichTieuChiDTO>();
            string sql = "SELECT * FROM chuthichtieuchi";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                // Đọc dữ liệu từ kết quả truy vấn
                int id = Convert.ToInt32(row[0]);
                long tieuChiDanhGiaId = Convert.ToInt64(row[1]);
                string name = Convert.ToString(row[2]);
                int diem = Convert.ToInt32(row[3]);
                DateTime createdAt = Convert.ToDateTime(row[4]);
                DateTime updatedAt = Convert.ToDateTime(row[5]);
                int status = Convert.ToInt32(row[6]);

                // Tạo đối tượng DTO và thêm vào danh sách
                ChuThichTieuChiDTO chuThich = new ChuThichTieuChiDTO(
                    id,
                    tieuChiDanhGiaId,
                    name,
                    diem,
                    createdAt,
                    updatedAt,
                    status
                );

                chuThichList.Add(chuThich);
            }

            return chuThichList;
        }
        //hàm  thêm CT $"INSERT INTO" + $"VALUES ()" CHÚ THÍCH 


        public static bool AddChuThichTieuChi(ChuThichTieuChiDTO chuThich)
        {
            try
            {
                string sql = $"INSERT INTO chuthichtieuchi (tieuchidanhgia_id, name, diem, created_at, updated_at, status) " +
                             $"VALUES (@tieuchidanhgia_id, @name, @diem, @created_at, @updated_at, @status)";

                var cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@tieuchidanhgia_id", chuThich.TieuChiDanhGiaId);
                cmd.Parameters.AddWithValue("@name", chuThich.Name);
                cmd.Parameters.AddWithValue("@diem", chuThich.Diem);
                cmd.Parameters.AddWithValue("@created_at", chuThich.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@updated_at", chuThich.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@status", chuThich.Status);

                return DBConnection.ExecuteNonQuery(cmd) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm chú thích tiêu chí: " + ex.Message);
                return false;
            }
        }

        // Cập nhật chú thích tiêu chí
        public static bool UpdateChuThichTieuChi(ChuThichTieuChiDTO chuThich)
        {
            try
            {
                string sql = @"
                    UPDATE chuthichtieuchi 
                    SET 
                        tieuchidanhgia_id = @tieuchidanhgia_id, 
                        name = @name, 
                        diem = @diem, 
                        updated_at = @updated_at, 
                        status = @status 
                    WHERE 
                        id = @id";

                var cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@tieuchidanhgia_id", chuThich.TieuChiDanhGiaId);
                cmd.Parameters.AddWithValue("@name", chuThich.Name);
                cmd.Parameters.AddWithValue("@diem", chuThich.Diem);
                cmd.Parameters.AddWithValue("@updated_at", chuThich.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@status", chuThich.Status);
                cmd.Parameters.AddWithValue("@id", chuThich.Id);
                return DBConnection.ExecuteNonQuery(cmd) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật chú thích tiêu chí: " + ex.Message);
                return false;
            }
        }

        // Xóa chú thích tiêu chí (chỉ đánh dấu là không hoạt động)
        public static bool DeleteChuThichTieuChi(long id)
        {
            try
            {
                // Update the status to 0 (inactive) for the given id
                string sql = "UPDATE chuthichtieuchi SET status = 0 WHERE id = @id";

                // Use ExecuteNonQuery to execute the update query
                var cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@id", id);

                return DBConnection.ExecuteNonQuery(cmd) > 0; // Check if the update was successful
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chú thích tiêu chí: " + ex.Message);
                return false;
            }
        }

        //hàm search IS NULL name LIKE CONCAT('%', @search, '%')
        public static List<ChuThichTieuChiDTO> SearchChuThich(int? tieuchidanhgia_id, int status, string search)
        {
            List<ChuThichTieuChiDTO> chuThichList = new List<ChuThichTieuChiDTO>();

            string sql = @"
        SELECT * FROM chuthichtieuchi
        WHERE
            tieuchidanhgia_id IS NOT NULL
            AND (@tieuchidanhgia_id IS NULL OR tieuchidanhgia_id = @tieuchidanhgia_id)
            AND (@status IS NULL OR status = @status)
            AND (@search IS NULL OR name LIKE CONCAT('%', @search, '%') OR id LIKE CONCAT('%', @search, '%'))";

            try
            {
                // Khởi tạo MySqlCommand
                var cmd = new MySqlCommand(sql);

                // Thêm các tham số vào câu lệnh
                cmd.Parameters.AddWithValue("@tieuchidanhgia_id", tieuchidanhgia_id.HasValue ? (object)tieuchidanhgia_id.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@status", status == -1 ? (object)DBNull.Value : status);
                cmd.Parameters.AddWithValue("@search", string.IsNullOrEmpty(search) ? (object)DBNull.Value : search);

                // Thực thi câu lệnh và lấy kết quả
                List<List<object>> result = DBConnection.ExecuteReader(cmd);

                foreach (var row in result)
                {
                    ChuThichTieuChiDTO chuThich = new ChuThichTieuChiDTO
                    {
                        Id = Convert.ToInt32(row[0]),
                        TieuChiDanhGiaId = Convert.ToInt64(row[1]),
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

            return chuThichList;
        }

    }
}
