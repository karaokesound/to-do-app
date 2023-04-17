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
            int randomKeyInt = randomKey.Next(100, 999);
            _loginPanelVM.IsVisibleGeneratedKey = true;
            _loginPanelVM.GeneratedKey = randomKeyInt;
        }

        public GenerateKeyCommand(LoginPanelViewModel loginPanelVM)
        {
            _loginPanelVM = loginPanelVM;
        }
    }
}
