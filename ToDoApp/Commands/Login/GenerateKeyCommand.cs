using System;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands
{
    public class GenerateKeyCommand : CommandBase
    {
        private readonly LoginPanelViewModel _loginPanelVM;

        public override void Execute(object parameter)
        {
            Random randomKey = new Random();
            string randomKeyString = randomKey.Next(100, 999).ToString();
            _loginPanelVM.IsGeneratedKeyVisible = true;
            _loginPanelVM.GeneratedKey = randomKeyString;
        }

        public GenerateKeyCommand(LoginPanelViewModel loginPanelVM)
        {
            _loginPanelVM = loginPanelVM;
        }
    }
}
