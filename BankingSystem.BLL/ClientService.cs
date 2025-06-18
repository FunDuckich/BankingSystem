using BankingSystem.DAL;
using System.Collections.Generic;
using System.Linq;

namespace BankingSystem.BLL
{
    public class ClientService
    {
        private readonly DataAccess _dataAccess;
        private readonly UserService _userService;
        private readonly List<Client> _clients;

        public ClientService(DataAccess dataAccess, UserService userService)
        {
            _dataAccess = dataAccess;
            _userService = userService;
            _clients = _dataAccess.LoadClients().Cast<Client>().ToList();
        }

        private int GetNextClientId()
        {
            if (_clients.Count == 0)
            {
                return 1;
            }

            return _clients.Max(c => c.ClientId) + 1;
        }

        public Client GetClientById(int clientId)
        {
            return _clients.FirstOrDefault(c => c.ClientId == clientId);
        }

        public List<Client> GetAllClients()
        {
            _clients.Sort();
            return _clients;
        }

        public List<Individual> GetUnemployedIndividuals()
        {
            var allEmployedIds = new HashSet<int>();
            var companies = _clients.OfType<LegalEntity>();
            foreach (var company in companies)
            {
                foreach (var worker in company.Workers)
                {
                    allEmployedIds.Add(worker.ClientId);
                }
            }

            return _clients.OfType<Individual>()
                .Where(i => !allEmployedIds.Contains(i.ClientId))
                .ToList();
        }

        public bool AddIndividual(string firstName, string username, string password, out string errorMessage)
        {
            int newId = GetNextClientId();
            if (!_userService.CreateUserForClient(username, password, newId, out errorMessage))
            {
                return false;
            }

            _clients.Add(new Individual(newId, firstName));
            errorMessage = string.Empty;
            return true;
        }

        public bool AddLegalEntity(string name, string username, string password, out string errorMessage)
        {
            int newId = GetNextClientId();
            if (!_userService.CreateUserForClient(username, password, newId, out errorMessage))
            {
                return false;
            }

            _clients.Add(new LegalEntity(newId, name));
            errorMessage = string.Empty;
            return true;
        }

        public void DeleteClient(int clientId)
        {
            var clientToRemove = _clients.FirstOrDefault(c => c.ClientId == clientId);
            if (clientToRemove == null) return;

            _userService.DeleteUserByClientId(clientId);
            _clients.Remove(clientToRemove);
        }

        public void SaveChanges()
        {
            _dataAccess.SaveClients(_clients.Cast<object>().ToList());
            _userService.SaveChanges();
        }
    }
}