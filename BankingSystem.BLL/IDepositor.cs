namespace BankingSystem.BLL
{
    public interface IDepositor
    {
        void OpenDeposit(decimal amount);
        void CloseDeposit();
    }
}