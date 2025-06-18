namespace BankingSystem.BLL
{
    public interface ILoaner
    {
        void TakeLoan(decimal amount);
        void PayLoan(decimal amount);
    }
}