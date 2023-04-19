using System;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Windows;
using ToDoApp.Services;
using ToDoApp.ViewModels;
using ToDoAppDataAccess;

namespace ToDoApp.Commands
{
    public class LoginCommand : CommandBase
    {
        private readonly MainViewModel _mainVM;

        private readonly LoginPanelViewModel _loginPanelVM;
        public override void Execute(object parameter)
        {
            if (_mainVM.LoginPanelVM.Key == _mainVM.LoginPanelVM.GeneratedKey && _mainVM.LoginPanelVM.Key != 0
                && _mainVM.LoginPanelVM.Username != null)
            {
                string username = _mainVM.LoginPanelVM.Username;
                UsernameStore.AddUsername(username);
                _mainVM.SelectedViewModel = new AccountPanelViewModel();
                _mainVM.IsTopbarVisible = true;
                _mainVM.LoginPanelVM.IsVisibleGenerateKeyButton = false;
            }
            else MessageBox.Show("Your username or key is invalid", "Error");
        }

        public LoginCommand(MainViewModel mainVM)
        {
            _mainVM = mainVM;
        }

        public LoginCommand(LoginPanelViewModel loginPanelVM)
        {
            _loginPanelVM = loginPanelVM;
        }
    }
}
