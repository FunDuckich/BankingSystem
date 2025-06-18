using System;

namespace BankingSystem.BLL
{
    [Serializable]
    public abstract class Client : IComparable<Client>
    {
        public int ClientId { get; protected set; }
        public abstract string DisplayName { get; }

        private decimal _balance;
        private decimal _depositBalance;

        protected decimal Balance
        {
            get => _balance;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Баланс не может быть меньше нуля!");
                }

                _balance = value;
            }
        }

        protected decimal DepositBalance
        {
            get => _depositBalance;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Депозит не может быть меньше нуля!");
                }

                _depositBalance = value;
            }
        }

        protected decimal LoanBalance { get; set; }
        protected DateTime RegistrationDate;

        protected Client(int clientId)
        {
            ClientId = clientId;
        }

        public void TopUp(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма пополнения должна быть положительной.");
            }

            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Сумма для снятия должна быть положительной.");
            }

            Balance -= amount;
        }

        public int CompareTo(Client other)
        {
            return RegistrationDate.CompareTo(other.RegistrationDate);
        }
    }
}