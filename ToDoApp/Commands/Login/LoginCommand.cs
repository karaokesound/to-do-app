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
        public override void Execute(object parameter)
        {
            if (_mainVM.LoginPanelVM.Key == _mainVM.LoginPanelVM.GeneratedKey && (_mainVM.LoginPanelVM.Key != string.Empty
                && _mainVM.LoginPanelVM.Username != null))
            {
                string username = _mainVM.LoginPanelVM.Username;
                UsernameStore.AddUsername(username);
                _mainVM.SelectedViewModel = new AccountPanelViewModel();
                _mainVM.IsTopbarVisible = true;
                _mainVM.LoginPanelVM.IsGenerateKeyButtonVisible = false;
            }
            else MessageBox.Show("Your username or key is invalid", "Error");
        }

        public LoginCommand(MainViewModel mainVM)
        {
            _mainVM = mainVM;
        }
    }
}
