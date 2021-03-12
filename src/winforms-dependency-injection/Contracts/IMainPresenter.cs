namespace FormApplication.Contracts
{
    public interface IMainPresenter : IPresenter<IMainView>
    {
        void OnButtonClicked();
    }
}