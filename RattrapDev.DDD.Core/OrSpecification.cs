using System;
using System.Linq.Expressions;

namespace RattrapDev.DDD.Core
{
	public class OrSpecification<T> : CompositeSpecification<T>
	{
		readonly ILinqSpecification<T> left;
		readonly ILinqSpecification<T> right;

		public OrSpecification(ILinqSpecification<T> left, ILinqSpecification<T> right)
		{
			this.right = right;
			this.left = left;
		}

		public override Expression<Func<T, bool>> AsExpression()
		{
			return ((s) => left.IsSatisfiedBy(s) || right.IsSatisfiedBy(s));
		}
	}
}

