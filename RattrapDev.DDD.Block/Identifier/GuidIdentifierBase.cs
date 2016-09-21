using System;

namespace RattrapDev.DDD.Block.Identifier
{
	/// <summary>
	/// Base Guid <see cref="IdentifierBase{Guid}"/> implementation.
	/// </summary>
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

