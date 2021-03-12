namespace FormApplication.Contracts
{
    public interface IUserPresenter : IPresenter<IUserView>
    {
        void OnButtonClicked();
    }
}