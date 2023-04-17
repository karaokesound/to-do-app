using System.Windows.Controls;
using ToDoApp.ViewModels;

namespace ToDoApp.Views
{
    public partial class FinishedTasksView : UserControl
    {
        public FinishedTasksView()
        {
            InitializeComponent();
            DataContext = new FinishedTasksViewModel();
        }
    }
}
