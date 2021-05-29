using AccountService.API.Queries;
using CoreService.Queries;
using System.Collections.Generic;

namespace AccountService.Api.Queries
{
    public class FindAllAccountsQuery : Query<IEnumerable<AccountDto>>
    {
        public override bool IsValid() => true;

    }
}
