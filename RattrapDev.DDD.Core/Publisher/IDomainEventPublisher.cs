namespace RattrapDev.DDD.Core.Publish
{
	public interface IDomainEventPublisher
	{
		IDomainEventPublisher Reset();
		void Publish(IDomainEvent domainEvent);
	}
}

