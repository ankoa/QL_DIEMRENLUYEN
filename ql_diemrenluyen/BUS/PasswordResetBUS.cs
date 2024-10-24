using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class PasswordResetBUS
    {
        // Thêm yêu cầu đặt lại mật khẩu
        public bool AddPasswordReset(string email, string token)
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
        public bool DeletePasswordReset(long id)
        {
            return PasswordResetDAO.DeletePasswordReset(id);
        }

        // Xác thực mã thông báo đặt lại mật khẩu
        /*public PasswordResetDTO VerifyToken(string token)
        {
            return PasswordResetDAO.VerifyPasswordResetToken(token);
        }*/
    }
}
