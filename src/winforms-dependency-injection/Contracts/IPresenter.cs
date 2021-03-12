namespace FormApplication.Contracts
{
    public interface IPresenter
    {
    }

    public interface IPresenter<out TView> : IPresenter where TView : IView
    {
        TView View { get; }
    }
}