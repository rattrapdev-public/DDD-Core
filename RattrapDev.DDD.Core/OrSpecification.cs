namespace RattrapDev.DDD.Core
{
	public class OrSpecification<T> : CompositeSpecification<T>
	{
		readonly ICompositeSpecification<T> left;
		readonly ICompositeSpecification<T> right;

		public OrSpecification(ICompositeSpecification<T> left, ICompositeSpecification<T> right)
		{
			this.right = right;
			this.left = left;
		}

		public override bool IsSatisfiedBy(T candidate)
		{
			return left.IsSatisfiedBy(candidate) || right.IsSatisfiedBy(candidate);
		}
	}
}

