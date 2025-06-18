using BankingSystem.DAL;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem.BLL
{
    public class ClientService
    {
        private readonly DataAccess _dataAccess;
        private readonly List<Client> _clients;

        public ClientService(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _clients = _dataAccess.LoadClients().Cast<Client>().ToList();
        }

        public List<Client> GetAllClients()
        {
            _clients.Sort();
            return _clients;
        }

        public void AddIndividual(int id, string firstName)
        {
            _clients.Add(new Individual(id, firstName));
        }

        public void AddLegalEntity(int id, string name)
        {
            _clients.Add(new LegalEntity(id, name));
        }

        public void SaveChanges()
        {
            _dataAccess.SaveClients(_clients.Cast<object>().ToList());
        }
    }
}