﻿using System;
namespace RattrapDev.DDD.Core
{
	public class DomainEventEntityPublisher : IDomainEventEntityPublisher
	{
		private readonly IDomainEventSubscriptionProvider subscriptionProvider;

		public DomainEventEntityPublisher(IDomainEventSubscriptionProvider subscriptionProvider)
		{
			this.subscriptionProvider = subscriptionProvider;
		}

		public void Publish(IPublishableEntity entity)
		{
			foreach (var domainEvent in entity.Events)
			{
				var subscribers = subscriptionProvider.GetSubscribersFor(domainEvent.GetType());
				foreach (var subscriber in subscribers)
				{
					subscriber.DynamicInvoke(domainEvent);
				}
			}
		}
	}
}
