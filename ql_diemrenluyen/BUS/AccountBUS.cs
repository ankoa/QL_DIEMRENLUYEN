using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class AccountBUS
    {
        // Lấy danh sách tất cả tài khoản
        public static List<AccountDTO> GetAllAccounts()
        {
            try
            {
                return AccountDAO.GetAllAccounts();
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (nếu cần) và trả về giá trị null hoặc một danh sách rỗng
                Console.WriteLine($"Error retrieving accounts: {ex.Message}");
                return new List<AccountDTO>(); // Hoặc return null;
            }
        }

        // Thêm tài khoản mới
        public static bool AddAccount(AccountDTO account)
        {
            try
            {
                return AccountDAO.AddAccount(account);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (nếu cần)
                Console.WriteLine($"Error adding account: {ex.Message}");
                return false; // Hoặc có thể throw exception để xử lý ở nơi khác
            }
        }

        // Cập nhật thông tin tài khoản
        public static bool UpdateAccount(AccountDTO account)
        {
            try
            {
                return AccountDAO.UpdateAccount(account);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (nếu cần)
                Console.WriteLine($"Error updating account: {ex.Message}");
                return false; // Hoặc có thể throw exception để xử lý ở nơi khác
            }
        }

        // Xóa tài khoản
        public static bool DeleteAccount(long id)
        {
            try
            {
                return AccountDAO.DeleteAccount(id);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi (nếu cần)
                Console.WriteLine($"Error deleting account with ID {id}: {ex.Message}");
                return false; // Hoặc có thể throw exception để xử lý ở nơi khác
            }
        }
        // Tìm kiếm tài khoản theo tiêu chí
        public static List<AccountDTO> SearchAccounts(string role, int status, string keyword)
        {
            try
            {
                // Call the AccountDAO method with the status as int
                return AccountDAO.SearchAccounts(role, status, keyword);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching accounts: {ex.Message}");
                return new List<AccountDTO>();
            }

        }
        //Login
        public static AccountDTO Login(string username, string plainPassword)
        {
            return AccountDAO.Login(username, plainPassword);
        }

        public static (object account, string accountType) findAccountByEmail(string email)
        {
            if (email == null)
            {
                return (null, null);
            }

            SinhVienDTO sv = SinhVienDAO.GetStudentByEmail(email);
            if (sv != null)
            {
                return (sv, "Sinh viên");
            }

            GiangVienDTO gv = GiangVienDAO.GetGiangVienByEmail(email);
            if (gv != null)
            {
                return (gv, "Giảng viên");
            }

            return (null, null);
        }

        public static bool ChangePassword(long userId, string oldPassword, string newPassword)
        {
            return AccountDAO.ChangePassword(userId, oldPassword, newPassword);
        }

    }
}
