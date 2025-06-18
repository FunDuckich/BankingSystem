using BankingSystem.DAL;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem.BLL
{
    public class UserService
    {
        private readonly DataAccess _dataAccess;
        private List<User> _users;

        public UserService(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _users = _dataAccess.LoadUsers().Cast<User>().ToList();

            EnsureAdminExists();
        }

        private void EnsureAdminExists()
        {
            if (!_users.Any(u => u.Role == UserRole.Admin))
            {
                var adminPasswordHash = PasswordHasher.Hash("admin");
                _users.Add(new User("admin", adminPasswordHash, UserRole.Admin));
                SaveChanges();
            }
        }

        public User Login(string username, string password)
        {
            var passwordHash = PasswordHasher.Hash(password);
            return _users.FirstOrDefault(u =>
                u.Username.ToLower() == username.ToLower() && u.PasswordHash == passwordHash);
        }

        public bool CreateUserForClient(string username, string password, int clientId, out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                errorMessage = "Имя пользователя и пароль не могут быть пустыми.";
                return false;
            }

            if (_users.Any(u => u.Username.ToLower() == username.ToLower()))
            {
                errorMessage = "Пользователь с таким именем уже существует.";
                return false;
            }

            var passwordHash = PasswordHasher.Hash(password);
            _users.Add(new User(username, passwordHash, UserRole.Client, clientId));

            errorMessage = string.Empty;
            return true;
        }

        public void DeleteUserByClientId(int clientId)
        {
            _users.RemoveAll(u => u.ClientId == clientId);
        }

        public void SaveChanges()
        {
            _dataAccess.SaveUsers(_users.Cast<object>().ToList());
        }
    }
}