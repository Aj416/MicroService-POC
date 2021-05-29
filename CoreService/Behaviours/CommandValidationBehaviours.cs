using CoreService.Bus;
using CoreService.Commands;
using CoreService.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoreService.Behaviours
{
    public class CommandValidationBehaviours<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IMediatorHandler _mediator;

        public CommandValidationBehaviours(IMediatorHandler mediator) => _mediator = mediator;

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var cmd = request as CommandBase;


            if (cmd.IsValid())
            {
                return await next();
            }
            else
            {
                await NotifyCommandErrors(cmd);
            }
            return default;
        }

        private async Task NotifyCommandErrors(CommandBase cmd)
        {
            if (cmd.ValidationResult != null)
            {
                foreach (var error in cmd.ValidationResult.Errors)
                {
                    await _mediator.RaiseEvent(new DomainNotification(cmd.MessageType, error.ErrorMessage));
                }
            }
            else
            {
                await _mediator.RaiseEvent(new DomainNotification(cmd.MessageType, $"Command validation failed ({cmd.MessageType})"));
            }
        }
    }
}
