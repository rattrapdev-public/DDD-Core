namespace RattrapDev.DDD.Core
{
	public interface ISpecification<T>
	{
		bool IsSatisfiedBy(T candidate);
	}
}

