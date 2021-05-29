using AccountService.API.Commands;
using AccountService.API.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountService.Service
{
    public interface IAccountsService
    {
        Task<Guid?> CreateAccount(CreateAccountDto model);
        Task<IEnumerable<AccountDto>> GetAccounts();
        Task<AccountDto> GetAccount(Guid id);
        Task UpdateAccount(Guid id, UpdateAccountDto model);
        Task DeleteAccount(Guid id);

    }
}
