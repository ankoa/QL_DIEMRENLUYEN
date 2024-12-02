using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.DAO
{
    public class GiangVienDAO
    {
        public static List<GiangVienDTO> GetAllGiangVien()
        {
            List<GiangVienDTO> giangViens = new List<GiangVienDTO>();
            string sql = "SELECT * FROM giangvien";

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                GiangVienDTO giangVien = new GiangVienDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    Name = Convert.ToString(row[1]),
                    Email = Convert.ToString(row[2]),

                    CreatedAt = row[3] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null,
                    UpdatedAt = row[4] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null,
                    KhoaId = Convert.ToInt32(row[5]),
                    NgaySinh = Convert.ToDateTime(row[6]),
                    GioiTinh = Convert.ToInt32(row[7]),
                    Status = Convert.ToInt32(row[8])

                };

                giangViens.Add(giangVien);
            }

            return giangViens;
        }

        // Thêm giảng viên mới

        public static bool AddGiangVien(GiangVienDTO giangVien)
        {

            string sql = $"INSERT INTO giangvien (name, email, created_at, updated_at, khoa_id ,ngaysinh, gioitinh, status) " +
                        $"VALUES (@name, @email, @createdAt, @updatedAt, @khoaId, @ngaySinh, @gioiTinh, @status )";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@name", giangVien.Name);
            cmd.Parameters.AddWithValue("@email", giangVien.Email);
            cmd.Parameters.AddWithValue("@createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@khoaId", giangVien.KhoaId);
            cmd.Parameters.AddWithValue("@ngaySinh", giangVien.NgaySinh.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@gioiTinh", giangVien.GioiTinh);
            cmd.Parameters.AddWithValue("@status", giangVien.Status);

            try
            {
                bool isGiangVienAdded = DBConnection.ExecuteNonQuery(cmd) > 0;
                if (isGiangVienAdded)
                {
                    //long giangVienId = GetLastInsertedId();
                    //string password = "1";
                    //return AddAccount(giangVienId, password);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm giảng viên: " + ex.Message);
            }

            return false;
        }
        public static bool AddGiangVienByExcel(GiangVienDTO giangVien)
        {

            string sql = $"INSERT INTO giangvien (id, name, email, created_at, updated_at, khoa_id ,ngaysinh, gioitinh, status) " +
                        $"VALUES (@id, @name, @email, @createdAt, @updatedAt, @khoaId, @ngaySinh, @gioiTinh, @status )";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", giangVien.Id);
            cmd.Parameters.AddWithValue("@name", giangVien.Name);
            cmd.Parameters.AddWithValue("@email", giangVien.Email);
            cmd.Parameters.AddWithValue("@createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@khoaId", giangVien.KhoaId);
            cmd.Parameters.AddWithValue("@ngaySinh", giangVien.NgaySinh.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@gioiTinh", giangVien.GioiTinh);
            cmd.Parameters.AddWithValue("@status", giangVien.Status);

            try
            {
                bool isGiangVienAdded = DBConnection.ExecuteNonQuery(cmd) > 0;
                if (isGiangVienAdded)
                {
                    //long giangVienId = GetLastInsertedId();
                    //string password = "1";
                    //return AddAccount(giangVienId, password);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm giảng viên: " + ex.Message);
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
            string sql = @"
        UPDATE giangvien
        SET name = @name,
            email = @email, 
            created_at = @createdAt,
            updated_at = @updatedAt,
            khoa_id = @khoaId,
            ngaysinh = @ngaySinh,      -- Thêm trường NgaySinh
            gioitinh = @gioiTinh,      -- Thêm trường GioiTinh
            status = @status
        WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", giangVien.Id);
            cmd.Parameters.AddWithValue("@name", giangVien.Name);
            cmd.Parameters.AddWithValue("@email", giangVien.Email);
            cmd.Parameters.AddWithValue("@createdAt", giangVien.CreatedAt ?? DateTime.Now);
            cmd.Parameters.AddWithValue("@updatedAt", giangVien.UpdatedAt ?? DateTime.Now);
            cmd.Parameters.AddWithValue("@khoaId", giangVien.KhoaId);
            cmd.Parameters.AddWithValue("@ngaySinh", giangVien.NgaySinh);      // Thêm tham số NgaySinh
            cmd.Parameters.AddWithValue("@gioiTinh", giangVien.GioiTinh);      // Thêm tham số GioiTinh
            cmd.Parameters.AddWithValue("@status", giangVien.Status);

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

            return null;
        }


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
                    Id = Convert.ToInt32(row[0]),
                    Name = Convert.ToString(row[1]),
                    Email = Convert.ToString(row[2]),
                    CreatedAt = row[3] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null,
                    UpdatedAt = row[4] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null,
                    KhoaId = Convert.ToInt32(row[5]),
                    Status = Convert.ToInt32(row[6])
                };

                giangViens.Add(giangVien);
            }

            return giangViens;
        }


        //public static List<GiangVienDTO> SearchGiangVienByChucVu(string chucVu)
        //{
        //    List<GiangVienDTO> giangViens = new List<GiangVienDTO>();
        //    string sql = "SELECT * FROM giangvien WHERE chucvu = @chucVu";

        //    var cmd = new MySqlCommand(sql);
        //    cmd.Parameters.AddWithValue("@chucVu", chucVu);

        //    List<List<object>> result = DBConnection.ExecuteReader(cmd);

        //    foreach (var row in result)
        //    {
        //        GiangVienDTO giangVien = new GiangVienDTO
        //        {
        //            Id = Convert.ToInt32(row[0]),
        //            Name = Convert.ToString(row[1]),
        //            Email = Convert.ToString(row[2]),
        //            CreatedAt = row[4] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null,
        //            UpdatedAt = row[5] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null,
        //            ChucVu = Convert.ToInt32(row[5]),
        //            KhoaId = Convert.ToInt32(row[6]),
        //            Status = Convert.ToInt32(row[7])
        //        };

        //        giangViens.Add(giangVien);
        //    }

        //    return giangViens;
        //}

        public static List<GiangVienDTO> GetGiangVienByKhoaId(long khoaId)
        {
            List<GiangVienDTO> giangViens = new List<GiangVienDTO>();
            string sql = "SELECT * FROM giangvien WHERE khoa_id = @khoaId";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@khoaId", khoaId);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            foreach (var row in result)
            {
                GiangVienDTO giangVien = new GiangVienDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    Name = Convert.ToString(row[1]),
                    Email = Convert.ToString(row[2]),
                    CreatedAt = row[3] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null,
                    UpdatedAt = row[4] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null,
                    KhoaId = Convert.ToInt32(row[5]),
                    NgaySinh = Convert.ToDateTime(row[6]),
                    GioiTinh = Convert.ToInt32(row[7]),
                    Status = Convert.ToInt32(row[8])
                };

                giangViens.Add(giangVien);
            }

            return giangViens;
        }


        private static GiangVienDTO MapToGiangVienDTO(List<object> row)
        {
            return new GiangVienDTO
            {
                Id = Convert.ToInt32(row[0]),
                Name = Convert.ToString(row[1]),
                Email = Convert.ToString(row[2]),
                CreatedAt = row[3] != null ? Convert.ToDateTime(row[3]) : (DateTime?)null,
                UpdatedAt = row[4] != null ? Convert.ToDateTime(row[4]) : (DateTime?)null,
                KhoaId = Convert.ToInt32(row[5]),
                NgaySinh = Convert.ToDateTime(row[6]),
                GioiTinh = Convert.ToInt32(row[7]),
                Status = Convert.ToInt32(row[8])
            };
        }

    }
}
