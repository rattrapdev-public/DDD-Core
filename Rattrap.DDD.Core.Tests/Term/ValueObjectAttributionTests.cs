using System.Linq;
using NUnit.Framework;
using RattrapDev.DDD.Core;
using Shouldly;

namespace Rattrap.DDD.Core.Tests
{
	[TestFixture]
	public class ValueObjectAttributionTests
	{
		[Test]
		public void Value_attribution_is_on_properties()
		{
			var properties = typeof(ValueTest).GetProperties();
			properties.Count(p => p.GetCustomAttributes(true)[0] is ValueObject).ShouldBe(2);
		}

		private class ValueTest 
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
}
