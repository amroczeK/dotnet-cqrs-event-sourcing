using CQRS.Core.Domain;
using Post.Common.Events;

namespace Post.Command.Domain.Aggregates
{
    public class PostAggregate : AggregateRoot
    {
        private bool _active;
        private string _author = string.Empty;
        private readonly Dictionary<Guid, Tuple<string, string>> _comments = new();

        public bool Active { get => _active; set => _active = value; }

        // An aggregate should have a constructor that takes in to parameters or arguments
        public PostAggregate()
        {

        }

        /// <summary>
        /// Constructor <c>PostAggregate</c> facilitates the handling of a command that creates a new instance of the aggregate.
        /// </summary>
        public PostAggregate(Guid id, string author, string message)
        {
            RaiseEvent(new PostCreatedEvent
            {
                Id = id,
                Author = author,
                Message = message,
                DatePosted = DateTime.Now
            });
        }

        public void Apply(PostCreatedEvent @event)
        {
            _id = @event.Id;
            _active = true;
            _author = @event.Author;
        }

        public void EditMessage(string message)
        {
            if (!_active)
            {
                throw new InvalidOperationException("You cannot edit the message of an inactive post.");
            }
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new InvalidOperationException($"The value of {nameof(message)} cannot be null or empty. Please provide a valid {nameof(message)}");
            }

            RaiseEvent(new MessageUpdatedEvent
            {
                Id = _id,
                Message = message
            });
        }

        public void Apply(MessageUpdatedEvent @event)
        {
            _id = @event.Id;
        }

        public void LikePost()
        {
            if (!_active)
            {
                throw new InvalidOperationException("You cannot like an inactive post.");
            }

            RaiseEvent(new PostLikedEvent
            {
                Id = _id
            });
        }

        public void Apply(PostLikedEvent @event)
        {
            _id = @event.Id;
        }

        public void AddComment(string comment, string username)
        {
            if (!_active)
            {
                throw new InvalidOperationException("You cannot add a comment to an inactive post.");
            }
            if (string.IsNullOrWhiteSpace(comment))
            {
                throw new InvalidOperationException($"The value of {nameof(comment)} cannot be null or empty. Please provide a valid {nameof(comment)}");
            }

            RaiseEvent(new CommentAddedEvent
            {
                Id = _id,
                CommentId = Guid.NewGuid(),
                Comment = comment,
                Username = username,
                CommentDate = DateTime.Now
            });
        }

        public void Apply(CommentAddedEvent @event)
        {
            _id = @event.Id;
            _comments.Add(@event.CommentId, new Tuple<string, string>(@event.Comment, @event.Username));
        }
    }
}