using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class PasswordResetBUS
    {
        // Thêm yêu cầu đặt lại mật khẩu
        public static bool AddPasswordReset(string email, string token)
        {
            var passwordReset = new PasswordResetDTO
            {
                Email = email,
                Token = token,
                IsUsed = 0 // Đặt trạng thái là chưa sử dụng
            };

            return PasswordResetDAO.AddPasswordReset(passwordReset);
        }

        // Lấy tất cả yêu cầu đặt lại mật khẩu
        public List<PasswordResetDTO> GetAllPasswordResets()
        {
            return PasswordResetDAO.GetAllPasswordResets();
        }

        // Xóa yêu cầu đặt lại mật khẩu
        public bool DeletePasswordReset(int id)
        {
            return PasswordResetDAO.DeletePasswordReset(id);
        }

        // Xác thực mã thông báo đặt lại mật khẩu
        public static PasswordResetDTO VerifyToken(string email, string token)
        {
            return PasswordResetDAO.VerifyPasswordResetToken(email, token);
        }

        // Đánh dấu đã dùng OTP
        public static bool MarkOTPAsUsed(int id)
        {
            return PasswordResetDAO.MarkOTPAsUsed(id); // Trả về true nếu cập nhật thành công
        }

    }
}
