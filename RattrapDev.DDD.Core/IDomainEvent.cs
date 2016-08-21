using System;

namespace RattrapDev.DDD.Core
{
	public interface IDomainEvent
	{
		DateTime OccurredOn { get; }
	}
}

