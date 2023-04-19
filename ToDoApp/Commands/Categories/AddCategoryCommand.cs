using System;
using ToDoApp.Models;
using ToDoApp.ViewModels;
using ToDoAppDataAccess;

namespace ToDoApp.Commands
{
    public class AddCategoryCommand : CommandBase
    {
        private readonly CategoriesPanelViewModel _categoriesVM;
        public override void Execute(object parameter)
        {
            if ((_categoriesVM.NewCategoryVM.Name != string.Empty && _categoriesVM.NewCategoryVM.Name != null)
                && (_categoriesVM.NewCategoryVM.Hashtag != string.Empty && _categoriesVM.NewCategoryVM.Hashtag != null))
            {
                using (ToDoAppDbContext context = new ToDoAppDbContext())
                {
                    CategoryModel newCategory = new CategoryModel
                    {
                        GuidId = Guid.NewGuid(),
                        Name = _categoriesVM.NewCategoryVM.Name,
                        Hashtag = _categoriesVM.NewCategoryVM.Hashtag,
                        CategoryDate = _categoriesVM.NewCategoryVM.CategoryDate,
                    };
                    context.Categories.Add(newCategory);
                    context.SaveChanges();
                }
               
                _categoriesVM.GetCategories();
                _categoriesVM.NewCategoryVM.Name = string.Empty;
                _categoriesVM.NewCategoryVM.Hashtag = string.Empty;
                _categoriesVM.NewCategoryVM.CategoryDate = DateTime.Now;
                _categoriesVM.IsVisibleAddPanel = false;
                _categoriesVM.IsVisibleListview = false;
            }
            else return;
        }

        public AddCategoryCommand(CategoriesPanelViewModel categoriesVM)
        {
            _categoriesVM = categoriesVM;
        }
    }
}
