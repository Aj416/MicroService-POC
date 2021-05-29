using AccountService.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountService.DataAcces.Repository
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        Task<IEnumerable<Account>> GetAllAccountsAsync();
        Task<Account> GetAccountByIdAsync(Guid accountId);
        void CreateAccount(Account account);
        void UpdateAccount(Account account);
        void DeleteAccount(Account account);
    }
}
