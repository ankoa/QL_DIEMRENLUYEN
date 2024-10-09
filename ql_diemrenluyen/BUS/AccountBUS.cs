using ql_diemrenluyen.DAO;
using ql_diemrenluyen.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
