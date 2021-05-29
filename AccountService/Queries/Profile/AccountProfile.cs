using AccountService.API.Queries;
using AccountService.Domain;
using AutoMapper;

namespace AccountService.Queries
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<Account, AccountDto>();
        }

    }
}