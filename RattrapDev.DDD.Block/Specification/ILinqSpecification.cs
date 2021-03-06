using System;
using System.Linq.Expressions;

namespace RattrapDev.DDD.Block.Specification
{
	/// <summary>
	/// Base contract for doing LINQ based specifications.  Note the default implementation
	/// of <see cref="LinqSpecification"/> implements <see cref="ISpecification"/> by
	/// executing the lambda expression.
	/// </summary>
	public interface ILinqSpecification<T> : ISpecification<T>
	{
		Expression<Func<T, bool>> AsExpression();

		Func<T, bool> ToFunc();
	}
}

