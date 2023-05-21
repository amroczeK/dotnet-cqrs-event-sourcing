NOTES:
- COMMANDS and EVENTS are MessageType objects and require a unique identifier.
- When a COMMAND is handled, the AGGREGATE will raise an EVENT. For each COMMAND object, we need a corresponding EVENT object.
- CommandDispatcher uses the Mediator Pattern, promoting loose coupling by preventing objects from referring to each other explicitly. It manages the distribution of messages among other objects.
- AggregateRoot is the Entity within the aggregate that is responsible for keeping the aggregate in a consistent state. This is achieved by assisting the aggregate to raise events, applying changes to the aggregate state and keeping track of uncommited changes and replaying the latest state of the aggregate.