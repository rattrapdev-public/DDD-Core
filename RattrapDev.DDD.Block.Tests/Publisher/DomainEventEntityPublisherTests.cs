using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using RattrapDev.DDD.Block;
using RattrapDev.DDD.Block.Publisher;
using Shouldly;

namespace RattrapDev.DDD.Block.Tests.Publisher
{
	[TestFixture]
	public class DomainEventEntityPublisherTests
	{
		[Test]
		public void Constuctor_null_provider_throws_exception()
		{
			Should.Throw<ArgumentNullException>(() => new DomainEventEntityPublisher(null));
		}

		[Test]
		public void Publish_publishes_to_subscribers_matching_domainEvent()
		{
			var entity = Substitute.For<IPublishableEntity>();
			entity.Events.Returns(new List<SampleDomainEvent> { new SampleDomainEvent() });

			var subscriber1 = Substitute.For<ISubscriber<SampleDomainEvent>>();
			var subscriber2 = Substitute.For<ISubscriber<AnotherSampleDomainEvent>>();
			var provider = Substitute.For<IDomainEventSubscriptionProvider>();
			provider.GetSubscribersFor(Arg.Is<Type>(t => t.Equals(typeof(SampleDomainEvent)))).Returns(new List<Delegate> { new Action<SampleDomainEvent>(subscriber1.DoSomething) });
			provider.GetSubscribersFor(Arg.Is<Type>(t => t.Equals(typeof(AnotherSampleDomainEvent)))).Returns(new List<Delegate> { new Action<AnotherSampleDomainEvent>(subscriber2.DoSomething) });

			var publisher = new DomainEventEntityPublisher(provider);

			publisher.Publish(entity);

			subscriber1.ReceivedWithAnyArgs().DoSomething(Arg.Any<SampleDomainEvent>());
			subscriber2.DidNotReceiveWithAnyArgs().DoSomething(Arg.Any<AnotherSampleDomainEvent>());
		}
	}
}