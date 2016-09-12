using RattrapDev.DDD.Core;

namespace Rattrap.DDD.Core.Tests.Publish
{
	public interface ISubscriber<TDomainEvent> where TDomainEvent : IDomainEvent
	{
		void DoSomething(TDomainEvent domainEvent);
	}
}

