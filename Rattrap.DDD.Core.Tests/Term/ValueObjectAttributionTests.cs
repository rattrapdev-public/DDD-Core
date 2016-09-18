using System.Linq;
using System.Reflection;
using NUnit.Framework;
using RattrapDev.DDD.Core.Term;
using Shouldly;

namespace Rattrap.DDD.Core.Tests
{
	[TestFixture]
	public class ValueObjectAttributionTests
	{
		[Test]
		public void Value_attribution_is_on_properties()
		{
			var property = typeof(ValueTest).GetProperty("Property1");
			(property.GetCustomAttributes(true)[0] is ValueObject).ShouldBeTrue();
		}
	}

	public class ValueTest
	{
		[ValueObject]
		public object Property1
		{
			get;
			set;
		}

		public object Property2
		{
			get;
			set;
		}

		[ValueObject]
		public object Property3
		{
			get;
			set;
		}
	}
}
