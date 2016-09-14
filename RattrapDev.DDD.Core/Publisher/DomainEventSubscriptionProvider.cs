using System;
using System.Collections.Generic;

namespace RattrapDev.DDD.Core.Publish
{
	/// <summary>
	/// The implementation of <see cref="IDomainEventSubscriptionProvider"/>.
	/// </summary>
	public class DomainEventSubscriptionProvider : IDomainEventSubscriptionProvider
	{
		private Dictionary<Type, List<Delegate>> subscribers = new Dictionary<Type, List<Delegate>>();

		public ICollection<Delegate> GetSubscribersFor(Type domainEventType)
		{
			if (subscribers.ContainsKey(domainEventType))
			{
				return subscribers[domainEventType];
			}

			return new List<Delegate>();
		}

		public void Subscribe<TDomainEvent>(Action<TDomainEvent> action) where TDomainEvent : IDomainEvent
		{
			if (subscribers.ContainsKey(typeof(TDomainEvent)))
			{
				subscribers[typeof(TDomainEvent)].Add(action);
			}
			else 
			{
				subscribers.Add(typeof(TDomainEvent), new List<Delegate> { action });
			}
		}
	}
}