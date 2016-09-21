namespace RattrapDev.DDD.Block.Publisher
{
	/// <summary>
	/// Contract for Domain Event Publisher that
	/// publishes all Domain Events for a given <see cref="IPublishableEntity"/> 
	/// instead of individually.
	/// Based on the idea here: https://lostechies.com/jimmybogard/2014/05/13/a-better-domain-events-pattern/
	/// </summary>
	public interface IDomainEventEntityPublisher
	{
		/// <summary>
		/// Publish the specified entity.
		/// </summary>
		/// <param name="entity">The <see cref="IPublishableEntity"/> implementation to be published.</param>
		void Publish(IPublishableEntity entity);
	}
}