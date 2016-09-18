using System;
using System.Linq.Expressions;

namespace RattrapDev.DDD.Core.Specification
{
	public class OrNotSpecification<T> : CompositeSpecification<T>
	{
		private readonly ILinqSpecification<T> left;
		private readonly ILinqSpecification<T> right;

		public OrNotSpecification(ILinqSpecification<T> left, ILinqSpecification<T> right)
		{
			this.right = right;
			this.left = left;
		}

		public override Expression<Func<T, bool>> AsExpression()
		{
			return ((s) => left.IsSatisfiedBy(s) || !right.IsSatisfiedBy(s));
		}
	}
}

