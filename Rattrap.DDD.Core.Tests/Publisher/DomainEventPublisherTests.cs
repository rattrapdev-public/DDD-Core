using System.Linq;
using NSubstitute;
using NUnit.Framework;
using RattrapDev.DDD.Core.Publish;
using Shouldly;

namespace Rattrap.DDD.Core.Tests.Publish
{
	[TestFixture]
	public class DomainEventPublisherTests
	{
		[Test, RequiresThread]
		public void GetSubscribers_returns_a_list_of_subscribers()
		{
			var publisher = DomainEventPublisher.Instance;
			var subscriber = Substitute.For<IHandler<SampleDomainEvent>>();

			publisher.Subscribe<SampleDomainEvent>(subscriber.DoSomething);
			var subscribers = publisher.GetSubscribersFor(typeof(SampleDomainEvent));
			subscribers.Count.ShouldBeGreaterThan(0);
		}

		[Test, RequiresThread]
		public void Reset_cleans_out_subscribers()
		{
			var publisher = DomainEventPublisher.Instance;
			var subscriber = Substitute.For<IHandler<SampleDomainEvent>>();

			publisher.Subscribe<SampleDomainEvent>(subscriber.DoSomething);
			publisher.Reset();
			var subscribers = publisher.GetSubscribersFor(typeof(SampleDomainEvent)).ToList();
			subscribers.Count.ShouldBe(0);
		}

		[Test, RequiresThread]
		public void Subscribe_publishes_to_only_matching_subscribers()
		{
			var publisher = DomainEventPublisher.Instance;
			var subscriber1 = Substitute.For<IHandler<SampleDomainEvent>>();
			var subscriber2 = Substitute.For<IHandler<AnotherSampleDomainEvent>>();

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
			var subscriber1 = Substitute.For<IHandler<SampleDomainEvent>>();
			var subscriber2 = Substitute.For<IHandler<AnotherSampleDomainEvent>>();

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
		public void Publish_without_subscribers_returns()
		{
			Should.NotThrow(() => DomainEventPublisher.Instance.Publish(new SampleDomainEvent()));
		}
	}

	public interface IHandler<TDomainEvent>
	{
		void DoSomething(TDomainEvent domainEvent);
	}
}