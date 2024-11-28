using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;
using CloudinaryDotNet.Core;

namespace ql_diemrenluyen.DAO
{
    public class ThongTinDotChamDAO
    {
        // Lấy tất cả thông tin đợt chấm điểm
        public static List<ThongTinDotChamDTO> GetAllThongTinDotChamDiem()
        {
            List<ThongTinDotChamDTO> thongTinList = new List<ThongTinDotChamDTO>();
            string sql = "SELECT * FROM thongtindotchamdiem"; // Câu lệnh SQL

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                ThongTinDotChamDTO thongTin = new ThongTinDotChamDTO(
                    Convert.ToInt64(row[0]),
                    Convert.ToInt32(row[1]),
                    row[2] != null ? (long?)Convert.ToInt64(row[2]) : null,
                    Convert.ToInt64(row[3]),
                    row[4] != null ? (long?)Convert.ToInt64(row[4]) : null,
                    Convert.ToInt32(row[5]),
                    Convert.ToInt32(row[6]),
                    Convert.ToInt32(row[7]),
                    row[8] != DBNull.Value ? (int?)Convert.ToInt32(row[8]) : null,  // KetQua
                    row[9] != DBNull.Value ? row[9].ToString() : null  // DanhGia
                );

                thongTinList.Add(thongTin);
            }

            return thongTinList;
        }

        // Thêm thông tin đợt chấm điểm mới
        public static bool AddThongTinDotCham(ThongTinDotChamDTO thongTin)
        {
            string sql = "INSERT INTO thongtindotchamdiem (dotchamdiem_id, covan_id, sinhvien_id, khoa_id, final, hoanthanh, status) " +
                         "VALUES (@dotChamDiemId, @coVanId, @sinhVienId, @khoaId, @final, @hoanThanh, @status, @ketQua, @danhGia)";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@dotChamDiemId", thongTin.DotChamDiemId);
            cmd.Parameters.AddWithValue("@coVanId", (object)thongTin.CoVanId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@sinhVienId", thongTin.SinhVienId);
            cmd.Parameters.AddWithValue("@khoaId", (object)thongTin.KhoaId ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@final", thongTin.Final);
            cmd.Parameters.AddWithValue("@hoanThanh", thongTin.HoanThanh);
            cmd.Parameters.AddWithValue("@status", thongTin.Status);
            cmd.Parameters.AddWithValue("@ketQua", (object)thongTin.KetQua ?? DBNull.Value);  // Thêm KetQua
            cmd.Parameters.AddWithValue("@danhGia", (object)thongTin.DanhGia ?? DBNull.Value);  // Thêm DanhGia

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Cập nhật thông tin đợt chấm điểm
        //public static bool UpdateThongTinDotCham(ThongTinDotChamDTO thongTin)
        //{
        //    string sql = "UPDATE thongtindotchamdiem SET dotchamdiem_id = @dotChamDiemId, covan_id = @coVanId, " +
        //                 "sinhvien_id = @sinhVienId, khoa_id = @khoaId, final = @final, hoanthanh = @hoanThanh, status = @status " +
        //                 "WHERE id = @id";
        //    var cmd = new MySqlCommand(sql);
        //    cmd.Parameters.AddWithValue("@id", thongTin.Id);
        //    cmd.Parameters.AddWithValue("@dotChamDiemId", thongTin.DotChamDiemId);
        //    cmd.Parameters.AddWithValue("@coVanId", (object)thongTin.CoVanId ?? DBNull.Value);
        //    cmd.Parameters.AddWithValue("@sinhVienId", thongTin.SinhVienId);
        //    cmd.Parameters.AddWithValue("@khoaId", (object)thongTin.KhoaId ?? DBNull.Value);
        //    cmd.Parameters.AddWithValue("@final", thongTin.Final);
        //    cmd.Parameters.AddWithValue("@hoanThanh", thongTin.HoanThanh);
        //    cmd.Parameters.AddWithValue("@status", thongTin.Status);

        //    return DBConnection.ExecuteNonQuery(cmd) > 0;
        //}
        public static bool UpdateThongTinDotCham(int dotChamDiemId, string role, long sinhVienId, long nguoiChamId, int? ketQua, string danhGia)
        {
            string sql = string.Empty;
            var cmd = new MySqlCommand();

            // Xử lý logic cập nhật dựa vào role
            if (role == "Sinh viên")
            {
                sql = "UPDATE thongtindotchamdiem SET hoanthanh = 1, ketqua = @ketQua, danhgia = @danhGia " +
                      "WHERE dotchamdiem_id = @dotChamDiemId AND sinhvien_id = @sinhVienId AND sinhvien_id = @nguoiChamId";
                cmd.Parameters.AddWithValue("@dotChamDiemId", dotChamDiemId);
                cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);
                cmd.Parameters.AddWithValue("@nguoiChamId", nguoiChamId);
            }
            else if (role == "Cố vấn")
            {
                sql = "UPDATE thongtindotchamdiem SET covan_id = @nguoiChamId, hoanthanh = 1, ketqua = @ketQua, danhgia = @danhGia " +
                      "WHERE dotchamdiem_id = @dotChamDiemId AND sinhvien_id = @sinhVienId";
                cmd.Parameters.AddWithValue("@dotChamDiemId", dotChamDiemId);
                cmd.Parameters.AddWithValue("@nguoiChamId", nguoiChamId);
                cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);
            }
            else if (role == "Khoa")
            {
                sql = "UPDATE thongtindotchamdiem SET khoa_id = @nguoiChamId, hoanthanh = 1, ketqua = @ketQua, danhgia = @danhGia " +
                      "WHERE dotchamdiem_id = @dotChamDiemId AND sinhvien_id = @sinhVienId";
                cmd.Parameters.AddWithValue("@dotChamDiemId", dotChamDiemId);
                cmd.Parameters.AddWithValue("@nguoiChamId", nguoiChamId);
                cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);
            }
            else if (role == "Trường")
            {
                sql = "UPDATE thongtindotchamdiem SET final = 1, hoanthanh = 1, ketqua = @ketQua, danhgia = @danhGia " +
                      "WHERE dotchamdiem_id = @dotChamDiemId AND sinhvien_id = @sinhVienId";
                cmd.Parameters.AddWithValue("@dotChamDiemId", dotChamDiemId);
                cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);
            }
            else
            {
                throw new ArgumentException("Role không hợp lệ!");
            }

