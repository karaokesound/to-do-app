using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands
{
    public class DisplayCategoriesCommand : CommandBase
    {
        private readonly CategoriesPanelViewModel _categoriesVM;
        public override void Execute(object parameter)
        {
            //if (_categoriesVM.IsVisibleCategories == false)
            //{
            //    _categoriesVM.IsVisibleCategories = true;
            //}
            //else
            //{
            //    _categoriesVM.IsVisibleCategories = false;
            //    _categoriesVM.IsVisibleAddPanel = false;
            //}
        }

        public DisplayCategoriesCommand(CategoriesPanelViewModel categoriesVM)
        { 
            _categoriesVM = categoriesVM;
        }
    }
}
