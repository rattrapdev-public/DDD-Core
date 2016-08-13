using System;

namespace RattrapDev.DDD.Core.Term
{
	public class DomainTerm : Attribute
	{
		internal DomainTerm(string name)
			: this(name, string.Empty) 
		{ 
		}

		internal DomainTerm(string name, string definition)
		{
			Name = name;
			Definition = definition;
		}

		public string Name { get; private set; }
		public string Definition { get; private set; }
	}
}

