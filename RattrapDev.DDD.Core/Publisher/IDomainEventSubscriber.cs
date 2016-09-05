namespace RattrapDev.DDD.Core
{
	public interface IDomainEventSubscriber<TDomainEvent> where TDomainEvent : IDomainEvent
	{
		void Handle(TDomainEvent domainEvent);
	}
}

