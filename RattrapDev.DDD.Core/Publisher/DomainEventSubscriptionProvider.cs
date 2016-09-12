using System;
using System.Collections.Generic;

namespace RattrapDev.DDD.Core
{
	public class DomainEventSubscriptionProvider : IDomainEventSubscriptionProvider
	{
		private List<Delegate> subscribers = new List<Delegate>();

		public IEnumerable<Action<TDomainEvent>> GetSubscribers<TDomainEvent>() where TDomainEvent : IDomainEvent
		{
			foreach (var subscriber in subscribers)
			{
				var parameters = subscriber.Method.GetParameters();
				if (parameters[0].ParameterType.Equals(typeof(TDomainEvent)))
				{
					yield return subscriber as Action<TDomainEvent>;
				}
			}
		}

		public void Subscribe<TDomainEvent>(Action<TDomainEvent> action) where TDomainEvent : IDomainEvent
		{
			subscribers.Add(action);
		}
	}
}

