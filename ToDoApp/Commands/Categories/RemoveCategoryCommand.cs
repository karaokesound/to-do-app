using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using ToDoApp.Models;
using ToDoApp.ViewModels;
using ToDoAppDataAccess;

namespace ToDoApp.Commands.Profile
{
    public class RemoveCategoryCommand : CommandBase
    {
        private readonly CategoriesPanelViewModel _categoriesPanelVM;
        public RemoveCategoryCommand(CategoriesPanelViewModel categoriesPanelVM)
        {
            _categoriesPanelVM = categoriesPanelVM;
        }

        public override void Execute(object parameter)
        {
            List<CategoryTaskModel> categoryTasksList = new List<CategoryTaskModel>();

            Guid removeCategoryId = _categoriesPanelVM.SelectedCategory.CategoryId;
            if (removeCategoryId == null)
            {
                MessageBox.Show("Error", "No category selected");
                return;
            }
            else
            {
                using (ToDoAppDbContext context = new ToDoAppDbContext())
                {
                    CategoryModel removingCategory = context.Categories.FirstOrDefault(category => category.GuidId == removeCategoryId);
                    categoryTasksList = context.CategoryTasks.Where(task => task.CategoryGuidId == removeCategoryId).ToList();
                    if (removeCategoryId != Guid.Empty && removeCategoryId != null)
                    {
                        foreach (CategoryTaskModel removingTask in categoryTasksList)
                        {
                            Guid tasksModelsGuid = removingTask.TaskGuidId;
                            context.CategoryTasks.Remove(removingTask);
                            var myTask = context.Tasks.FirstOrDefault(task => task.GuidId == tasksModelsGuid);
                            context.Tasks.Remove(myTask);
                        }
                        context.Categories.Remove(removingCategory);
                        context.SaveChanges();
                        _categoriesPanelVM.GetCategories();
                        _categoriesPanelVM.IsCategoryInfoVisible = false;
                    }
                    else
                    {
                        MessageBox.Show("No category selected", "Error");
                        return;
                    }
                }
            }
        }
    }
}
