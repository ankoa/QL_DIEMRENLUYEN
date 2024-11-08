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
            string sql = "SELECT * FROM password_reset"; // Thay đổi câu lệnh SQL nếu cần

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
                string sql = "INSERT INTO password_reset (email, token, created_at, expired_at, isUsed) " +
                             "VALUES (@Email, @Token, @CreatedAt, @ExpiredAt, @IsUsed)";

                // Thiết lập thời gian tạo và hết hạn
                passwordReset.CreatedAt = DateTime.UtcNow;
                passwordReset.ExpiredAt = passwordReset.CreatedAt.Value.AddMinutes(1);

                using (var cmd = new MySqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@Email", passwordReset.Email);
                    cmd.Parameters.AddWithValue("@Token", passwordReset.Token);
                    cmd.Parameters.AddWithValue("@CreatedAt", passwordReset.CreatedAt);
                    cmd.Parameters.AddWithValue("@ExpiredAt", passwordReset.ExpiredAt);
                    cmd.Parameters.AddWithValue("@IsUsed", passwordReset.IsUsed);

                    int result = DBConnection.ExecuteNonQuery(cmd);
                    if (result > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Lỗi MySQL: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khác: {ex.Message}");
                return false;
            }
        }


        // Xóa yêu cầu đặt lại mật khẩu
        public static bool DeletePasswordReset(int id)
        {
            string sql = "DELETE FROM password_reset WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            return DBConnection.ExecuteNonQuery(cmd) > 0; // Trả về true nếu thành công
        }

        // Đánh dấu đã dùng OTP
        public static bool MarkOTPAsUsed(int id)
        {
            string sql = "UPDATE password_reset SET isUsed = 1 WHERE id = @id";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@id", id);

            int rowsAffected = DBConnection.ExecuteNonQuery(cmd);
            return rowsAffected > 0; // Trả về true nếu cập nhật thành công
        }


        // Xác thực mã thông báo đặt lại mật khẩu
        public static PasswordResetDTO VerifyPasswordResetToken(string email, string token)
        {
            string sql = "SELECT id, email, token, created_at, expired_at, isUsed FROM password_reset WHERE email=@email AND token = @token AND isUsed = 0 AND expired_at > @currentTime";
            var cmd = new MySqlCommand(sql);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@token", token);
            cmd.Parameters.AddWithValue("@currentTime", DateTime.UtcNow); // Thời gian hiện tại

            List<List<object>> result = DBConnection.ExecuteReader(cmd);

            if (result.Count > 0)
            {
                var row = result[0];
                return new PasswordResetDTO
                {
                    Id = Convert.ToInt32(row[0]),
                    Email = Convert.ToString(row[1]),
                    Token = Convert.ToString(row[2]),
                    CreatedAt = row[3] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[3]) : null,
                    ExpiredAt = row[4] != DBNull.Value ? (DateTime?)Convert.ToDateTime(row[4]) : null,
                    IsUsed = Convert.ToInt32(row[5])
                };
            }
            return null; // Trả về null nếu không tìm thấy
        }

    }
}