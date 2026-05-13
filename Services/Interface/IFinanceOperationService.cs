using APIsprint.Models;

namespace APIsprint.Services.Interfaces
{
    public interface IFinanceOperationService
    {
        Task DepositAsync(FinanceOperation operation);

        Task WithdrawAsync(FinanceOperation operation);

        Task<IEnumerable<FinanceOperation>> GetAllAsync();
    }
}