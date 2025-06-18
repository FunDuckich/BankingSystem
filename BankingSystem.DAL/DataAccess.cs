using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BankingSystem.DAL
{
    public class DataAccess
    {
        private readonly string _clientsFilePath;
        private readonly string _usersFilePath;
        private readonly BinaryFormatter _formatter;

        public DataAccess(string clientsFilePath, string usersFilePath)
        {
            _clientsFilePath = clientsFilePath;
            _usersFilePath = usersFilePath;
            _formatter = new BinaryFormatter();
        }

        private List<T> LoadData<T>(string filePath)
        {
            if (!File.Exists(filePath) || new FileInfo(filePath).Length == 0)
            {
                return new List<T>();
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                try
                {
                    return (List<T>)_formatter.Deserialize(fs);
                }
                catch (Exception)
                {
                    return new List<T>();
                }
            }
        }

        private void SaveData<T>(string filePath, List<T> data)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                _formatter.Serialize(fs, data);
            }
        }

        public List<object> LoadClients()
        {
            return LoadData<object>(_clientsFilePath);
        }

        public void SaveClients(List<object> clients)
        {
            SaveData(_clientsFilePath, clients);
        }

        public List<object> LoadUsers()
        {
            return LoadData<object>(_usersFilePath);
        }

        public void SaveUsers(List<object> users)
        {
            SaveData(_usersFilePath, users);
        }
    }
}