using CQRS.Core.Commands;
using CQRS.Core.Infrastructure;

namespace Post.Command.Infrastructure.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        /// <summary>
        /// <c>_handler</c> stores the command handling methods as function delegates.
        /// The function delegate takes BaseCommand as an input and outputs a parameter Task.
        /// </summary>
        private readonly Dictionary<Type, Func<BaseCommand, Task>> _handlers = new();
        public void RegisterHandler<T>(Func<T, Task> handler) where T : BaseCommand
        {
            if (_handlers.ContainsKey(typeof(T)))
            {
                throw new IndexOutOfRangeException("You cannot register the same command handler twice.");
            }

            // Add handler to handlers and cast base command to the specified concrete command object type.
            // T corresponds to the input parameter of our function delegate.
            _handlers.Add(typeof(T), x => handler((T)x));
        }

        /// <summary>
        /// Method <c>SendAsync</c> dispatches the command object to the registered command handler method.
        /// </summary>
        public async Task SendAsync(BaseCommand command)
        {
            if (_handlers.TryGetValue(command.GetType(), out Func<BaseCommand, Task> handler))
            {
                await handler(command);
            }
            else
            {
                throw new ArgumentNullException(nameof(handler), "No command handler was registered.");
            }
        }
    }
}