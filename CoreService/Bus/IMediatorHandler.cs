using CoreService.Commands;
using CoreService.Events;
using CoreService.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.Bus
{
    public interface IMediatorHandler
    {
        Task<T> SendCommand<T>(Command<T> command);
        Task SendCommand(Command command);
        Task RaiseEvent<T>(T thisEvent) where T : Event;
        Task<T> SendQuery<T>(Query<T> query);
        Task SendQuery(Query query);
    }
}
