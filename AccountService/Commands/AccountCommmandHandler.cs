using AccountService.API.Commands;
using AccountService.DataAcces.Repository;
using AccountService.Domain;
using CoreService.Bus;
using CoreService.Commands;
using CoreService.Notifications;
using CoreService.UnitOfWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AccountService.Commands
{
    public class AccountCommmandHandler : CommandHandler,
        IRequestHandler<CreateAccountCommand, Guid?>,
        IRequestHandler<UpdateAccountCommand, Unit>,
        IRequestHandler<DeleteAccountCommand, Unit>
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AccountCommmandHandler(IRepositoryWrapper repositoryWrapper, IUnitOfWork uow, IMediatorHandler mediator, IDomainNotificationHandler notifications) : base(mediator, uow, notifications)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<Guid?> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = new Account(request.UserName, request.BankName);
            _repositoryWrapper.Account.CreateAccount(account);
            if (await Commit())
            {
                return account.Id;
            }
            else
            {
                await _mediator.RaiseEvent(new DomainNotification(request.MessageType, "Failed to create account", 400));
                return null;
            }
        }

        public async Task<Unit> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _repositoryWrapper.Account.GetAccountByIdAsync(request.Id);
            if (account == null)
            {
                await _mediator.RaiseEvent(new DomainNotification(request.MessageType, $"Account with id {request.Id} not found", 404));
                return Unit.Value;
            }

            account.BankName = request.BankName;
            account.UserName = request.UserName;
            account.UpdatedDate = DateTime.UtcNow;

            _repositoryWrapper.Account.UpdateAccount(account);

            if (await Commit())
            {
                return Unit.Value;
            }
            else
            {
                await _mediator.RaiseEvent(new DomainNotification(request.MessageType, "Not able to update account details", 400));
                return Unit.Value;
            }
        }

        public async Task<Unit> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _repositoryWrapper.Account.GetAccountByIdAsync(request.Id);
            if (account == null)
            {
                await _mediator.RaiseEvent(new DomainNotification(request.MessageType, $"Account with id {request.Id} not found", 404));
                return Unit.Value;
            }

            _repositoryWrapper.Account.DeleteAccount(account);

            if (await Commit())
            {
                return Unit.Value;
            }
            else
            {
                await _mediator.RaiseEvent(new DomainNotification(request.MessageType, "Not able to delete account details", 400));
                return Unit.Value;
            }

        }
    }
}