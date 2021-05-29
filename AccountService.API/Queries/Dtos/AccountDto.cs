using System;

namespace AccountService.API.Queries
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string BankName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}