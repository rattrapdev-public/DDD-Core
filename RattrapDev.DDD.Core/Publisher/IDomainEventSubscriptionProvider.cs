using System;
using System.Collections.Generic;

namespace RattrapDev.DDD.Core.Publish
{
	/// <summary>
	/// Contract for subscription provider.  Keeps a collection
	/// of subscribers in the form of <see cref="Action{TDomainEvent}"/>.
	/// </summary>
	public interface IDomainEventSubscriptionProvider
	{
		/// <summary>
		/// Returns all <see cref="ICollection{Delegate}"/> that match the given <see cref="Type"/>.
		/// </summary>
		/// <returns>A <see cref="ICollection{Delegate}"/>.</returns>
		/// <param name="domainEventType">Domain event type.</param>
		ICollection<Delegate> GetSubscribersFor(Type domainEventType);

		/// <summary>
		/// Subscribes the given <see cref="Action{TDomainEvent}"/> to the provider.
		/// </summary>
		/// <param name="action">The <see cref="Action{TDomainEvent}"/> being subscribed.</param>
		/// <typeparam name="TDomainEvent">Domain event type.</typeparam>
		void Subscribe<TDomainEvent>(Action<TDomainEvent> action) where TDomainEvent : IDomainEvent;
	}
}