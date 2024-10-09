using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class DiemRenLuyenSinhVienDAO
    {
        // Lấy tất cả điểm rèn luyện sinh viên
        public static List<DiemRenLuyenSinhVienDTO> GetAllDiemRenLuyen()
        {
            List<DiemRenLuyenSinhVienDTO> diemRenLuyens = new List<DiemRenLuyenSinhVienDTO>();
            string sql = "SELECT * FROM diem_ren_luyen_sinh_vien"; // Thay đổi câu lệnh SQL nếu cần

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                DiemRenLuyenSinhVienDTO diemRenLuyen = new DiemRenLuyenSinhVienDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    SinhVienId = row[1] != null ? (int?)Convert.ToInt32(row[1]) : null,
                    SemesterId = row[2] != null ? (int?)Convert.ToInt32(row[2]) : null,
                    Score = row[3] != null ? (decimal?)Convert.ToDecimal(row[3]) : null,
                    Comments = Convert.ToString(row[4])
                };

                diemRenLuyens.Add(diemRenLuyen);
            }

            return diemRenLuyens;
        }

        // Thêm điểm rèn luyện sinh viên mới
        public static bool AddDiemRenLuyen(DiemRenLuyenSinhVienDTO diemRenLuyen)
        {
            string sql = $"INSERT INTO diem_ren_luyen_sinh_vien (SinhVienId, SemesterId, Score, Comments) " +
                         $"VALUES (@sinhVienId, @semesterId, @score, @comments)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@sinhVienId", diemRenLuyen.SinhVienId);
            cmd.Parameters.AddWithValue("@semesterId", diemRenLuyen.SemesterId);
            cmd.Parameters.AddWithValue("@score", diemRenLuyen.Score);
            cmd.Parameters.AddWithValue("@comments", diemRenLuyen.Comments);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin điểm rèn luyện sinh viên
        public static bool UpdateDiemRenLuyen(DiemRenLuyenSinhVienDTO diemRenLuyen)
        {
            string sql = $"UPDATE diem_ren_luyen_sinh_vien SET SinhVienId = @sinhVienId, SemesterId = @semesterId, " +
                         $"Score = @score, Comments = @comments WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", diemRenLuyen.Id);
            cmd.Parameters.AddWithValue("@sinhVienId", diemRenLuyen.SinhVienId);
            cmd.Parameters.AddWithValue("@semesterId", diemRenLuyen.SemesterId);
            cmd.Parameters.AddWithValue("@score", diemRenLuyen.Score);
            cmd.Parameters.AddWithValue("@comments", diemRenLuyen.Comments);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa điểm rèn luyện sinh viên
        public static bool DeleteDiemRenLuyen(int id)
        {
            string sql = $"DELETE FROM diem_ren_luyen_sinh_vien WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}
