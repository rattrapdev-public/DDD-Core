namespace RattrapDev.DDD.Core
{
	public class AndNotSpecification<T> : CompositeSpecification<T>
	{
		private readonly ICompositeSpecification<T> left;
		private readonly ICompositeSpecification<T> right;

		public AndNotSpecification(ICompositeSpecification<T> left, ICompositeSpecification<T> right)
		{
			this.right = right;
			this.left = left;
		}

		public override bool IsSatisfiedBy(T candidate)
		{
			return left.IsSatisfiedBy(candidate) && !right.IsSatisfiedBy(candidate);
		}
	}
}

