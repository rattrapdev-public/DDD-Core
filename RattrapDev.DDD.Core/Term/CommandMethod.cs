using System;

namespace RattrapDev.DDD.Core.Term
{
	[AttributeUsage(AttributeTargets.Method)]
	public class CommandMethod : Attribute
	{
		public CommandMethod(Type[] issuedEvents = null) 
			: this(string.Empty, string.Empty, issuedEvents)
		{
		}

		public CommandMethod(string name, Type[] issuedEvents = null)
			: this(name, string.Empty, issuedEvents)
		{
		}

		public CommandMethod(string name, string purpose, Type[] issuedEvents = null)
		{
			Name = name;
			Purpose = purpose;
			IssuedEvents = issuedEvents;
		}

		public string Name { get; private set; }
		public string Purpose { get; private set; }
		public Type[] IssuedEvents { get; private set; }
	}
}
