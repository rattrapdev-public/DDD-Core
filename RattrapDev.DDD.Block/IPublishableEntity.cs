using System.Collections.Generic;

namespace RattrapDev.DDD.Block
{
	/// <summary>
	/// An entity that will fire domain events.
	/// </summary>
	public interface IPublishableEntity
	{
		/// <summary>
		/// Gets a collection of <see cref="IDomainEvent"/> that have been issued.
		/// </summary>
		IEnumerable<IDomainEvent> Events { get; }
	}
}