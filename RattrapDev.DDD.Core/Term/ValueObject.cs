using System;

namespace RattrapDev.DDD.Core.Term
{
	/// <summary>
	/// Attribute for Value Object implementations within a class.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	public class ValueObject : Attribute
	{
	}
}
