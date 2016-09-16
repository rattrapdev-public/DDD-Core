using NUnit.Framework;
using Rattrap.DDD.Core.Tests;
using RattrapDev.DDD.Core;
using Shouldly;

namespace Rattrap.DDD.Core.Tests
{
	[TestFixture]
	public class CommandAttributionTests
	{
		[Test]
		public void Command_can_have_attribute()
		{
			var commandAttributes = typeof(CommandClass).GetMethod("Command").GetCustomAttributes(true);
			var commandMethodAttribute = commandAttributes[0] as CommandMethod;

			commandMethodAttribute.ShouldNotBeNull();
			commandMethodAttribute.Name.ShouldBe("Command");
			commandMethodAttribute.Purpose.ShouldBe("Here is the purpose");
			commandMethodAttribute.IssuedEvents.ShouldContain(typeof(SampleDomainEvent));
			commandMethodAttribute.IssuedEvents.ShouldContain(typeof(AnotherSampleDomainEvent));
		}

		private class CommandClass
		{
			[CommandMethod("Command", "Here is the purpose", new[] { typeof(SampleDomainEvent), typeof(AnotherSampleDomainEvent) })]
			public void Command() { }
		}
	}
}

