using AccountService.Api.Queries;
using AccountService.API.Commands;
using AccountService.API.Queries;
using CoreService.Bus;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountService.Service
{
    public class AccountsService : IAccountsService
    {
        private readonly IMediatorHandler _mediator;

        public AccountsService(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        public async Task<Guid?> CreateAccount(CreateAccountDto model) => await _mediator.SendCommand(new CreateAccountCommand(model.UserName, model.BankName));

        public async Task DeleteAccount(Guid id) => await _mediator.SendCommand(new DeleteAccountCommand(id));

        public async Task<AccountDto> GetAccount(Guid id) => await _mediator.SendQuery(new FindAccountQuery(id));

        public async Task<IEnumerable<AccountDto>> GetAccounts() => await _mediator.SendQuery(new FindAllAccountsQuery());

        public async Task UpdateAccount(Guid id, UpdateAccountDto model) => await _mediator.SendCommand(new UpdateAccountCommand(model.UserName, model.BankName, id));
    }
}
