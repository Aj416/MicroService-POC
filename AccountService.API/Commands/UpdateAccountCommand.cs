using CoreService.Commands;
using MediatR;
using System;

namespace AccountService.API.Commands
{
    public class UpdateAccountCommand : Command<Unit>
    {
        public Guid Id { get; set; }
        public string BankName { get; set; }
        public string UserName { get; set; }
        public UpdateAccountCommand(string userName, string bankName, Guid id)
        {
            UserName = userName;
            BankName = bankName;
            Id = id;
        }

        public override bool IsValid() => Id != Guid.Empty && UserName != string.Empty && BankName != string.Empty;
    }
}
