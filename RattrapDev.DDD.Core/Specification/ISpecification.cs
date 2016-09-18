namespace RattrapDev.DDD.Core.Specification
{
	/// <summary>
	/// Specification pattern for doing validation.  
	/// Includes support for chaining <see cref="CompositeSpecification"/> 
	/// and LINQ based specifications <see cref="LinqSpecification"/>.  Chaining
	/// of LINQ based specifications is supported via the composite.
	/// 
	/// Credit goes to the following links for inspiration/examples:
	/// Specification using IQuerable/LINQ: http://enterprisecraftsmanship.com/2016/02/08/specification-pattern-c-implementation/
	/// Specification chainging via good example on Wikipedia: https://en.wikipedia.org/wiki/Specification_pattern
	/// </summary>
	public interface ISpecification<T>
	{
		bool IsSatisfiedBy(T candidate);
	}
}

