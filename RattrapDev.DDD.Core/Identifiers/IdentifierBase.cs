using System;

namespace RattrapDev.DDD.Core.Identifier
{
	public abstract class IdentifierBase<T> : IEquatable<IdentifierBase<T>>
	{
		private readonly T id;

		protected IdentifierBase(T id)
		{
			this.id = id;
		}

		public T Id
		{
			get
			{
				return id;
			}
		}

		public bool Equals(IdentifierBase<T> other)
		{
			if (ReferenceEquals(this, other)) return true;
			return other != null && this.Id.Equals(other.Id);
		}
	}
}

