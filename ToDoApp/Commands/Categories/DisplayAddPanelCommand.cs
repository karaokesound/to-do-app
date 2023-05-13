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
            if (_categoriesVM.IsAddPanelVisible == false)
            {
                _categoriesVM.IsAddPanelVisible = true;
                _categoriesVM.IsCategoryInfoVisible = false;
            }
            else
            {
                _categoriesVM.IsAddPanelVisible = false;
            }
        }

        public DisplayAddPanelCommand(CategoriesPanelViewModel categoriesVM)
        {
            _categoriesVM = categoriesVM;
        }
    }
}
