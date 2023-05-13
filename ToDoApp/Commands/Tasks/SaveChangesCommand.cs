using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels;
using ToDoAppDataAccess;

namespace ToDoApp.Commands
{
    public class SaveChangesCommand : CommandBase
    {
        private readonly TaskOperationsViewModel _tasksListVM;
        public override void Execute(object parameter)
        {
            if (_tasksListVM.IsTaskEditorVisible == true)
            {
                TaskViewModel editedTask = _tasksListVM.EditTaskViewModel;

                TaskModel editedTaskModel = new TaskModel
                {
                    Name = _tasksListVM.EditTaskViewModel.TaskTitle,
                    Description = _tasksListVM.EditTaskViewModel.TaskDescription,
                    Value = _tasksListVM.EditTaskViewModel.TaskValue,
                    GuidId = _tasksListVM.EditTaskViewModel.TaskId
                };

                Guid editedTaskID = _tasksListVM.EditTaskViewModel.TaskId;
                using (ToDoAppDbContext context = new ToDoAppDbContext())
                {
                    TaskModel replacingTaskModel = context.Tasks.FirstOrDefault(task => task.GuidId == editedTaskID);
                    replacingTaskModel.Name = editedTaskModel.Name;
                    replacingTaskModel.Description = editedTaskModel.Description;
                    replacingTaskModel.Value = editedTaskModel.Value;
                    replacingTaskModel.GuidId = editedTaskModel.GuidId;
                    context.SaveChanges();
                }
                
                _tasksListVM.GetAllTasks();
                _tasksListVM.IsTaskEditorVisible = false;
                _tasksListVM.EditTaskViewModel.TaskTitle = string.Empty;
                _tasksListVM.EditTaskViewModel.TaskDescription = string.Empty;
                _tasksListVM.EditTaskViewModel.TaskValue = 0;
            }
            else return;
        }

        public SaveChangesCommand(TaskOperationsViewModel tasksListVM)
        {
            _tasksListVM = tasksListVM;
        }
    }
}
