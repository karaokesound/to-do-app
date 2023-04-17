using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.ViewModels;

namespace ToDoApp.Commands.Profile
{
    public class ShowCalendarCommand : CommandBase
    {
        private readonly CategoriesPanelViewModel _categoriesVM;
        public override void Execute(object parameter)
        {
            if (_categoriesVM.IsVisibleCalendar == false)
            {
                _categoriesVM.IsVisibleCalendar = true;

            }
            else _categoriesVM.IsVisibleCalendar = false;
        }

        public ShowCalendarCommand(CategoriesPanelViewModel categoriesVM)
        {
            _categoriesVM = categoriesVM;
        }
    }
}
