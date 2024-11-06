using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;

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

        // Thêm tài khoản mới
        public static bool AddAccount(AccountDTO account)
        {
            string sql = $"INSERT INTO account (vaitro, password, remember_token, created_at, updated_at, status) " +
                         $"VALUES (@role, @password, @rememberToken, @createdAt, @updatedAt, @status)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@role", account.Role);
            cmd.Parameters.AddWithValue("@password", account.Password);
            cmd.Parameters.AddWithValue("@rememberToken", account.RememberToken);
            cmd.Parameters.AddWithValue("@createdAt", account.CreatedAt);
            cmd.Parameters.AddWithValue("@updatedAt", account.UpdatedAt);
            cmd.Parameters.AddWithValue("@status", account.Status);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
        }

        // Thêm tài khoản mới khi thêm sinh viên
        public static bool AddAccountSV(AccountDTO account)
        {
            string sql = $"INSERT INTO account (id, vaitro, password, remember_token, created_at, updated_at, status) " +
                         $"VALUES (@id, @role, @password, @rememberToken, @createdAt, @updatedAt, @status)";

            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", account.Id);
            cmd.Parameters.AddWithValue("@role", "Sinh viên");
            cmd.Parameters.AddWithValue("@password", account.Password);
            cmd.Parameters.AddWithValue("@rememberToken", null);
            cmd.Parameters.AddWithValue("@createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@updatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            cmd.Parameters.AddWithValue("@status", 1);

            return DBConnection.ExecuteNonQuery(cmd) > 0;
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
    }
}
