using NSubstitute;
using NUnit.Framework;
using RattrapDev.DDD.Block.Publisher;

namespace Rattrap.DDD.Block.Tests.Publisher
{
	[TestFixture]
	public class DomainEventSubscriptionProviderTests
	{
		[Test]
		public void GetSubscriptionsFor_gets_subscriptions_for_given_type()
		{
			var provider = new DomainEventSubscriptionProvider();
			var subscriber1 = Substitute.For<ISubscriber<SampleDomainEvent>>();
			var subscriber2 = Substitute.For<ISubscriber<AnotherSampleDomainEvent>>();

			provider.Subscribe<SampleDomainEvent>(subscriber1.DoSomething);
			provider.Subscribe<AnotherSampleDomainEvent>(subscriber2.DoSomething);
			var domainEvent = new SampleDomainEvent();

			var subscribers = provider.GetSubscribersFor(domainEvent.GetType());
			foreach (var subscriber in subscribers)
			{
				subscriber.DynamicInvoke(domainEvent);
			}

			subscriber1.ReceivedWithAnyArgs().DoSomething(Arg.Any<SampleDomainEvent>());
			subscriber2.DidNotReceiveWithAnyArgs().DoSomething(Arg.Any<AnotherSampleDomainEvent>());
		}
	}
}