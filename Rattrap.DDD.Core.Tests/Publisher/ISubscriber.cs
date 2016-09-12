using RattrapDev.DDD.Core;

namespace Rattrap.DDD.Core.Tests
{
	public interface ISubscriber<TDomainEvent> where TDomainEvent : IDomainEvent
	{
		void DoSomething(TDomainEvent domainEvent);
	}
}

