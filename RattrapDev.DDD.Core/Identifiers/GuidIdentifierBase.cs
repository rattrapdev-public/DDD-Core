using System;

namespace RattrapDev.DDD.Core.Identifier
{
	public abstract class GuidIdentifierBase : IEquatable<GuidIdentifierBase>
	{
		private readonly Guid id;

		protected GuidIdentifierBase(Guid identity)
		{
			this.id = identity;
		}

		protected GuidIdentifierBase()
		{
			id = Guid.NewGuid();
		}

		public Guid Id
		{
			get
			{
				return this.id;
			}
		}

		public bool Equals(GuidIdentifierBase other)
		{
			if (ReferenceEquals(this, other)) return true;
			return other != null && other.Id.Equals(this.Id);
		}
	}
}

