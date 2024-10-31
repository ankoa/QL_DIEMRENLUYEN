namespace ql_diemrenluyen.DTO
{
    public class PasswordResetDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        public int IsUsed { get; set; }

        public PasswordResetDTO() { }

        public PasswordResetDTO(int id, string email, string token, DateTime? createdAt, DateTime? updatedAt, int isUsed)
        {
            this.Id = id;
            this.Email = email;
            this.Token = token;
            this.CreatedAt = createdAt;
            /*this.UpdatedAt = updatedAt;*/
            this.IsUsed = isUsed;
        }
    }
}
