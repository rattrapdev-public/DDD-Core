using System.Collections.Generic;

namespace RattrapDev.DDD.Core
{
	public interface IPublishableEntity<TIdentifier> : IEntity<TIdentifier>
	{
		IEnumerable<IDomainEvent> Events { get; }
	}
}

