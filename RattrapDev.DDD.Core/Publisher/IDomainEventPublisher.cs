namespace RattrapDev.DDD.Core.Publish
{
	/// <summary>
	/// Contract for publishing <see cref="IDomainEvent"/> directly.  Designed
	/// to publish the DomainEvent as soon as it runs.   
	/// </summary>
	public interface IDomainEventPublisher
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