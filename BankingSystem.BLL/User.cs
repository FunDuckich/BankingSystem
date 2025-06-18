using System;

namespace BankingSystem.BLL
{
    public enum UserRole
    {
        Admin,
        Client
    }

    [Serializable]
    public class User
    {
        public string Username { get; private set; }
        public string PasswordHash { get; private set; }
        public UserRole Role { get; private set; }
        public int? ClientId { get; private set; }

        public User(string username, string passwordHash, UserRole role, int? clientId = null)
        {
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
            ClientId = clientId;
        }
    }
}