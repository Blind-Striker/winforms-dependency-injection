using System;
using System.Windows.Forms;
using FormApplication.Contracts;
using FormApplication.Models;
using FormApplication.Presenters;

namespace FormApplication.Views
{
    public partial class UserView : Form, IUserView
    {
        private readonly IUserPresenter _userPresenter;
        public UserView(IUserPresenter userPresenter)
        {
            _userPresenter = userPresenter;

            InitializeComponent();
        }

        public void JustDoIt(string message)
        {
            label1.Text = message;
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _userPresenter.OnButtonClicked();
        }
    }
}
