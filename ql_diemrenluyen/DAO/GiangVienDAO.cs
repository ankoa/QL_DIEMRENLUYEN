﻿using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class GiangVienDAO
    {
        // Lấy tất cả giảng viên
        // Lấy tất cả giảng viên
            public static List<GiangVienDTO> GetAllGiangVien()
            {
                List<GiangVienDTO> giangViens = new List<GiangVienDTO>();
                string sql = "SELECT * FROM giangvien"; 

                List<List<object>> result = DBConnection.ExecuteReader(sql);

                foreach (var row in result)
                {
                    GiangVienDTO giangVien = new GiangVienDTO
                    {
                        Id = Convert.ToString(row[0]), 
                        Name = Convert.ToString(row[1]), 
                        Email = Convert.ToString(row[2]), 
                        ngaySinh = row[3] != null ? Convert.ToDateTime(row[7]) : (DateTime?)null,
                        CreatedAt = row[4] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null, 
                        UpdatedAt = row[5] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null, 
                        ChucVu = Convert.ToString(row[6]),
                        KhoaId = Convert.ToString(row[7]),
                        
                    };

                    giangViens.Add(giangVien);
                }

                return giangViens;
            }

        // Thêm giảng viên mới

        public static bool AddGiangVien(GiangVienDTO giangVien, DateTime ngaySinh)
        {
            // Cập nhật câu lệnh SQL để bao gồm ngày sinh
            string sql = $"INSERT INTO giangvien (name, email, created_at, updated_at, chucvu, khoa_id, ngay_sinh) " +
                        $"VALUES (@name, @email, @createdAt, @updatedAt, @ChucVu, @khoaId, @ngaySinh)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", giangVien.Name);
            cmd.Parameters.AddWithValue("@email", giangVien.Email);
            cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);  
            cmd.Parameters.AddWithValue("@createdAt", giangVien.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", giangVien.UpdatedAt);
            cmd.Parameters.AddWithValue("@ChucVu", giangVien.ChucVu);
            cmd.Parameters.AddWithValue("@khoaId", giangVien.KhoaId);
            

            bool isGiangVienAdded = DBConnection.ExecuteNonQuery(cmd) > 0;

            if (isGiangVienAdded)
            {
                // Lấy id giảng viên mới tạo bằng LAST_INSERT_ID()
                long giangVienId = GetLastInsertedId(); 

                // Tạo tài khoản cho giảng viên mới
                string password = ngaySinh.ToString("yyyyMMdd");

                return AddAccount(giangVienId, password);
            }

            return false;
        }


        // Hàm lấy ID giảng viên mới thêm vào
        public static long GetLastInsertedId()
        {
            string sql = "SELECT LAST_INSERT_ID()";  // Lấy id của dòng mới thêm
            var cmd = new MySqlCommand(sql);
            List<List<object>> result = DBConnection.ExecuteReader(cmd);
            
            if (result.Count > 0)
            {
                return Convert.ToInt64(result[0][0]);
            }

            return -1; 
        }

        
        public static bool AddAccount(long giangVienId, string password)
        {
            string sql = $"INSERT INTO account (id, password, role) VALUES (@id, @password, @role)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", giangVienId);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@role", 0); // Giảng viên bình thường (có thể điều chỉnh theo chức vụ)

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin giảng viên
        public static bool UpdateGiangVien(GiangVienDTO giangVien)
        {
            string sql = $"UPDATE giangvien SET name = @name, email = @email, " +
                         $"created_at = @createdAt, updated_at = @updatedAt, chucvu = @ChucVu, khoa_id = @khoaId WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", giangVien.Id);
            cmd.Parameters.AddWithValue("@name", giangVien.Name);
            cmd.Parameters.AddWithValue("@email", giangVien.Email);
            cmd.Parameters.AddWithValue("@createdAt", giangVien.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", giangVien.UpdatedAt);
            cmd.Parameters.AddWithValue("@ChucVu", giangVien.ChucVu);
            cmd.Parameters.AddWithValue("@khoaId", giangVien.KhoaId);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

    
        public static bool DeleteGiangVien(long id)
        {
            string sql = $"DELETE FROM giangvien WHERE id = @id"; 
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        
        public static GiangVienDTO GetGiangVienByEmail(string email)
        {
            string sql = "SELECT * FROM giangvien WHERE email = @email";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@email", email);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                return MapToGiangVienDTO(result[0]);
            }

            return null; // Trả về null nếu không tìm thấy giảng viên
        }

        // Lấy giảng viên theo Id
        public static GiangVienDTO GetGiangVienById(long id)
        {
            string sql = "SELECT * FROM giangvien WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                return MapToGiangVienDTO(result[0]);
            }

            return null; // Trả về null nếu không tìm thấy giảng viên
        }

        // Tìm kiếm giảng viên theo từ khóa
        public static List<GiangVienDTO> SearchGiangVien(string searchTerm)
        {
            List<GiangVienDTO> giangViens = new List<GiangVienDTO>();
            string sql = "SELECT * FROM giangvien WHERE name LIKE @searchTerm OR email LIKE @searchTerm";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            foreach (var row in result)
            {
                GiangVienDTO giangVien = new GiangVienDTO
                {
                    Id = Convert.ToString(row[0]), 
                    Name = Convert.ToString(row[1]), 
                    Email = Convert.ToString(row[2]), 
                    CreatedAt = row[3] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null, 
                    UpdatedAt = row[4] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null, 
                    ChucVu = Convert.ToString(row[5]),
                    KhoaId = Convert.ToString(row[6]) 
                };

                giangViens.Add(giangVien);
            }

            return giangViens;
        }

        // Tìm kiếm giảng viên theo chức vụ
        public static List<GiangVienDTO> SearchGiangVienByChucVu(string chucVu)
        {
            List<GiangVienDTO> giangViens = new List<GiangVienDTO>();
            string sql = "SELECT * FROM giangvien WHERE chucvu = @chucVu"; 

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@chucVu", chucVu); // Thêm tham số chức vụ vào câu truy vấn

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            foreach (var row in result)
            {
                GiangVienDTO giangVien = new GiangVienDTO
                {
                    Id = Convert.ToString(row[0]),
                    Name = Convert.ToString(row[1]),
                    Email = Convert.ToString(row[2]),
                    CreatedAt = row[3] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null,
                    UpdatedAt = row[4] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null,
                    ChucVu = Convert.ToString(row[5]),
                    KhoaId = Convert.ToString(row[6])
                };

                giangViens.Add(giangVien);
            }

            return giangViens;
        }

        // Map kết quả từ cơ sở dữ liệu vào DTO
        // Map kết quả từ cơ sở dữ liệu vào DTO
        private static GiangVienDTO MapToGiangVienDTO(List<object> row)
        {
            return new GiangVienDTO
            {
                Id = Convert.ToString(row[0]),
                Name = Convert.ToString(row[1]),
                Email = Convert.ToString(row[2]),
                ngaySinh = row[3] != null ? Convert.ToDateTime(row[7]) : (DateTime?)null,
                CreatedAt = row[4] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null,
                UpdatedAt = row[5] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null,
                ChucVu = Convert.ToString(row[6]),
                KhoaId = Convert.ToString(row[7]),
               
            };
        }

    }
}
