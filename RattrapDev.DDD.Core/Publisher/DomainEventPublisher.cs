using System;
using System.Collections.Generic;

namespace RattrapDev.DDD.Core
{
	public class DomainEventPublisher : IDomainEventPublisher, IDomainEventSubscriptionProvider
	{
		private static DomainEventPublisher instance = null;

		private static List<Delegate> subscribers;

		private static readonly object _object = new Object();

		/// <summary>
		/// Gets or sets an instance of <see cref="DomainEventPublisher"/>.  
		/// When backing field is new works like a factory.
		/// Otherwise the internal instance can be set for testing purposes.
		/// </summary>
		/// <value>The instance.</value>
		public static DomainEventPublisher Instance
		{
			get
			{
				if (instance == null)
				{
					return new DomainEventPublisher();
				}

				return instance;
			}
			set
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
				foreach (var subscriber in GetSubscribers<TDomainEvent>())
				{
					subscriber.DynamicInvoke(domainEvent);
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
	}
}

