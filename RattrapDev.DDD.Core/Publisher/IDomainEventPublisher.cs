namespace RattrapDev.DDD.Core
{
	public interface IDomainEventPublisher
	{
		IDomainEventPublisher Reset();
		void Publish<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent;
	}
}

