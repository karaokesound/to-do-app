using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands
{
    public class ExitTaskEditingCommand : CommandBase
    {
        private readonly TaskOperationsViewModel _tasksListVM;
        public override void Execute(object parameter)
        {
            _tasksListVM.IsVisibleTaskEditor = false;
        }

        public ExitTaskEditingCommand(TaskOperationsViewModel tasksListVM)
        {
            _tasksListVM = tasksListVM;
        }
    }
}
