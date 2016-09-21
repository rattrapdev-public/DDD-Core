using System;
using System.Linq.Expressions;

namespace RattrapDev.DDD.Block.Specification
{
	public class AndSpecification<T> : CompositeSpecification<T>
	{
		private readonly ILinqSpecification<T> left;
		private readonly ILinqSpecification<T> right;

		public AndSpecification(ILinqSpecification<T> left, ILinqSpecification<T> right)
		{
			this.right = right;
			this.left = left;
		}

		public override Expression<Func<T, bool>> AsExpression()
		{
			return ((s) => left.IsSatisfiedBy(s) && right.IsSatisfiedBy(s));
		}
	}
}

