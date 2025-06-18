using BankingSystem.DAL;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem.BLL
{
    public class UserService
    {
        private readonly DataAccess _dataAccess;
        private readonly List<User> _users;

        public UserService(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _users = _dataAccess.LoadUsers().Cast<User>().ToList();
        }

        public bool Register(string username, string password, out string errorMessage)
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

            string passwordHash = PasswordHasher.Hash(password);
            _users.Add(new User(username, passwordHash));
            _dataAccess.SaveUsers(_users.Cast<object>().ToList());

            errorMessage = string.Empty;
            return true;
        }

        public bool Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
            if (user == null)
            {
                return false;
            }

            string passwordHash = PasswordHasher.Hash(password);
            return user.PasswordHash == passwordHash;
        }
    }
}