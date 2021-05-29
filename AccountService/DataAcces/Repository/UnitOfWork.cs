using AccountService.DataAccess.EF;
using CoreService.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace AccountService.DataAcces.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected AccountDbContext Context { get; }
        public UnitOfWork(AccountDbContext context) => Context = context;
        public Task<IDbContextTransaction> BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted) => Context.Database.BeginTransactionAsync(isolationLevel);
        public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => await Context.SaveChangesAsync(cancellationToken);
    }
}
