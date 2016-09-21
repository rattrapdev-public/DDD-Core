using System;

namespace RattrapDev.DDD.Block
{
	/// <summary>
	/// Base contract for DDD Domain Events.  
	/// </summary>
	public interface IDomainEvent
	{
		DateTime OccurredOn { get; }
	}
}

