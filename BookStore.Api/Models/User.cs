namespace BookStore.Api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime DateJoined { get; set; }

        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}