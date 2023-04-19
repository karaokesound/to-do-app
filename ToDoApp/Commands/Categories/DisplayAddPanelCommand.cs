using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands.Profile
{
    public class DisplayAddPanelCommand : CommandBase
    {
        private readonly CategoriesPanelViewModel _categoriesVM;
        public override void Execute(object parameter)
        {
            if (_categoriesVM.IsVisibleAddPanel == false)
            {
                _categoriesVM.IsVisibleAddPanel = true;
                _categoriesVM.IsVisibleCategoryInfo = false;
            }
            else
            {
                _categoriesVM.IsVisibleAddPanel = false;
            }
        }

        public DisplayAddPanelCommand(CategoriesPanelViewModel categoriesVM)
        {
            _categoriesVM = categoriesVM;
        }
    }
}
