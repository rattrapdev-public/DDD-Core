namespace RattrapDev.DDD.Core.Publish
{
	public interface IDomainEventEntityPublisher
	{
		void Publish(IPublishableEntity entity);
	}
}

