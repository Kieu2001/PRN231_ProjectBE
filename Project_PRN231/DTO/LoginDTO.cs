namespace Project_PRN231.DTO
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class Register
    {

        public int Id  { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
