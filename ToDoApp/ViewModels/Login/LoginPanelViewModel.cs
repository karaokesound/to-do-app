using System.Windows.Input;
using ToDoApp.Commands;

namespace ToDoApp.ViewModels
{
    public class LoginPanelViewModel : BaseViewModel
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

        private int _key;
        public int Key
        {
            get { return _key; }
            set
            {
                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }

        private int _generatedKey;
        public int GeneratedKey
        {
            get { return _generatedKey; }
            set
            {
                _generatedKey = value;
                OnPropertyChanged(nameof(GeneratedKey));
            }
        }

        private bool _isVisibleGenerateKeyButton = true;
        public bool IsVisibleGenerateKeyButton
        {
            get { return _isVisibleGenerateKeyButton; }
            set
            {
                _isVisibleGenerateKeyButton = value;
                OnPropertyChanged(nameof(IsVisibleGenerateKeyButton));
            }
        }

        private bool _isVisibleGeneratedKey;
        public bool IsVisibleGeneratedKey
        {
            get { return _isVisibleGeneratedKey; }
            set
            {
                _isVisibleGeneratedKey = value;
                OnPropertyChanged(nameof(IsVisibleGeneratedKey));
            }
        }

        public ICommand GenerateKeyCommand { get; }

        public ICommand LoginCommand { get; }

        public LoginPanelViewModel()
        {
            GenerateKeyCommand = new GenerateKeyCommand(this);
            LoginCommand = new LoginCommand(this);
        }
    }
}
