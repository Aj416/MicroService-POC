using System;

namespace AccountService.API.Commands
{
    public class CreateAccountDto
    {
        public string UserName { get; set; }
        public string BankName { get; set; }
    }
}