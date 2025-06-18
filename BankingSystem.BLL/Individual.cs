using System;
using System.Text;
using static System.DateTime;

namespace BankingSystem.BLL
{
    [Serializable]
    public class Individual : Client, IDepositor, ILoaner
    {
        public string FirstName { get; }
        public override string DisplayName => $"{FirstName} (ID: {ClientId})";

        private const int DepositInterest = 22;
        private const int LoanInterest = 6;
        private bool _depositIsOpened;
        private bool _loanIsOpened;
        private DateTime _depositDate;

        public Individual(int clientId, string firstName) : base(clientId)
        {
            FirstName = firstName;
            RegistrationDate = Now.AddDays(-1);
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

            decimal availableLoanAmount = Balance * 3;
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

        public override string ToString()
        {
            var info = new StringBuilder();
            info.AppendLine("Физ. лицо");
            info.AppendLine($"Имя: {FirstName}");
            info.AppendLine($"ID: {ClientId}");
            info.AppendLine($"Баланс: {Balance:C}");
            info.AppendLine($"Депозит: {DepositBalance:C}");
            info.AppendLine($"Кредит: {LoanBalance:C}");
            return info.ToString();
        }
    }
}