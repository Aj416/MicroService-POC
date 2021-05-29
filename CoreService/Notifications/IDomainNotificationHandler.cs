using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreService.Notifications
{
    public interface IDomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        IEnumerable<DomainNotification> GetNotifications();
        bool HasNotifications();
        void Dispose();
    }
}
