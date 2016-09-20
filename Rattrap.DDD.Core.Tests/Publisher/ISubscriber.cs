using RattrapDev.DDD.Block;

namespace Rattrap.DDD.Block.Tests.Publisher
{
	public interface ISubscriber<TDomainEvent> where TDomainEvent : IDomainEvent
	{
		void DoSomething(TDomainEvent domainEvent);
	}
}