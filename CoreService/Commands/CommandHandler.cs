using CoreService.Bus;
using CoreService.Extensions;
using CoreService.Notifications;
using CoreService.UnitOfWork;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.Commands
{
    public class CommandHandler
    {
        public const string CommitErrorKey = "CommitError";
        protected readonly IMediatorHandler _mediator;
        private readonly IUnitOfWork _uow;
        private readonly IDomainNotificationHandler _notifications;

        public CommandHandler(IMediatorHandler mediator, IUnitOfWork uow, IDomainNotificationHandler notifications)
        {
            _mediator = mediator;
            _uow = uow;
            _notifications = notifications;
        }

        public Task<IDbContextTransaction> BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => _uow.BeginTransaction(isolationLevel);

        public async Task<bool> Commit()
        {
            if (_notifications.HasNotifications())
            {
                return false;
            }

            int commandResponse;

            try
            {
                commandResponse = await _uow.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _mediator.RaiseEvent(new DomainNotification(CommitErrorKey, string.Join(" -> ", ex.WithInnerException().Select(x => x.Message))));
                return false;
            }

            if (commandResponse > 0)
            {
                return true;
            }

            await _mediator.RaiseEvent(new DomainNotification(CommitErrorKey, "We had a problem during saving your data."));

            return false;
        }
    }
}
