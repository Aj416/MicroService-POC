using System;

namespace AccountService.Domain
{
    public class Account
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string BankName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Account() { }
        public Account(string userName, string bankName)
        {
            UserName = userName;
            BankName = bankName;
            CreatedDate = DateTime.UtcNow;
        }
    }
}