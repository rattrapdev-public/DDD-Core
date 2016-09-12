﻿using System.Collections.Generic;

namespace RattrapDev.DDD.Core
{
	public interface IPublishableEntity
	{
		IEnumerable<IDomainEvent> Events { get; }
	}
}