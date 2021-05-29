using CoreService.Commands;
using MediatR;
using System;

namespace AccountService.API.Commands
{
    public class CreateAccountCommand : Command<Guid?>
    {
        public string UserName { get; set; }
        public string BankName { get; set; }

        public CreateAccountCommand(string userName, string bankName)
        {
            UserName = userName;
            BankName = bankName;
        }

        public override bool IsValid() => !string.IsNullOrEmpty(BankName) && !string.IsNullOrEmpty(UserName);
    }
}
