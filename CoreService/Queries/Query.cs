using CoreService.Commands;
using MediatR;

namespace CoreService.Queries
{
    public abstract class Query : CommandBase, IRequest
    {
    }
}
