using System;
using System.Linq.Expressions;

namespace RattrapDev.DDD.Core
{
	public abstract class LinqSpecification<T> : ILinqSpecification<T>
	{
		public abstract Expression<Func<T, bool>> AsExpression();

		public bool IsSatisfiedBy(T candidate)
		{
			Func<T, bool> predicate = AsExpression().Compile();
			return predicate(candidate);
		}

		public Func<T, bool> ToFunc()
		{
			return AsExpression().Compile();
		}
	}
}

