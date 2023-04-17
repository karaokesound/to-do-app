using System;
using System.Linq;
using ToDoApp.Models;
using ToDoApp.ViewModels;
using ToDoAppDataAccess;

namespace ToDoApp.Commands
{
    public class FinishTaskCommand : CommandBase
    {
        private readonly TaskOperationsViewModel _tasksListVM;
        public override void Execute(object parameter)
        {
            if (_tasksListVM.TasksList.Count > 0 && _tasksListVM.SelectedTask != null)
            {
                Guid selectedFinishedTaskID = _tasksListVM.SelectedTask.TaskId;
                using (ToDoAppDbContext context = new ToDoAppDbContext())
                {
                    TaskModel finishedTaskModel = context.Tasks.FirstOrDefault(task => task.GuidId == selectedFinishedTaskID);
                    finishedTaskModel.IsCompleted = true;

                    CategoryModel finishedTaskCategory = context.Categories.FirstOrDefault(category => category.Hashtag == finishedTaskModel.Description);
                    if (finishedTaskCategory == null)
                    {
                        CategoryModel defaultTaskCategory = context.Categories.FirstOrDefault(category => category.Hashtag == "#all");
                        CategoryTaskModel finishedCategoryTask = new CategoryTaskModel
                        {
                            CategoryGuidId = defaultTaskCategory.GuidId,
                            TaskGuidId = finishedTaskModel.GuidId,
                        };
                        CategoryTaskModel replaceTask = context.CategoryTasks.FirstOrDefault(task => task.TaskGuidId == finishedCategoryTask.TaskGuidId);
                        context.CategoryTasks.Remove(replaceTask);
                        context.CategoryTasks.Add(finishedCategoryTask);
                    }
                    else
                    {
                        CategoryTaskModel finishedCategoryTask = new CategoryTaskModel
                        {
                            CategoryGuidId = finishedTaskCategory.GuidId,
                            TaskGuidId = finishedTaskModel.GuidId,
                        };
                        CategoryTaskModel replaceTask = context.CategoryTasks.FirstOrDefault(task => task.TaskGuidId == finishedCategoryTask.TaskGuidId);
                        context.CategoryTasks.Remove(replaceTask);
                        context.CategoryTasks.Add(finishedCategoryTask);
                    }
                   
                    context.SaveChanges();
                }
                _tasksListVM.GetAllTasks();
            }
        }

        public FinishTaskCommand(TaskOperationsViewModel tasksListVM)
        {
            _tasksListVM = tasksListVM;
        }
    }
}
