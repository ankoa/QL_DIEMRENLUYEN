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
                    Role = Convert.ToInt32(row[1]), // Role
                    Password = Convert.ToString(row[2]), // Password
                    RememberToken = Convert.ToString(row[3]), // RememberToken
                    CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null, // CreatedAt
                    UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null, // UpdatedAt
                    Status = Convert.ToInt32(row[6]) // Status
                };

                accounts.Add(account);
            }

            return accounts;
        }

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
            string sql = $"UPDATE account SET Role = @role, Password = @password, RememberToken = @rememberToken, " +
                         $"CreatedAt = @createdAt, UpdatedAt = @updatedAt, Status = @status WHERE Id = @id";

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
            string sql = $"DELETE FROM account WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
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

                // Kiểm tra mật khẩu đã mã hóa với mật khẩu người dùng nhập.
                //if (BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword))
                //{
                return new AccountDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    Role = Convert.ToInt32(row[1]),
                    Password = hashedPassword,
                    RememberToken = Convert.ToString(row[3]),
                    CreatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                    UpdatedAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                    Status = Convert.ToInt32(row[6])
                };
                //}
            }

            return null; // Trả về null nếu đăng nhập không thành công.
        }


    }
}
