using System;

namespace RattrapDev.DDD.Block.Term
{
	/// <summary>
	/// Base domain class used by other implementations.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public abstract class BaseDomainClass : Attribute
	{
		internal BaseDomainClass(string name)
			: this(name, string.Empty) 
		{ 
		}

		internal BaseDomainClass(string name, string definition)
		{
			Name = name;
			Definition = definition;
		}

		/// <summary>
		/// Gets or sets the Name of the class in long form.
		/// </summary>
		public string Name { get; private set; }

		/// <summary>
		/// Gets the definitions of the Domain class.
		/// </summary>
		public string Definition { get; private set; }
	}
}

