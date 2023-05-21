NOTES:
- COMMANDS and EVENTS are MessageType objects and require a unique identifier.
- When a COMMAND is handled, the AGGREGATE will raise an EVENT. For each COMMAND object, we need a corresponding EVENT object.
- CommandDispatcher uses the Mediator Pattern, promoting loose coupling by preventing objects from referring to each other explicitly. It manages the distribution of messages among other objects.