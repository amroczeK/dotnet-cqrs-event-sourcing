using CQRS.Core.Events;

namespace CQRS.Core.Domain
{
    public interface IEventStoreRepository
    {
        /// <summary>
        /// Persist a new event to the event store.
        /// </summary>
        Task SaveAsync(EventModel @event);

        /// <summary>
        /// Returns a list of the event model. Used to retrieve all the events from the even store for a specific aggregate.
        /// These events can be used to replay the latest state of the aggregate.
        /// </summary>
        Task<List<EventModel>> FindByAggregateId(Guid aggregateId);
    }
}