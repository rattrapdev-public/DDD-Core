using System;
namespace RattrapDev.DDD.Core
{
	public interface IDomainEventPublisher
	{
		void Publish<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent;
		void Subscribe<TDomainEvent>(Action<TDomainEvent> action) where TDomainEvent : IDomainEvent;
		IDomainEventPublisher Reset();
	}
}

