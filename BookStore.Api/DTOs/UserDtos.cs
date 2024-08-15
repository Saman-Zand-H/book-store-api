namespace BookStore.Api.DTOs
{
    public class UserCreateDto
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;

        public string Password
        {
            set
            {
                PasswordHash = Models.User.HashPassword(value);
            }
        }
    }

    public class UserReadDto
    {
        public string Id { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string DateJoined { get; set; } = string.Empty;
    }

    public class UserLoginDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}