using System.Windows.Controls;
using ToDoApp.ViewModels;

namespace ToDoApp.Views
{
    public partial class ProfileView : UserControl
    {
        public ProfileView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
