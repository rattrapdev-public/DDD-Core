namespace RattrapDev.DDD.Core
{
	public interface IDomainEventEntityPublisher
	{
		void Publish(IPublishableEntity entity);
	}
}

