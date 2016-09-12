namespace RattrapDev.DDD.Core.Publish
{
	public interface IDomainEventSubscriber<TDomainEvent> where TDomainEvent : IDomainEvent
	{
		void Handle(TDomainEvent domainEvent);
	}
}

