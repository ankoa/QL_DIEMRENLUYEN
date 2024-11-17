﻿using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

namespace ql_diemrenluyen.DAO
{
    public class TieuChiDanhGiaDAO
    {
        // Lấy tất cả tiêu chí đánh giá
        public static List<TieuChiDanhGiaDTO> GetAllTieuChiDanhGia()
        {
            List<TieuChiDanhGiaDTO> tieuChiList = new List<TieuChiDanhGiaDTO>();
            string sql = "SELECT * FROM tieu_chi_danh_gia"; // Câu lệnh SQL

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                TieuChiDanhGiaDTO tieuChi = new TieuChiDanhGiaDTO(
                    Convert.ToInt64(row[0]),
                    Convert.ToString(row[1]),
                    Convert.ToInt32(row[2]),
                    Convert.ToInt64(row[3]),
                    row[4] != null ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                    row[5] != null ? (DateTime?)Convert.ToDateTime(row[5]) : null
                );

                tieuChiList.Add(tieuChi);
            }

            return tieuChiList;
        }

        // Thêm tiêu chí đánh giá mới
        public static bool AddTieuChiDanhGia(TieuChiDanhGiaDTO tieuChi)
        {
            string sql = "INSERT INTO `sinhvien` (`name`, `ngaysinh`, `email`, `gioitinh`, `lop_id`, `chucvu`, `created_at`, `updated_at`) " +
                                           "VALUES (@name, @birthDate, @email, @gender, @classId, @position, @createdAt, @updatedAt);";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", tieuChi.Name);
            cmd.Parameters.AddWithValue("@diemMax", tieuChi.DiemMax);
            cmd.Parameters.AddWithValue("@parentId", tieuChi.ParentId);
            cmd.Parameters.AddWithValue("@createdAt", tieuChi.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", tieuChi.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin tiêu chí đánh giá
        public static bool UpdateTieuChiDanhGia(TieuChiDanhGiaDTO tieuChi)
        {
            string sql = "UPDATE tieu_chi_danh_gia SET Name = @name, DiemMax = @diemMax, ParentId = @parentId, CreatedAt = @createdAt, UpdatedAt = @updatedAt WHERE Id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", tieuChi.Id);
            cmd.Parameters.AddWithValue("@name", tieuChi.Name);
            cmd.Parameters.AddWithValue("@diemMax", tieuChi.DiemMax);
            cmd.Parameters.AddWithValue("@parentId", tieuChi.ParentId);
            cmd.Parameters.AddWithValue("@createdAt", tieuChi.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", tieuChi.UpdatedAt);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Xóa tiêu chí đánh giá
        public static bool DeleteTieuChiDanhGia(long id)
        {
            string sql = "DELETE FROM tieu_chi_danh_gia WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
        public static List<TieuChiDanhGiaDTO> XuatAllTieuChiDanhGia()
        {
            List<TieuChiDanhGiaDTO> tieuChiList = new List<TieuChiDanhGiaDTO>();
            //string sql = "SELECT \r\n    CASE \r\n        WHEN tc1.parent_id IS NULL THEN \r\n            CONCAT(tc1.id, '. ', tc1.name)  -- Đánh số la mã hoặc số nguyên cho mục cha\r\n        ELSE \r\n            CONCAT(tc1.parent_id, '.', tc1.id, ' ', tc1.name)  -- Đánh số thập phân cho mục con\r\n    END AS name,\r\n    tc1.diem_max AS diem_max,\r\n    tc1.id AS id,\r\n    tc1.parent_id AS parent_id\r\nFROM tieuchidanhgia tc1\r\nORDER BY COALESCE(tc1.parent_id, tc1.id), tc1.parent_id, tc1.id;\r\n"; // Câu lệnh SQL
            //string sql = "SELECT \r\n    tc1.id AS id,  -- id là số\r\n    CASE \r\n        WHEN tc1.parent_id IS NULL THEN CONCAT(tc1.id, '. ', tc1.name) -- Mục cha\r\n        ELSE CONCAT(tc2.id, '.', tc1.id, ' ', tc1.name)  -- Mục con\r\n    END AS name,  -- name là chuỗi\r\n    tc1.diem_max AS diem_max,  -- diem_max là số\r\n    tc1.parent_id AS parent_id  -- parent_id có thể là số hoặc null\r\nFROM tieuchidanhgia tc1\r\nLEFT JOIN tieuchidanhgia tc2 ON tc1.parent_id = tc2.id  -- Nối bảng với mục cha\r\nORDER BY COALESCE(tc1.parent_id, tc1.id), tc1.parent_id, tc1.id;"; // Câu lệnh SQL
            //            string sql = @"
            //    WITH NumberedItems AS (
            //    SELECT 
            //        tc1.id AS id,
            //        tc1.name AS name,
            //        tc1.diem_max AS diem_max,
            //        tc1.parent_id AS parent_id,
            //        ROW_NUMBER() OVER (PARTITION BY tc1.parent_id ORDER BY tc1.id) AS ChildIndex
            //    FROM tieuchidanhgia tc1
            //)
            //SELECT 
            //    id,
            //    CASE 
            //        WHEN parent_id IS NULL THEN CAST(id AS CHAR)  -- Chỉ số mục cha
            //        ELSE CONCAT(parent_id, '.', ChildIndex)         -- Định dạng mục con
            //    END AS name,
            //    diem_max,
            //    parent_id
            //FROM NumberedItems
            //ORDER BY COALESCE(parent_id, id), parent_id, ChildIndex;

            //";
            string sql = @"
        SELECT 
            tc1.id AS id,
            tc1.name AS name,
            tc1.diem_max AS diem_max,
            tc1.parent_id AS parent_id
        FROM tieuchidanhgia tc1
        WHERE tc1.status = 1 -- Chỉ lấy các tiêu chí có status = 1
        ORDER BY COALESCE(tc1.parent_id, tc1.id), tc1.parent_id, tc1.id;
    ";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                //TieuChiDanhGiaDTO tieuChi = new TieuChiDanhGiaDTO(
                //    Convert.ToInt64(row[0]),
                //    Convert.ToString(row[1]),
                //    Convert.ToInt32(row[2]),
                //    Convert.ToInt64(row[3]),
                //    row[4] != null ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                //    row[5] != null ? (DateTime?)Convert.ToDateTime(row[5]) : null
                //);

                // Trường id là số
                long id = Convert.ToInt64(row[0]);

                // Trường name là chuỗi
                string name = Convert.ToString(row[1]);

                // Kiểm tra nếu diemMax là null, đặt giá trị mặc định là 0
                int diemMax = row[2] != DBNull.Value ? Convert.ToInt32(row[2]) : 0;

                // Kiểm tra nếu ParentId là null
                long? parentId = row[3] != DBNull.Value ? (long?)Convert.ToInt64(row[3]) : null;

                // Tạo đối tượng TieuChiDanhGiaDTO
                TieuChiDanhGiaDTO tieuChi = new TieuChiDanhGiaDTO(
                    id,
                    name,
                    diemMax,
                    parentId ?? 0,  // Nếu parentId là null, dùng giá trị mặc định là 0
                    null,           // Nếu không có CreatedAt trong câu SQL
                    null            // Nếu không có UpdatedAt trong câu SQL
                );

                tieuChiList.Add(tieuChi);
            }

            return tieuChiList;
        }
    }
}
