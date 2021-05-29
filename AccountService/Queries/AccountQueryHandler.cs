using AccountService.Api.Queries;
using AccountService.API.Queries;
using AccountService.DataAcces.Repository;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AccountService.Queries
{
    public class AccountQueryHandler :
        IRequestHandler<FindAllAccountsQuery, IEnumerable<AccountDto>>,
        IRequestHandler<FindAccountQuery, AccountDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repositoryWrapper;

        public AccountQueryHandler(IMapper mapper, IRepositoryWrapper repositoryWrapper)
        {
            _mapper = mapper;
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<IEnumerable<AccountDto>> Handle(FindAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var result = await _repositoryWrapper.Account.GetAllAccountsAsync();

            return _mapper.Map<List<AccountDto>>(result);
        }

        public async Task<AccountDto> Handle(FindAccountQuery request, CancellationToken cancellationToken)
        {
            var result = await _repositoryWrapper.Account.GetAccountByIdAsync(request.Id);
            return _mapper.Map<AccountDto>(result);
        }
    }
}
