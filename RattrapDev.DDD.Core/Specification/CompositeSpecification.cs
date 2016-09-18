namespace RattrapDev.DDD.Core.Specification
{
	public abstract class CompositeSpecification<T> : LinqSpecification<T>, ICompositeSpecification<T>
	{
		public ICompositeSpecification<T> And(ICompositeSpecification<T> other)
		{
			return new AndSpecification<T>(this, other);
		}

		public ICompositeSpecification<T> AndNot(ICompositeSpecification<T> other)
		{
			return new AndNotSpecification<T>(this, other);
		}

		public ICompositeSpecification<T> Not()
		{
			return new NotSpecification<T>(this);
		}

		public ICompositeSpecification<T> Or(ICompositeSpecification<T> other)
		{
			return new OrSpecification<T>(this, other);
		}

		public ICompositeSpecification<T> OrNot(ICompositeSpecification<T> other)
		{
			return new OrNotSpecification<T>(this, other);
		}
	}
}

