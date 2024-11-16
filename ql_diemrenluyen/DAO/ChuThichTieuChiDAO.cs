using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

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
                    TieuChiDanhGiaId = Convert.ToUInt64(row[1]), 
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
                string sql = "DELETE FROM chuthichtieuchi WHERE id = @id";
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
    }
}
