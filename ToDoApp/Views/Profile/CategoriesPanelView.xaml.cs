using System.Windows.Controls;
using ToDoApp.ViewModels;

namespace ToDoApp.Views
{
    public partial class CategoriesView : UserControl
    {
        public CategoriesView()
        {
            InitializeComponent();
            DataContext = new CategoriesPanelViewModel();
        }
    }
}
