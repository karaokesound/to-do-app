using System.Windows.Input;
using ToDoApp.Commands;

namespace ToDoApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand UpdateViewCommand { get; set; }
        public ICommand LoginCommand { get; set; }

        private BaseViewModel _selectedViewModel;

        private bool _isTopbarVisible;

        public TaskOperationsViewModel TaskOperationsVM { get; }
        public FinishedTasksViewModel FinishedTasksVM { get; }
        public ProfileViewModel ProfileVM { get; }
        public SettingsViewModel SettingsVM { get; }
        public AccountPanelViewModel AccountPanelVM { get; }
        public CategoriesPanelViewModel CategoriesVM { get; }
        public LoginPanelViewModel LoginPanelVM { get; }

        //properties//
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public bool IsTopbarVisible
        {
            get { return _isTopbarVisible; }
            set
            {
                _isTopbarVisible = value;
                OnPropertyChanged(nameof(IsTopbarVisible));
            }
        }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            LoginCommand = new LoginCommand(this);
            TaskOperationsVM = new TaskOperationsViewModel();
            ProfileVM = new ProfileViewModel();
            CategoriesVM = new CategoriesPanelViewModel();
            SettingsVM = new SettingsViewModel();
            AccountPanelVM = new AccountPanelViewModel();
            LoginPanelVM = new LoginPanelViewModel();
        }
    }
}
