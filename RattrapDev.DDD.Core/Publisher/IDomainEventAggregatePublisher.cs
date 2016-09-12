namespace RattrapDev.DDD.Core
{
	public interface IDomainEventAggregatePublisher
	{
		void Publish<TIdentifier>(IPublishableEntity<TIdentifier> entity);
	}
}

