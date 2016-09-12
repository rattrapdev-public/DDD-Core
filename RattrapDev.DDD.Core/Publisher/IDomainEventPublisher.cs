namespace RattrapDev.DDD.Core
{
	public interface IDomainEventPublisher
	{
		IDomainEventPublisher Reset();
		void Publish(IDomainEvent domainEvent);

	}
}

