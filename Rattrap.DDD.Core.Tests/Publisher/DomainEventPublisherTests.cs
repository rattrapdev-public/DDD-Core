using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using RattrapDev.DDD.Core;
using Shouldly;

namespace Rattrap.DDD.Core.Tests
{
	[TestFixture]
	public class DomainEventPublisherTests
	{
		[Test]
		public void GetSubscribers_returns_a_list_of_subscribers()
		{
			var publisher = new DomainEventPublisher();
			var subscriber = Substitute.For<IHandler<SampleDomainEvent>>();

			publisher.Subscribe<SampleDomainEvent>(subscriber.DoSomething);
			var subscribers = publisher.GetSubscribers<SampleDomainEvent>().ToList();
			subscribers.Count.ShouldBeGreaterThan(0);
		}

		[Test]
		public void Reset_cleans_out_subscribers()
		{
			var publisher = new DomainEventPublisher();
			var subscriber = Substitute.For<IHandler<SampleDomainEvent>>();

			publisher.Subscribe<SampleDomainEvent>(subscriber.DoSomething);
			publisher.Reset();
			var subscribers = publisher.GetSubscribers<AnotherSampleDomainEvent>().ToList();
			subscribers.Count.ShouldBe(0);
		}

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

		[Test]
		public void Publish_only_allows_one_event_at_a_time()
		{
			DateTime dateTime1 = DateTime.MinValue;
			DateTime dateTime2 = DateTime.MinValue;
			Guid anId = Guid.Empty;

			var publisher = new DomainEventPublisher();
			var subscriber1 = new Action<SampleDomainEvent>((e) =>
			{
				anId = e.Id;
				dateTime1 = e.OccurredOn;
			});

			var subscriber2 = new Action<AnotherSampleDomainEvent>((e) =>
			{
				Thread.Sleep(100);
				anId = e.Id;
				dateTime2 = e.OccurredOn;
			});

			publisher.Subscribe<SampleDomainEvent>(subscriber1);
			publisher.Subscribe<AnotherSampleDomainEvent>(subscriber2);

			var domainEvent = new SampleDomainEvent();
			var anotherDomainEvent = new AnotherSampleDomainEvent();

			Parallel.Invoke(
				() => publisher.Publish(anotherDomainEvent),
				() =>
				{
					Thread.Sleep(50);
					publisher.Publish(domainEvent);
				}
			);

			anId.ShouldBe(domainEvent.Id);
			dateTime1.ShouldBe(domainEvent.OccurredOn);
			dateTime2.ShouldBe(anotherDomainEvent.OccurredOn);
		}
	}

	public interface IHandler<TDomainEvent>
	{
		void DoSomething(TDomainEvent domainEvent);
	}

	public class SampleDomainEvent : IDomainEvent
	{
		Guid id = Guid.NewGuid();
		DateTime occurredOn = DateTime.UtcNow;
		public Guid Id
		{
			get
			{
				return id;
			}
		}

		public DateTime OccurredOn
		{
			get
			{
				return occurredOn;
			}
		}
	}

	public class AnotherSampleDomainEvent : IDomainEvent
	{
		Guid id = Guid.NewGuid();
		DateTime occurredOn = DateTime.UtcNow;
		public Guid Id
		{
			get
			{
				return id;
			}
		}

		public DateTime OccurredOn
		{
			get
			{
				return occurredOn;
			}
		}
	}
}

