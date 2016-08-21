namespace RattrapDev.DDD.Core
{
	public class NotSpecification<T> : CompositeSpecification<T>
	{
		private readonly ICompositeSpecification<T> left;

		public NotSpecification(ICompositeSpecification<T> left)
		{
			this.left = left;
		}

		public override bool IsSatisfiedBy(T candidate)
		{
			return !left.IsSatisfiedBy(candidate);
		}
	}
}

