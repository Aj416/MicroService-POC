using CoreService.Queries;
using MediatR;
using System;

namespace AccountService.API.Queries
{
    public class FindAccountQuery : Query<AccountDto>
    {
        public Guid Id { get; set; }

        public FindAccountQuery(Guid id)
        {
            Id = id;
        }

        public override bool IsValid() => Id != Guid.Empty;
    }
}
