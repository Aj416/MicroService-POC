using System.Threading.Tasks;

namespace AccountService.DataAcces.Repository
{
    public interface IRepositoryWrapper
    {
        IAccountRepository Account { get; }
        Task SaveAsync();
    }
}
