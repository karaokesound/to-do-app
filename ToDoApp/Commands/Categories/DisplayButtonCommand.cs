using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels;
using ToDoAppDataAccess;

namespace ToDoApp.Commands.Profile
{
    public class DisplayButtonCommand : CommandBase
    {
        private readonly CategoriesPanelViewModel _categoriesPanelVM;
        public override void Execute(object parameter)
        {
            if (_categoriesPanelVM.SelectedCategory.CategoryId != Guid.Empty && _categoriesPanelVM.SelectedCategory.CategoryId != null)
            {
                if (_categoriesPanelVM.IsVisibleCategoryInfo == false)
                {
                    GetCategoryTaskList();
                    _categoriesPanelVM.IsVisibleCategoryInfo = true;
                    _categoriesPanelVM.IsVisibleAddPanel = false;
                    _categoriesPanelVM.IsVisibleListview = false;
                    _categoriesPanelVM.SelectedCategory.CategoryId = Guid.Empty;
                }
                else _categoriesPanelVM.IsVisibleCategoryInfo = false;
            }
            else return;
        }

        public DisplayButtonCommand(CategoriesPanelViewModel categoriesPanelVM)
        {
            _categoriesPanelVM = categoriesPanelVM;   
        }

        public void GetCategoryTaskList()
        {
            List<TaskModel> taskModels = new List<TaskModel>();

            Guid selectedCategoryId = _categoriesPanelVM.SelectedCategory.CategoryId;
            using (ToDoAppDbContext context = new ToDoAppDbContext())
            {
                List<CategoryTaskModel> categoryTasksListModel = context.CategoryTasks.Where(category => category.CategoryGuidId == selectedCategoryId).ToList();
                foreach (CategoryTaskModel categoryTaskModel in categoryTasksListModel)
                {
                    Guid categoryTaskId = categoryTaskModel.TaskGuidId;
                    TaskModel taskModel = context.Tasks.FirstOrDefault(task => task.GuidId == categoryTaskId);
                    taskModels.Add(taskModel);
                }
            }
            _categoriesPanelVM.GetCategoryTaskList(taskModels);
        }
    }
}
