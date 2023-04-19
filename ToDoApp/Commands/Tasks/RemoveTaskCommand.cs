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
    public class RemoveTaskCommand : CommandBase
    {
        private readonly TaskOperationsViewModel _tasksListVM;

        public override void Execute(object parameter)
        {
            if (_tasksListVM.Counter > 0 && _tasksListVM.SelectedTask != null)
            {
                Guid removeTaskID = _tasksListVM.SelectedTask.TaskId;
                using (ToDoAppDbContext context = new ToDoAppDbContext())
                {
                    TaskModel taskModel = context.Tasks.FirstOrDefault(task => task.GuidId == removeTaskID);
                    CategoryModel taskCategoryModel = context.Categories.FirstOrDefault(category => category.Hashtag == taskModel.Description);
                    if (taskCategoryModel == null)
                    {
                        CategoryModel defaultTaskCategory = context.Categories.FirstOrDefault(category => category.Hashtag == "#all");
                        CategoryTaskModel categoryTaskModel = new CategoryTaskModel()
                        {
                            CategoryGuidId = defaultTaskCategory.GuidId,
                            TaskGuidId = taskModel.GuidId,
                        };
                        CategoryTaskModel categoryTask = context.CategoryTasks.FirstOrDefault(task => task.TaskGuidId == categoryTaskModel.TaskGuidId);
                        context.CategoryTasks.Remove(categoryTask);
                    }
                    else
                    {
                        CategoryTaskModel categoryTaskModel = new CategoryTaskModel()
                        {
                            CategoryGuidId = taskCategoryModel.GuidId,
                            TaskGuidId = taskModel.GuidId,
                        };
                        CategoryTaskModel categoryTask = context.CategoryTasks.FirstOrDefault(task => task.TaskGuidId == categoryTaskModel.TaskGuidId);
                        context.CategoryTasks.Remove(categoryTask);
                    }
                    
                    context.Tasks.Remove(taskModel);
                    context.SaveChanges();
                }
                _tasksListVM.GetAllTasks();
            }
            else return;
        }

        public RemoveTaskCommand(TaskOperationsViewModel tasksListVM)
        {
            _tasksListVM = tasksListVM;
        }
    }
}
