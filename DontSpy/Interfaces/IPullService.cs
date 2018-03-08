namespace DontSpy.Interfaces
{
    internal interface IPullService
    {
        void PullNewMessages();
        void PullChannelRequests();
    }
}
