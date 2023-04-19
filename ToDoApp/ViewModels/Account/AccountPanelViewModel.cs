using ToDoApp.Services;

namespace ToDoApp.ViewModels
{
    public class AccountPanelViewModel : BaseViewModel
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public AccountPanelViewModel()
        {
            GetUsername();
        }

        public void GetUsername()
        {
            string username = UsernameStore.ReturnUsername();
            _username = username;
        }
    }
}
