using NUnit.Framework;
using RattrapDev.DDD.Block.Term;

namespace RattrapDev.DDD.Block.Tests
{
	[TestFixture]
	public class ValueObjectClassAttributionTests
	{
		[Test]
		public void Attribution_sets_name_and_definition()
		{
			var attributes = typeof(TestValueObject).GetCustomAttributes(true);
			var valueObjectTerm = (ValueObjectClass)attributes[0];
			Assert.That(valueObjectTerm.Name, Is.EqualTo("Value"));
			Assert.That(valueObjectTerm.Definition, Is.EqualTo("Definition"));
		}

		[ValueObjectClass("Value", "Definition")]
		private class TestValueObject 
		{
		}
	}
}

