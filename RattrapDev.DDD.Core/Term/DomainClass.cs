using System;

namespace RattrapDev.DDD.Core.Term
{
	[AttributeUsage(AttributeTargets.Class)]
	public class DomainClass : Attribute
	{
		internal DomainClass(string name)
			: this(name, string.Empty) 
		{ 
		}

		internal DomainClass(string name, string definition)
		{
			Name = name;
			Definition = definition;
		}

		public string Name { get; private set; }
		public string Definition { get; private set; }
	}
}

