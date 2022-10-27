namespace BlazorApp2.Server
{
    public interface ITchat
    {
        Task ReceiveMessage(string user, string message);

    }
}
