using RattrapDev.DDD.Core;

namespace Rattrap.DDD.Core.Tests.Publisher
{
	public interface ISubscriber<TDomainEvent> where TDomainEvent : IDomainEvent
	{
		void DoSomething(TDomainEvent domainEvent);
	}
}