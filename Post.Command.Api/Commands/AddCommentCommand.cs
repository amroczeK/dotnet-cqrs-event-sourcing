namespace Post.Command.Api.Commands
{
    public class AddCommentCommand
    {
        public string Comment { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
    }
}