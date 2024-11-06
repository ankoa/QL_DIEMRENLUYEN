using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.DAO
{
    public class AccountDAO
    {
        // Lấy tất cả tài khoản
        public static List<AccountDTO> GetAllAccounts()
        {
            List<AccountDTO> accounts = new List<AccountDTO>();
            string sql = "SELECT * FROM account"; // Thay đổi câu lệnh SQL nếu cần

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                AccountDTO account = new AccountDTO
                {
                    Id = Convert.ToInt64(row[0]), // id
                    Role = Convert.ToString(row[1]), // vaitro
                    Password = Convert.ToString(row[2]), // password
                    RememberToken = row[3] != DBNull.Value ? Convert.ToString(row[3]) : null, // remember_token
                    CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null, // created_at
                    UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null, // updated_at
                    Status = Convert.ToInt32(row[6]) // status
                };

                accounts.Add(account);
            }

            return accounts;
        }

        ////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
        ////AIzaSyCh9ySK3dqjXAvbWZ-rcukKsjY5oBuCar8
        //public static List<TieuChiDanhGiaDTO> XuatAllTieuChiDanhGia()
        //{
        //    List<TieuChiDanhGiaDTO> tieuChiList = new List<TieuChiDanhGiaDTO>();
        //    string sql = "SELECT \r\n    CASE \r\n        WHEN tc1.parent_id IS NULL THEN \r\n            CONCAT(tc1.id, '. ', tc1.name)  -- Đánh số la mã hoặc số nguyên cho mục cha\r\n        ELSE \r\n            CONCAT(tc1.parent_id, '.', tc1.id, ' ', tc1.name)  -- Đánh số thập phân cho mục con\r\n    END AS name,\r\n    tc1.diem_max AS diem_max,\r\n    tc1.id AS id,\r\n    tc1.parent_id AS parent_id\r\nFROM tieuchidanhgia tc1\r\nORDER BY COALESCE(tc1.parent_id, tc1.id), tc1.parent_id, tc1.id;\r\n"; // Câu lệnh SQL

        //    List<List<object>> result = DBConnection.ExecuteReader(sql);

        //    foreach (var row in result)
        //    {
        //        TieuChiDanhGiaDTO tieuChi = new TieuChiDanhGiaDTO(
        //            Convert.ToInt64(row[0]),
        //            Convert.ToString(row[1]),
        //            Convert.ToInt32(row[2]),
        //            Convert.ToInt64(row[3]),
        //            row[4] != null ? (DateTime?)Convert.ToDateTime(row[4]) : null,
        //            row[5] != null ? (DateTime?)Convert.ToDateTime(row[5]) : null
        //        );

        //        tieuChiList.Add(tieuChi);
        //    }

        //    return tieuChiList;
        //}

        public static bool AddAccount(AccountDTO account)
        {

            try
            {
                string sql = "INSERT INTO account (vaitro, password, remember_token, created_at, updated_at, status) " +
                             "VALUES (@role, @password, @rememberToken, @createdAt, @updatedAt, @status)";

                string hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(account.Password, 13); // Hash password

                using (var cmd = new MySqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@role", account.Role);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@rememberToken", account.RememberToken ?? (object)DBNull.Value); // Handle null
                    cmd.Parameters.AddWithValue("@createdAt", account.CreatedAt ?? DateTime.Now); // Set default if null
                    cmd.Parameters.AddWithValue("@updatedAt", account.UpdatedAt ?? DateTime.Now); // Set default if null
                    cmd.Parameters.AddWithValue("@status", account.Status);

                    return DBConnection.ExecuteNonQuery(cmd) > 0; // Return true if success
                }
            }
            catch (MySqlException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        // Cập nhật thông tin tài khoản
        public static bool UpdateAccount(AccountDTO account)
        {
            string sql = $"UPDATE account SET vaitro = @role, password = @password, remember_token = @rememberToken, " +
                         $"created_at = @createdAt, updated_at = @updatedAt, status = @status WHERE id = @id";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", account.Id);
            cmd.Parameters.AddWithValue("@role", account.Role);
            cmd.Parameters.AddWithValue("@password", account.Password);
            cmd.Parameters.AddWithValue("@rememberToken", account.RememberToken);
            cmd.Parameters.AddWithValue("@createdAt", account.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", account.UpdatedAt);
            cmd.Parameters.AddWithValue("@status", account.Status);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }



        // Xóa tài khoản
        public static bool DeleteAccount(long id)
        {
            string sql = $"DELETE FROM account WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }
        // Tìm kiếm tài khoản theo nhiều tiêu chí
        public static List<AccountDTO> SearchAccounts(string role, int status, string search)
        {
            List<AccountDTO> accounts = new List<AccountDTO>();

            string sql = @"
        SELECT * FROM account
        WHERE
            (@role = '' OR vaitro = @role)
            AND (@status = -1 OR status = @status)
            AND (
                id LIKE @search
                OR vaitro LIKE @search
            )";

            using (var cmd = new MySqlCommand(sql))
            {
                // Thêm giá trị cho các tham số truy vấn
                cmd.Parameters.AddWithValue("@role", string.IsNullOrEmpty(role) ? "" : role);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@search", $"%{search}%");

                // Sử dụng ExecuteReader để thực thi truy vấn và lấy kết quả
                List<List<object>> result = DBConnection.ExecuteReader(cmd);

                // Duyệt qua từng dòng kết quả và ánh xạ sang đối tượng `AccountDTO`
                foreach (var row in result)
                {
                    AccountDTO account = new AccountDTO
                    {
                        Id = Convert.ToInt64(row[0]), // id
                        Role = Convert.ToString(row[1]), // vaitro
                        Password = Convert.ToString(row[2]), // password
                        RememberToken = row[3] != DBNull.Value ? Convert.ToString(row[3]) : null, // remember_token
                        CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null, // created_at
                        UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null, // updated_at
                        Status = Convert.ToInt32(row[6]) // status
                    };

                    accounts.Add(account);
                }
            }

            return accounts;
        }




        public static void PrintAllAccounts()
        {
            List<AccountDTO> accounts = GetAllAccounts(); // Lấy tất cả tài khoản

            // Kiểm tra nếu danh sách không rỗng
            if (accounts.Count > 0)
            {
                foreach (var account in accounts)
                {
                    // In thông tin tài khoản ra console
                    Console.WriteLine($"ID: {account.Id}, Role: {account.Role}, Password: {account.Password}, " +
                                      $"Remember Token: {account.RememberToken}, Created At: {account.CreatedAt}, " +
                                      $"Updated At: {account.UpdatedAt}, Status: {account.Status}");
                }
            }
            else
            {
                Console.WriteLine("Không có tài khoản nào trong cơ sở dữ liệu.");
            }
        }


        public static AccountDTO Login(string username, string plainPassword)
        {
            string sql = $"SELECT * FROM account WHERE id = @username";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@username", username);

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                var row = result[0];
                string hashedPassword = Convert.ToString(row[2]);

                //Kiểm tra mật khẩu đã mã hóa với mật khẩu người dùng nhập.
                if (BCrypt.Net.BCrypt.EnhancedVerify(plainPassword, hashedPassword))
                {
                    return new AccountDTO
                    {
                        Id = Convert.ToInt64(row[0]),
                        Role = Convert.ToString(row[1]),
                        Password = hashedPassword,
                        RememberToken = Convert.ToString(row[3]),
                        CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                        UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                        Status = Convert.ToInt32(row[6])
                    };
                }
            }

            return null; // Trả về null nếu đăng nhập không thành công.
        }

        //Đổi mật khẩu
        public static bool ChangePassword(long userId, string newPassword)
        {
            try
            {
                // Hash mật khẩu mới
                string newHashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(newPassword, 13);

                // Cập nhật mật khẩu mới
                string updateSql = "UPDATE account SET password = @newPassword, updated_at = @updatedAt WHERE id = @userId";
                var updateCmd = new MySqlCommand(updateSql);
                updateCmd.Parameters.AddWithValue("@newPassword", newHashedPassword);
                updateCmd.Parameters.AddWithValue("@updatedAt", DateTime.Now);
                updateCmd.Parameters.AddWithValue("@userId", userId);

                int rowsAffected = DBConnection.ExecuteNonQuery(updateCmd);

                if (rowsAffected > 0)
                {
                    return true; // Đổi mật khẩu thành công
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật mật khẩu");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
                return false;
            }
        }



    }
}
