using System.Windows.Input;
using ToDoApp.Commands;

namespace ToDoApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        private bool _isTopbarVisible;
        public bool IsTopbarVisible
        {
            get { return _isTopbarVisible; }
            set
            {
                _isTopbarVisible = value;
                OnPropertyChanged(nameof(IsTopbarVisible));
            }
        }

        public TaskOperationsViewModel TaskOperationsVM { get; }

        public FinishedTasksViewModel FinishedTasksVM { get; }

        public SettingsViewModel SettingsVM { get; }

        public AccountPanelViewModel AccountPanelVM { get; }

        public CategoriesPanelViewModel CategoriesVM { get; }

        public LoginPanelViewModel LoginPanelVM { get; }

        public ICommand UpdateViewCommand { get; set; }

        public ICommand LoginCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
            LoginCommand = new LoginCommand(this);
            TaskOperationsVM = new TaskOperationsViewModel();
            CategoriesVM = new CategoriesPanelViewModel();
            SettingsVM = new SettingsViewModel();
            AccountPanelVM = new AccountPanelViewModel();
            LoginPanelVM = new LoginPanelViewModel();
        }
    }
}
