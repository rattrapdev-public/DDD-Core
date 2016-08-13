using System;
namespace RattrapDev.DDD.Core.Term
{
	public class ValueObject : DomainTerm
	{
		public ValueObject(string name, string description)
			: base(name, description)
		{
		}
	}
}

