using AccountService.API.Commands;
using AccountService.Service;
using CoreService.Bus;
using CoreService.MVC;
using CoreService.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AccountService.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IAccountsService _accountService;

        public AccountsController(IAccountsService accountService, IMediator mediator, IMediatorHandler mediatorHandler, IDomainNotificationHandler notifications) : base(notifications, mediatorHandler)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _accountService = accountService;
        }

        // GET api/products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _accountService.GetAccounts();
            return Response(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _accountService.GetAccount(id);
            if (result == null)
            {
                NotifyError(GetType().Name, $"Account with id {id} not found", 404);
            }

            return Response(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountDto model)
        {
            var result = await _accountService.CreateAccount(model);
            return Response(result);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAccount(Guid id, [FromBody] UpdateAccountDto model)
        {
            await _accountService.UpdateAccount(id, model);
            return Response();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            await _accountService.DeleteAccount(id);
            return Response();
        }
    }
}