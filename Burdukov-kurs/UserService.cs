using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Burdukov_kurs
{
    public static class UserService
    {
        private const string UserFilePath = "users.csv"; // Файл для хранения учетных записей

        // Статический конструктор для инициализации файла администратора при первом обращении к классу
        static UserService()
        {
            EnsureAdminUserExists();
        }

        private static void EnsureAdminUserExists()
        {
            if (!File.Exists(UserFilePath))
            {
                // Создаем файл и записываем учетные данные администратора по умолчанию
                var admin = new User("admin", "admin123", UserRole.Administrator);
                WriteUsersToFile(new List<User> { admin });
            }
            else
            {
                // Проверяем, есть ли администратор, если файл существует, но пуст или без админа
                var users = ReadUsersFromFile();
                if (!users.Any(u => u.Role == UserRole.Administrator))
                {
                    var admin = new User("admin", "admin123", UserRole.Administrator);
                    users.Add(admin);
                    WriteUsersToFile(users);
                }
            }
        }

        public static List<User> ReadUsersFromFile()
        {
            var users = new List<User>();
            if (File.Exists(UserFilePath))
            {
                var lines = File.ReadAllLines(UserFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        if (System.Enum.TryParse<UserRole>(parts[2], out UserRole role))
                        {
                            users.Add(new User(parts[0], parts[1], role));
                        }
                    }
                }
            }
            return users;
        }

        private static void WriteUsersToFile(List<User> users)
        {
            var lines = users.Select(u => $"{u.Username},{u.Password},{u.Role}").ToList();
            File.WriteAllLines(UserFilePath, lines);
        }

        public static User AuthenticateUser(string username, string password)
        {
            var users = ReadUsersFromFile();
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public static bool AddUser(User newUser)
        {
            var users = ReadUsersFromFile();
            if (users.Any(u => u.Username == newUser.Username))
            {
                return false; // Пользователь с таким именем уже существует
            }
            users.Add(newUser);
            WriteUsersToFile(users);
            return true;
        }

        public static bool UpdateUser(string oldUsername, User updatedUser)
        {
            var users = ReadUsersFromFile();
            var userToUpdate = users.FirstOrDefault(u => u.Username == oldUsername);
            if (userToUpdate != null)
            {
                // Если имя пользователя меняется, убедимся, что новое имя не занято (кроме текущего пользователя)
                if (oldUsername != updatedUser.Username && users.Any(u => u.Username == updatedUser.Username))
                {
                    return false; // Новое имя пользователя уже занято
                }
                userToUpdate.Username = updatedUser.Username;
                userToUpdate.Password = updatedUser.Password;
                userToUpdate.Role = updatedUser.Role;
                WriteUsersToFile(users);
                return true;
            }
            return false; // Пользователь не найден
        }

        public static bool DeleteUser(string username)
        {
            var users = ReadUsersFromFile();
            var userToDelete = users.FirstOrDefault(u => u.Username == username);
            if (userToDelete != null)
            {
                // Нельзя удалить последнего администратора
                if (userToDelete.Role == UserRole.Administrator && users.Count(u => u.Role == UserRole.Administrator) <= 1)
                {
                    return false; // Нельзя удалить единственного администратора
                }
                users.Remove(userToDelete);
                WriteUsersToFile(users);
                return true;
            }
            return false; // Пользователь не найден
        }
    }
}