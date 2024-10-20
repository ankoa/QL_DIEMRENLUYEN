using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;

namespace ql_diemrenluyen.BUS
{
    public class AccountBUS
    {
        // Lấy danh sách tất cả tài khoản
        public static List<AccountDTO> GetAllAccounts()
        {
            return AccountDAO.GetAllAccounts();
        }

        // Thêm tài khoản mới
        public static bool AddAccount(AccountDTO account)
        {
            return AccountDAO.AddAccount(account);
        }

        // Cập nhật thông tin tài khoản
        public static bool UpdateAccount(AccountDTO account)
        {
            return AccountDAO.UpdateAccount(account);
        }

        // Xóa tài khoản
        public static bool DeleteAccount(long id)
        {
            return AccountDAO.DeleteAccount(id);
        }

        //Login
        public static AccountDTO Login(string username, string plainPassword)
        {
            return AccountDAO.Login(username, plainPassword);
        }

        public static Object findAccountByEmail(string email)
        {
            if (email == null)
            {
                return null;
            }
            SinhVienDTO sv = SinhVienDAO.GetStudentByEmail(email);
            if (sv != null)
            {
                return sv;
            }
            GiangVienDTO gv = GiangVienDAO.GetGiangVienByEmail(email);
            if (gv != null)
            {
                return sv;
            }
            return null;
        }

    }
}
