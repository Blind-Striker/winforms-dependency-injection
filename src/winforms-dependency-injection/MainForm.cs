using System;
using System.Windows.Forms;
using FormApplication.Contracts;
using FormApplication.Views;

namespace FormApplication
{
    public partial class MainForm : Form, IMainView
    {
        private readonly IMainPresenter _mainPresenter;

        public MainForm(IMainPresenter mainPresenter)
        {
            InitializeComponent();

            _mainPresenter = mainPresenter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _mainPresenter.OnButtonClicked();
        }
    }
}
