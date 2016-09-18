namespace RattrapDev.DDD.Core.Publisher
{
	/// <summary>
	/// Contract for publishing <see cref="IDomainEvent"/> directly.  Designed
	/// to publish the DomainEvent as soon as it runs. 
	/// Based, in part, on the design here: http://udidahan.com/2009/06/14/domain-events-salvation/
	/// </summary>
	public interface IDomainEventPublisher : IDomainEventSubscriptionProvider
	{
		/// <summary>
		/// Resets the publisher by reseting the subscribers.
		/// </summary>
		IDomainEventPublisher Reset();

		/// <summary>
		/// Publishes the given <see cref="IDomainEvent"/>. 
		/// </summary>
		/// <param name="domainEvent">The Domain Event being published.</param>
		void Publish(IDomainEvent domainEvent);
	}
}