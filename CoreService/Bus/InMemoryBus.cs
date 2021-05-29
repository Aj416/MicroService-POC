﻿using CoreService.Commands;
using CoreService.Events;
using CoreService.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoreService.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IMediator mediator, IEventStore eventStore)
        {
            _mediator = mediator;
            _eventStore = eventStore;
        }
        public Task RaiseEvent<T>(T thisEvent) where T : Event
        {
            if (!thisEvent.MessageType.Equals("DomainNotification"))
            {
                _eventStore?.Save(thisEvent);
            }

            return _mediator.Publish(thisEvent);
        }

        public Task<T> SendCommand<T>(Command<T> command)
        => _mediator.Send(command);

        public Task SendCommand(Command command)
       => _mediator.Send(command);

        public Task<T> SendQuery<T>(Query<T> query) => _mediator.Send(query);

        public Task SendQuery(Query query) => _mediator.Send(query);
    }
}
