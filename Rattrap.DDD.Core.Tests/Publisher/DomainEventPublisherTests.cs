using System.Linq;
using NSubstitute;
using NUnit.Framework;
using RattrapDev.DDD.Core.Publisher;
using Shouldly;

namespace Rattrap.DDD.Core.Tests.Publisher
{
	[TestFixture]
	public class DomainEventPublisherTests
	{
		[SetUp]
		public void Setup()
		{
			DomainEventPublisher.Instance = null;
		}

		[Test, RequiresThread]
		public void GetSubscribers_returns_a_list_of_subscribers()
		{
			var publisher = DomainEventPublisher.Instance;
			var subscriber = Substitute.For<ISubscriber<SampleDomainEvent>>();

			publisher.Subscribe<SampleDomainEvent>(subscriber.DoSomething);
			var subscribers = publisher.GetSubscribersFor(typeof(SampleDomainEvent));
			subscribers.Count.ShouldBeGreaterThan(0);
		}

		[Test, RequiresThread]
		public void Reset_cleans_out_subscribers()
		{
			var publisher = DomainEventPublisher.Instance;
			var subscriber = Substitute.For<ISubscriber<SampleDomainEvent>>();

			publisher.Subscribe<SampleDomainEvent>(subscriber.DoSomething);
			publisher.Reset();
			var subscribers = publisher.GetSubscribersFor(typeof(SampleDomainEvent)).ToList();
			subscribers.Count.ShouldBe(0);
		}

		[Test, RequiresThread]
		public void Subscribe_publishes_to_only_matching_subscribers()
		{
			var publisher = DomainEventPublisher.Instance;
			var subscriber1 = Substitute.For<ISubscriber<SampleDomainEvent>>();
			var subscriber2 = Substitute.For<ISubscriber<AnotherSampleDomainEvent>>();

			publisher.Subscribe<SampleDomainEvent>(subscriber1.DoSomething);
			publisher.Subscribe<AnotherSampleDomainEvent>(subscriber2.DoSomething);

			var domainEvent = new AnotherSampleDomainEvent();

			publisher.Publish(domainEvent);

			subscriber1.DidNotReceiveWithAnyArgs().DoSomething(Arg.Any<SampleDomainEvent>());
			subscriber2.ReceivedWithAnyArgs().DoSomething(Arg.Any<AnotherSampleDomainEvent>());
		}

		[Test, RequiresThread]
		public void Instance_calling_instance_twice_still_publishes_DomainEvents()
		{
			var publisher = DomainEventPublisher.Instance;
			var subscriber1 = Substitute.For<ISubscriber<SampleDomainEvent>>();
			var subscriber2 = Substitute.For<ISubscriber<AnotherSampleDomainEvent>>();

			publisher.Subscribe<SampleDomainEvent>(subscriber1.DoSomething);
			publisher.Subscribe<AnotherSampleDomainEvent>(subscriber2.DoSomething);

			var domainEvent = new AnotherSampleDomainEvent();
			var anotherDomainEvent = new SampleDomainEvent();

			publisher.Publish(domainEvent);

			publisher = DomainEventPublisher.Instance;
			publisher.Publish(anotherDomainEvent);

			subscriber1.ReceivedWithAnyArgs().DoSomething(Arg.Any<SampleDomainEvent>());
			subscriber2.ReceivedWithAnyArgs().DoSomething(Arg.Any<AnotherSampleDomainEvent>());
		}

		[Test, RequiresThread]
		public void Instance_can_be_overridden()
		{
			var overriddenPublisher = Substitute.For<IDomainEventPublisher>();
			DomainEventPublisher.Instance = overriddenPublisher;
			DomainEventPublisher.Instance.Publish(new SampleDomainEvent());
			DomainEventPublisher.Instance.Received().Publish(Arg.Any<SampleDomainEvent>());
		}

		[Test, RequiresThread]
		public void Publish_without_subscribers_returns()
		{
			Should.NotThrow(() => DomainEventPublisher.Instance.Publish(new SampleDomainEvent()));
		}
	}
}