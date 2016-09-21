using System;
using System.Collections.Generic;

namespace RattrapDev.DDD.Block.Publisher
{
	/// <summary>
	/// Singleton publisher designed to be used within Domain aggregates.   
	/// </summary>
	public class DomainEventPublisher : IDomainEventPublisher
	{
		private static IDomainEventPublisher instance = null;

		[ThreadStatic]
		private static IDomainEventSubscriptionProvider provider;

		/// <summary>
		/// Gets or sets an instance of <see cref="DomainEventPublisher"/>.  
		/// When backing field is new works like a factory.
		/// Otherwise the internal instance can be set for testing purposes.
		/// </summary>
		/// <value>The instance.</value>
		public static IDomainEventPublisher Instance
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

		private DomainEventPublisher() 
		{
		}

		public ICollection<Delegate> GetSubscribersFor(Type domainEventType)
		{
			if (provider == null)
			{
				return new List<Delegate>();
			}

			return provider.GetSubscribersFor(domainEventType);
		}

		public void Publish(IDomainEvent domainEvent)
		{
			foreach (var subscriber in GetSubscribersFor(domainEvent.GetType()))
			{
				subscriber.DynamicInvoke(domainEvent);
			}
		}

		public IDomainEventPublisher Reset()
		{
			provider = new DomainEventSubscriptionProvider();
			return this;
		}

		public void Subscribe<TDomainEvent>(Action<TDomainEvent> action) where TDomainEvent : IDomainEvent
		{
			if (provider == null)
			{
				provider = new DomainEventSubscriptionProvider();
			}
			provider.Subscribe(action);
		}
	}
}