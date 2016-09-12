using System;
using System.Collections.Generic;

namespace RattrapDev.DDD.Core
{
	public interface IDomainEventSubscriptionProvider
	{
		IEnumerable<Action<TDomainEvent>> GetSubscribers<TDomainEvent>() where TDomainEvent : IDomainEvent; 
		void Subscribe<TDomainEvent>(Action<TDomainEvent> action) where TDomainEvent : IDomainEvent;
	}
}

