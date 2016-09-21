using System;
using System.Linq.Expressions;

namespace RattrapDev.DDD.Block.Specification
{
	public class NotSpecification<T> : CompositeSpecification<T>
	{
		private readonly ILinqSpecification<T> left;

		public NotSpecification(ILinqSpecification<T> left)
		{
			this.left = left;
		}

		public override Expression<Func<T, bool>> AsExpression()
		{
			return ((s) => !left.IsSatisfiedBy(s));
		}
	}
}

