using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.DateTime;

namespace BankingSystem.BLL
{
    [Serializable]
    public class LegalEntity : Client, IDepositor, ILoaner
    {
        public string NameOfOrganisation { get; }
        public override string DisplayName => $"{NameOfOrganisation} (ID: {ClientId})";
        public IReadOnlyList<Individual> Workers => _workers.AsReadOnly();

        private const int DepositInterest = 29;
        private const int LoanInterest = 3;
        private bool _depositIsOpened;
        private bool _loanIsOpened;
        private DateTime _depositDate;
        private readonly List<Individual> _workers = new List<Individual>();
        private decimal WorkerSalary => _workers.Count > 0 ? Balance * (decimal)0.05 / _workers.Count : 0;

        public LegalEntity(int clientId, string nameOfOrganisation) : base(clientId)
        {
            NameOfOrganisation = nameOfOrganisation;
            RegistrationDate = Now;
        }

        public void OpenDeposit(decimal amount)
        {
            if (_depositIsOpened)
            {
                throw new Exception("Депозит уже открыт!");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Сумма депозита должна быть положительной.");
            }

            Balance -= amount;
            DepositBalance += amount;
            _depositDate = Now;
            _depositIsOpened = true;
        }

        public void CloseDeposit()
        {
            if (!_depositIsOpened)
            {
                throw new Exception("Открытого депозита нет!");
            }

            Balance += DepositBalance * (decimal)(1 + DepositInterest / (IsLeapYear(Now.Year) ? 366.0 : 365.0) *
                (Now - _depositDate).TotalDays);
            DepositBalance = 0;
            _depositIsOpened = false;
        }

        public void TakeLoan(decimal amount)
        {
            if (_loanIsOpened)
            {
                throw new Exception("У вас уже есть кредит!");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Сумма кредита должна быть положительной.");
            }

            decimal availableLoanAmount = Balance * 7;
            if (amount > availableLoanAmount)
            {
                throw new Exception($"Максимально доступный размер кредита: {availableLoanAmount:C}");
            }

            Balance += amount;
            LoanBalance += amount;
            _loanIsOpened = true;
        }

        public void PayLoan(decimal amount)
        {
            if (!_loanIsOpened)
            {
                throw new Exception("Вы не должник!");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Сумма погашения должна быть положительной.");
            }

            Balance -= amount;
            LoanBalance -= amount;

            if (LoanBalance <= 0)
            {
                Balance -= LoanBalance;
                LoanBalance = 0;
                _loanIsOpened = false;
            }
        }

        public void Hire(Individual newWorker)
        {
            if (_workers.Any(w => w.ClientId == newWorker.ClientId))
            {
                throw new Exception("Этот работник уже нанят.");
            }

            _workers.Add(newWorker);
        }

        public void PaymentForWorkers()
        {
            if (_workers.Count <= 0)
            {
                throw new Exception("Нет работников для выплаты зарплаты!");
            }

            decimal totalSalary = WorkerSalary * _workers.Count;
            if (Balance < totalSalary)
            {
                throw new Exception("Недостаточно средств на балансе для выплаты зарплаты.");
            }

            foreach (Individual worker in _workers)
            {
                worker.TopUp(WorkerSalary);
                Balance -= WorkerSalary;
            }
        }

        private string GetWorkersNames()
        {
            if (_workers.Count == 0) return "Нет";
            return string.Join(", ", _workers.Select(w => w.FirstName));
        }

        public override string ToString()
        {
            var info = new StringBuilder();
            info.AppendLine("Юр. лицо");
            info.AppendLine($"Наименование: {NameOfOrganisation}");
            info.AppendLine($"ID: {ClientId}");
            info.AppendLine($"Баланс: {Balance:C}");
            info.AppendLine($"Депозит: {DepositBalance:C}");
            info.AppendLine($"Кредит: {LoanBalance:C}");
            info.AppendLine($"Работники: {GetWorkersNames()}");
            return info.ToString();
        }
    }
}