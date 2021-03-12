using System;
using FormApplication.Contracts;
using FormApplication.Models;
using FormApplication.Services;

namespace FormApplication.Presenters
{
    public class UserPresenter : IUserPresenter
    {
        private readonly IUserService _userService;

        public UserPresenter(Func<IUserPresenter, IUserView> viewFactory, IUserService userService)
        {
            _userService = userService;

            View = viewFactory(this);
            View.JustDoIt("Hello User!");
        }

        public IUserView View { get; }

        public void OnButtonClicked()
        {
            UserModel userModel = _userService.GetUser(1);
            View.ShowMessage(userModel.Name);
        }
    }
}
