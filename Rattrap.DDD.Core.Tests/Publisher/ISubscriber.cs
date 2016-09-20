using RattrapDev.DDD.Block;

namespace RattrapDev.DDD.Block.Tests.Publisher
{
	public interface ISubscriber<TDomainEvent> where TDomainEvent : IDomainEvent
	{
		void DoSomething(TDomainEvent domainEvent);
	}
}