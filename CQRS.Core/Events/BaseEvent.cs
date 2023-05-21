using CQRS.Core.Messages;

namespace CQRS.Core.Events
{
    public abstract class BaseEvent : Message
    {
        protected BaseEvent(string type)
        {
            this.Type = type;
        }
        
        /// <summary>
        /// Used when replaying the latest state of the aggregate.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        /// Used when doing polymorhpic data binding when serializing event objects.
        /// </summary>
        public string Type { get; set; } = string.Empty;

    }
}