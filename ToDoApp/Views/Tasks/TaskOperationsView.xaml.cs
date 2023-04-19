using System.Windows.Controls;
using ToDoApp.ViewModels;

namespace ToDoApp.Views
{
    public partial class TaskOperationsView : UserControl
    {
        public TaskOperationsView()
        {
            InitializeComponent();
            DataContext = new TaskOperationsViewModel();
        }
    }
}
