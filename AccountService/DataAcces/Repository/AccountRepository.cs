using AccountService.DataAccess.EF;
using AccountService.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountService.DataAcces.Repository
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(AccountDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateAccount(Account account)
        {
            Create(account);
        }

        public void DeleteAccount(Account account)
        {
            Delete(account);
        }

        public async Task<Account> GetAccountByIdAsync(Guid accountId)
        {
            return await FindByCondition(a => a.Id.Equals(accountId))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.UserName)
               .ToListAsync();
        }

        public void UpdateAccount(Account account)
        {
            Update(account);
        }
    }
}
