namespace RattrapDev.DDD.Core.Term
{
	/// <summary>
	/// Attribute for Aggregate Root DDD classes.
	/// </summary>
	public class AggregateRootClass : EntityClass
	{
		public AggregateRootClass(string name, string definition)
			: base(name, definition)
		{
		}
	}
}

