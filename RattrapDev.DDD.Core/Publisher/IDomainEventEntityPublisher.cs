namespace RattrapDev.DDD.Core.Publish
{
	/// <summary>
	/// Contract for Domain Event Publisher that
	/// publishes all Domain Events for a given <see cref="IPublishableEntity"/> 
	/// instead of individually.
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