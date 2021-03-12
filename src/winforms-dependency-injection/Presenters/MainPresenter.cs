using System;
using FormApplication.Contracts;

namespace FormApplication.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private readonly Func<Type, IPresenter> _presenter;

        public MainPresenter(Func<IMainPresenter, IMainView> viewFactory, Func<Type, IPresenter> presenter)
        {
            _presenter = presenter;
            View = viewFactory(this);
        }

        public IMainView View { get; }

        public void OnButtonClicked()
        {
            var presenter = (IUserPresenter) _presenter(typeof(IUserPresenter));

            presenter.View.Show();
        }
    }
}
