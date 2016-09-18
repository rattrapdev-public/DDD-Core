namespace RattrapDev.DDD.Core.Term
{
	/// <summary>
	/// Attribute for DDD Domain Event classes.
	/// </summary>
	public class DomainEventClass : BaseDomainClass
	{
		public DomainEventClass(string name, string definition)
			: base(name, definition)
		{
		}
	}
}

