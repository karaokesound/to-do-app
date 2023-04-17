using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoApp.Commands.Profile;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels;
using ToDoAppDataAccess;

namespace ToDoApp.Commands
{
    public class CreateTaskCommand : CommandBase
    {
        private readonly TaskOperationsViewModel _tasksListVM;

        public override void Execute(object parameter)
        {
            if ((_tasksListVM.NewTaskViewModel.TaskTitle != null && _tasksListVM.NewTaskViewModel.TaskTitle != string.Empty)
                && (_tasksListVM.NewTaskViewModel.TaskDescription != null && _tasksListVM.NewTaskViewModel.TaskDescription != string.Empty)) 
            {
                using (ToDoAppDbContext context = new ToDoAppDbContext())
                {
                    TaskModel newTask = new TaskModel()
                    {
                        GuidId = Guid.NewGuid(),
                        Name = _tasksListVM.NewTaskViewModel.TaskTitle,
                        Description = _tasksListVM.NewTaskViewModel.TaskDescription,
                        Value = _tasksListVM.NewTaskViewModel.TaskValue,
                        IsCompleted = false,
                    };
                    context.Tasks.Add(newTask);

                    string[] taskHashtags = _tasksListVM.NewTaskViewModel.TaskDescription.Split(' ');
                    foreach (string taskHashtag in taskHashtags)
                    {
                        CategoryModel properTaskCategory = context.Categories.FirstOrDefault(category => category.Hashtag == taskHashtag);
                        if (properTaskCategory != null)
                        {
                            CategoryTaskModel categoryTaskModel = new CategoryTaskModel
                            {
                                CategoryGuidId = properTaskCategory.GuidId,
                                TaskGuidId = newTask.GuidId,
                            };
                            context.CategoryTasks.Add(categoryTaskModel);
                        }
                        else
                        {
                            CategoryModel defaultTaskCategory = context.Categories.FirstOrDefault(category => category.Hashtag == "#all");
                            CategoryTaskModel categoryTaskModel = new CategoryTaskModel
                            {
                                CategoryGuidId = defaultTaskCategory.GuidId,
                                TaskGuidId = newTask.GuidId,
                            };
                            context.CategoryTasks.Add(categoryTaskModel);
                        }
                    }
                    context.SaveChanges();
                }

                _tasksListVM.GetAllTasks();
                _tasksListVM.NewTaskViewModel.TaskTitle = string.Empty;
                _tasksListVM.NewTaskViewModel.TaskDescription = string.Empty;
                _tasksListVM.NewTaskViewModel.TaskValue = 0;
            }
            else return;
        }

        public CreateTaskCommand(TaskOperationsViewModel tasksListVM)
        {
            _tasksListVM = tasksListVM;
        }
    }
}
