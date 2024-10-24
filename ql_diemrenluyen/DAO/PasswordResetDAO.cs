using MySql.Data.MySqlClient;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.DAO
{
    public class PasswordResetDAO
    {
        // Lấy tất cả yêu cầu đặt lại mật khẩu
        public static List<PasswordResetDTO> GetAllPasswordResets()
        {
            List<PasswordResetDTO> passwordResets = new List<PasswordResetDTO>();
            string sql = "SELECT * FROM PasswordResets"; // Thay đổi câu lệnh SQL nếu cần

            List<List<object>> result = DBConnection.ExecuteReader(sql);

            foreach (var row in result)
            {
                PasswordResetDTO passwordReset = new PasswordResetDTO
                {
                    Id = Convert.ToInt32(row[0]), // id
                    Email = Convert.ToString(row[1]), // Email
                    Token = Convert.ToString(row[2]), // Token
                    CreatedAt = row[3] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[3]) : null, // CreatedAt
                    ExpiredAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null, // ExpiredAt
                    IsUsed = Convert.ToInt32(row[5]) // IsUsed
                };

                passwordResets.Add(passwordReset);
            }

            return passwordResets;
        }

        // Thêm yêu cầu đặt lại mật khẩu
        public static bool AddPasswordReset(PasswordResetDTO passwordReset)
        {
            try
            {
                string sql = "INSERT INTO password_reset (email, token, created_at, expired_ad, isUsed) " +
                             "VALUES (@Email, @Token, @CreatedAt, @UpdatedAt, @ExpiredAt, @IsUsed)";

                // Lấy thời gian UTC hiện tại và thiết lập thời gian hết hạn
                passwordReset.CreatedAt = DateTime.UtcNow;
                passwordReset.ExpiredAt = passwordReset.CreatedAt.Value.AddMinutes(1); // Thêm 1 phút

                using (var cmd = new MySqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@Email", passwordReset.Email);
                    cmd.Parameters.AddWithValue("@Token", passwordReset.Token);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@ExpiredAt", DateTime.UtcNow.AddMinutes(1));
                    cmd.Parameters.AddWithValue("@IsUsed", passwordReset.IsUsed);

                    return DBConnection.ExecuteNonQuery(cmd) > 0; // Trả về true nếu thành công
                }
            }
            catch (MySqlException ex)
            {
                // Xử lý ngoại lệ nếu cần
                return false;
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                return false;
            }
        }

        // Xóa yêu cầu đặt lại mật khẩu
        public static bool DeletePasswordReset(long id)
        {
            string sql = "DELETE FROM PasswordResets WHERE Id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0; // Trả về true nếu thành công
        }

        // Xác thực mã thông báo đặt lại mật khẩu
        public static PasswordResetDTO VerifyPasswordResetToken(string token)
        {
            string sql = "SELECT * FROM PasswordResets WHERE Token = @token AND IsUsed = 0 AND ExpiredAt > @currentTime";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@token", token);
            cmd.Parameters.AddWithValue("@currentTime", DateTime.UtcNow); // Thời gian hiện tại

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                var row = result[0];
                return new PasswordResetDTO
                {
                    Id = Convert.ToInt64(row[0]),
                    Email = Convert.ToString(row[1]),
                    Token = Convert.ToString(row[2]),
                    CreatedAt = row[3] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[3]) : null,
                    UpdatedAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                    ExpiredAt = row[5] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[5]) : null,
                    IsUsed = Convert.ToInt32(row[6])
                };
            }

            return null; // Trả về null nếu không tìm thấy
        }
    }
}
