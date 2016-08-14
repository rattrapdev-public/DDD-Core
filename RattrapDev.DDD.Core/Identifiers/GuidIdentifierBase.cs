using System;

namespace RattrapDev.DDD.Core.Identifier
{
	public abstract class GuidIdentifierBase : IdentifierBase<Guid>
	{
		protected GuidIdentifierBase(Guid id)
			: base(id)
		{
		}

		protected GuidIdentifierBase()
			: base(Guid.NewGuid())
		{
		}
	}
}

