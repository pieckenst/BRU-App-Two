namespace Burdukov_kurs
{
    public enum UserRole
    {
        Administrator,
        User
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; } // В реальном приложении пароли должны храниться в хешированном виде
        public UserRole Role { get; set; }

        public User(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}