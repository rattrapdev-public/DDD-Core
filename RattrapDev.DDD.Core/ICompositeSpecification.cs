namespace RattrapDev.DDD.Core
{
	/// <summary>
	/// Base contract for the Composite Specification.  Implements the Linq
	/// expression specification pattern.
	/// </summary>
	public interface ICompositeSpecification<T> : ILinqSpecification<T>
	{
		ICompositeSpecification<T> And(ICompositeSpecification<T> other);
		ICompositeSpecification<T> Or(ICompositeSpecification<T> other);
		ICompositeSpecification<T> Not();
		ICompositeSpecification<T> AndNot(ICompositeSpecification<T> other);
		ICompositeSpecification<T> OrNot(ICompositeSpecification<T> other);
	}
}

