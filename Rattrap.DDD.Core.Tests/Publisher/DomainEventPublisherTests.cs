using System;
using NSubstitute;
using NUnit.Framework;
using RattrapDev.DDD.Core;

namespace Rattrap.DDD.Core.Tests
{
	[TestFixture]
	public class DomainEventPublisherTests
	{
		[Test]
		public void Subscribe_publishes_to_only_matching_subscribers()
		{
			var publisher = new DomainEventPublisher();
			var subscriber1 = Substitute.For<IHandler<SampleDomainEvent>>();
			var subscriber2 = Substitute.For<IHandler<AnotherSampleDomainEvent>>();

			publisher.Subscribe<SampleDomainEvent>(subscriber1.DoSomething);
			publisher.Subscribe<AnotherSampleDomainEvent>(subscriber2.DoSomething);

			var domainEvent = new AnotherSampleDomainEvent();

			publisher.Publish(domainEvent);

			subscriber1.DidNotReceiveWithAnyArgs().DoSomething(Arg.Any<SampleDomainEvent>());
			subscriber2.ReceivedWithAnyArgs().DoSomething(Arg.Any<AnotherSampleDomainEvent>());
		}
	}

	public interface IHandler<TDomainEvent>
	{
		void DoSomething(TDomainEvent domainEvent);
	}

	public class SampleDomainEvent : IDomainEvent
	{
		public DateTime OccurredOn
		{
			get
			{
				return DateTime.UtcNow;
			}
		}
	}

	public class AnotherSampleDomainEvent : IDomainEvent
	{
		public DateTime OccurredOn
		{
			get
			{
				return DateTime.UtcNow;
			}
		}
	}
}

