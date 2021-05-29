using MediatR;

namespace CoreService.Commands
{
    public abstract class Command : CommandBase, IRequest
    {
    }
}
