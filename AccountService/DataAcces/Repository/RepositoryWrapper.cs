using AccountService.DataAccess.EF;
using System.Threading.Tasks;

namespace AccountService.DataAcces.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AccountDbContext _repoContext;
        private IAccountRepository _account;

        public IAccountRepository Account
        {
            get
            {
                if (_account == null)
                {
                    _account = new AccountRepository(_repoContext);
                }
                return _account;
            }
        }
        public RepositoryWrapper(AccountDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
