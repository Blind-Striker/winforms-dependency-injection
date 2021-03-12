namespace FormApplication.Contracts
{
    public interface IUserView : IView
    {
        void JustDoIt(string message);

        void ShowMessage(string message);
    }
}