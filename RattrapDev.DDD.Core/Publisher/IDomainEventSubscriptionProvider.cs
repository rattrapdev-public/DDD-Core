using System;
using System.Collections.Generic;

namespace RattrapDev.DDD.Core.Publish
{
	public interface IDomainEventSubscriptionProvider
	{
		ICollection<Delegate> GetSubscribersFor(Type domainEventType);
		void Subscribe<TDomainEvent>(Action<TDomainEvent> action) where TDomainEvent : IDomainEvent;
	}
}