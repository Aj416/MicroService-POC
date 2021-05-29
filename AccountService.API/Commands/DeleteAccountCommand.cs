using CoreService.Commands;
using MediatR;
using System;

namespace AccountService.API.Commands
{
    public class DeleteAccountCommand : Command<Unit>
    {
        public Guid Id { get; set; }
        public DeleteAccountCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid() => Id != Guid.Empty;
    }
}
