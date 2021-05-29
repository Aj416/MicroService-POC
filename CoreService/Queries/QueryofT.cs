using CoreService.Commands;
using MediatR;

namespace CoreService.Queries
{
    public abstract class Query<T> : CommandBase, IRequest<T>
    {
    }
}
