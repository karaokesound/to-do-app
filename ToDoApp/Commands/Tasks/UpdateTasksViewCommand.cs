using ToDoApp.ViewModels;

namespace ToDoApp.Commands.Tasks
{
    public class UpdateTasksViewCommand : CommandBase
    {
        private readonly TaskOperationsViewModel _taskOperationsVM;

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "FinishedTasks")
            {
                _taskOperationsVM.SelectedVM = new FinishedTasksViewModel();
            }
        }

        public UpdateTasksViewCommand(TaskOperationsViewModel taskOperationsVM)
        {
            _taskOperationsVM = taskOperationsVM;
        }
    }
}
