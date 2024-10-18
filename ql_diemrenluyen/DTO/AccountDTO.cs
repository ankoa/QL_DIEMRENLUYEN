using System;

namespace ql_diemrenluyen.DTO
{
    public class AccountDTO
    {
        public long Id { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string RememberToken { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Status { get; set; }

        public AccountDTO() { }

        public AccountDTO(long id, string role, string password, string rememberToken, DateTime? createdAt, DateTime? updatedAt, int status)
        {
            this.Id = id;
            this.Role = role;
            this.Password = password;
            this.RememberToken = rememberToken;
            this.CreatedAt = createdAt;
            this.UpdatedAt = updatedAt;
            this.Status = status;
        }
    }
}
