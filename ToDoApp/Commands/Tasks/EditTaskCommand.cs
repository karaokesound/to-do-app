using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands
{
    public class EditTaskCommand : CommandBase
    {
        private readonly TaskOperationsViewModel _tasksListVM;
        public override void Execute(object parameter)
        {
            if (_tasksListVM.SelectedTask != null)
            {
                _tasksListVM.EditTaskViewModel = _tasksListVM.SelectedTask;

                TaskModel copiedTaskModel = new TaskModel
                {
                    Name = _tasksListVM.SelectedTask.TaskTitle,
                    Description = _tasksListVM.SelectedTask.TaskDescription,
                    Value = _tasksListVM.SelectedTask.TaskValue,
                    GuidId = _tasksListVM.SelectedTask.TaskId
                };

                var copiedTaskViewModel = MappingService.ToTaskViewModel(copiedTaskModel);
                _tasksListVM.EditTaskViewModel = copiedTaskViewModel;
                _tasksListVM.IsVisibleTaskEditor = true;
                _tasksListVM.GetAllTasks();
            }
            else return;
        }

        public EditTaskCommand(TaskOperationsViewModel tasksListVM)
        {
            _tasksListVM = tasksListVM;
        }
    }
}
