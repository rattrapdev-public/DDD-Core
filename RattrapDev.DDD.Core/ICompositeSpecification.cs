namespace RattrapDev.DDD.Core
{
	public interface ICompositeSpecification<T> : ISpecification<T>
	{
		ICompositeSpecification<T> And(ICompositeSpecification<T> other);
		ICompositeSpecification<T> Or(ICompositeSpecification<T> other);
		ICompositeSpecification<T> Not();
		ICompositeSpecification<T> AndNot(ICompositeSpecification<T> other);
		ICompositeSpecification<T> OrNot(ICompositeSpecification<T> other);
	}
}