            // Thêm tham số cho ketQua và danhGia
            cmd.Parameters.AddWithValue("@ketQua", (object)ketQua ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@danhGia", (object)danhGia ?? DBNull.Value);

            cmd.CommandText = sql;
            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        public static long? GetThongTinDotChamId(long dotChamDiemId, string role, long sinhVienId, long nguoiChamId)
        {
            string sql = string.Empty;
            var cmd = new MySqlCommand();

            // Xử lý logic truy vấn dựa vào role
            if (role == "Sinh viên")
            {
                sql = "SELECT id FROM thongtindotchamdiem WHERE dotchamdiem_id = @dotChamDiemId AND sinhvien_id = @sinhVienId AND sinhvien_id = @nguoiChamId LIMIT 1";
                cmd.Parameters.AddWithValue("@dotChamDiemId", dotChamDiemId);
                cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);
                cmd.Parameters.AddWithValue("@nguoiChamId", nguoiChamId);
            }
            else if (role == "Cố vấn")
            {
                sql = "SELECT id FROM thongtindotchamdiem WHERE dotchamdiem_id = @dotChamDiemId AND sinhvien_id = @sinhVienId AND covan_id = @nguoiChamId LIMIT 1";
                cmd.Parameters.AddWithValue("@dotChamDiemId", dotChamDiemId);
                cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);
                cmd.Parameters.AddWithValue("@nguoiChamId", nguoiChamId);
            }
            else if (role == "Khoa")
            {
                sql = "SELECT id FROM thongtindotchamdiem WHERE dotchamdiem_id = @dotChamDiemId AND sinhvien_id = @sinhVienId AND khoa_id = @nguoiChamId LIMIT 1";
                cmd.Parameters.AddWithValue("@dotChamDiemId", dotChamDiemId);
                cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);
                cmd.Parameters.AddWithValue("@nguoiChamId", nguoiChamId);
            }
            else if (role == "Trường")
            {
                sql = "SELECT id FROM thongtindotchamdiem WHERE dotchamdiem_id = @dotChamDiemId AND sinhvien_id = @sinhVienId LIMIT 1";
                cmd.Parameters.AddWithValue("@dotChamDiemId", dotChamDiemId);
                cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);
            }
            else
            {
                throw new ArgumentException("Role không hợp lệ!");
            }

            cmd.CommandText = sql;
            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            // Nếu có kết quả, trả về id
            if (result.Count > 0)
            {
                return Convert.ToInt64(result[0][0]);
            }

            return null;  // Trả về null nếu không tìm thấy
        }
        //lấy id ThongTinDotChamDiem
        public static long? GetThongTinDotChamDiemId(int dotChamDiemId, long sinhVienId)
        {
            string sql = @"
        SELECT id 
        FROM thongtindotchamdiem 
        WHERE dotchamdiem_id = @dotChamDiemId 
          AND sinhvien_id = @sinhVienId 
          AND hoanthanh = 1 
        LIMIT 1";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@dotChamDiemId", dotChamDiemId);
            cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);

            object result = DBConnection.ExecuteScalar(cmd);

            // Nếu kết quả null, trả về null; nếu không, chuyển thành long
            return result != null ? Convert.ToInt64(result) : (long?)null;
        }

        public static ThongTinDotChamDTO GetThongTinDotChamDiemByDotChamDiemIdAndSinhVienId(int dotChamDiemId, long sinhVienId)
        {
            try
            {
                // Câu lệnh SQL để lấy thông tin
                string sql = @"
            SELECT id, dotchamdiem_id, covan_id, sinhvien_id, khoa_id, final, hoanthanh, status, ketqua, danhgia 
            FROM thongtindotchamdiem 
            WHERE dotchamdiem_id = @dotChamDiemId 
              AND sinhvien_id = @sinhVienId 
              AND hoanthanh = 1 
              AND status = 1
            LIMIT 1";

                // Tạo MySqlCommand và thêm tham số
                var cmd = new MySqlCommand(sql);
                cmd.Parameters.AddWithValue("@dotChamDiemId", dotChamDiemId);
                cmd.Parameters.AddWithValue("@sinhVienId", sinhVienId);

                // Mở kết nối và thực thi truy vấn
                List<List<object>> result = DBConnection.ExecuteReader(cmd);

                // Kiểm tra nếu có dữ liệu trả về
                if (result.Count > 0)
                {
                    var row = result[0];
                    return new ThongTinDotChamDTO(
                        id: Convert.ToInt64(row[0]),
                        dotChamDiemId: Convert.ToInt32(row[1]),
                        coVanId: row[2] != DBNull.Value ? (long?)Convert.ToInt64(row[2]) : null,
                        sinhVienId: Convert.ToInt64(row[3]),
                        khoaId: row[4] != DBNull.Value ? (long?)Convert.ToInt64(row[4]) : null,
                        final: Convert.ToInt32(row[5]),
                        hoanThanh: Convert.ToInt32(row[6]),
                        status: Convert.ToInt32(row[7]),
                        ketQua: row[8] != DBNull.Value ? (int?)Convert.ToInt32(row[8]) : null,
                        danhGia: row[9] != DBNull.Value ? row[9].ToString() : null
                    );
                }

                // Trả về null nếu không có dữ liệu
                return null;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                Console.WriteLine("Error in GetThongTinDotChamDiemByDotChamDiemIdAndSinhVienId: " + ex.Message);
                return null;
            }
        }

        public static string GetNguoiChamById(long id)
        {
            string sql = @"
        SELECT 
            covan_id, 
            sinhvien_id, 
            khoa_id, 
            final 
        FROM 
            thongtindotchamdiem 
        WHERE 
            id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                DBConnection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var coVanId = reader["covan_id"] as long?;
                        var sinhVienId = reader["sinhvien_id"] as long?;
                        var khoaId = reader["khoa_id"] as long?;
                        var final = Convert.ToInt32(reader["final"]);

                        if (sinhVienId.HasValue && !coVanId.HasValue && !khoaId.HasValue && final == 0)
                        {
                            return "Sinh viên";
                        }
                        else if (coVanId.HasValue)
                        {
                            return "Cố vấn";
                        }
                        else if (khoaId.HasValue)
                        {
                            return "Khoa";
                        }
                        else if (final == 1)
                        {
                            return "Trường";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                DBConnection.Close();
            }

            return null;
        }



        // Xóa thông tin đợt chấm điểm
        public static bool DeleteThongTinDotChamDiem(long id)
        {
            string sql = "DELETE FROM thongtindotchamdiem WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
    }
}

