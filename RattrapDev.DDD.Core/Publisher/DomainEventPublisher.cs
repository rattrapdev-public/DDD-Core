using System;
using System.Collections.Generic;

namespace RattrapDev.DDD.Core
{
	public class DomainEventPublisher : IDomainEventPublisher
	{
		private static DomainEventPublisher instance = new DomainEventPublisher();

		private static List<Delegate> subscribers;

		private static readonly object _object = new Object();

		public static DomainEventPublisher Instance
		{
			get
			{
				return instance;
			}
			internal set
			{
				instance = value;
			}
		}

		public DomainEventPublisher()
		{
			subscribers = new List<Delegate>();
		}

		public void Publish<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent
		{
			lock(_object)
			{
				foreach (var subscriber in subscribers)
				{
					var parameters = subscriber.Method.GetParameters();
					if (parameters[0].ParameterType.Equals(typeof(TDomainEvent)))
					{
						subscriber.DynamicInvoke(domainEvent);
					}
				}
			}
		}

		public IDomainEventPublisher Reset()
		{
			subscribers = new List<Delegate>();
			return this;
		}

		public void Subscribe<TDomainEvent>(Action<TDomainEvent> action) where TDomainEvent : IDomainEvent
		{
			subscribers.Add(action);
		}
	}
}

