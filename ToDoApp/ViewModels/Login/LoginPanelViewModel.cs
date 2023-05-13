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

        private string _key;
        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }

        private string _generatedKey;
        public string GeneratedKey
        {
            get { return _generatedKey; }
            set
            {
                _generatedKey = value;
                OnPropertyChanged(nameof(GeneratedKey));
            }
        }

        private bool _isGenerateKeyButtonVisible = true;
        public bool IsGenerateKeyButtonVisible
        {
            get { return _isGenerateKeyButtonVisible; }
            set
            {
                _isGenerateKeyButtonVisible = value;
                OnPropertyChanged(nameof(IsGenerateKeyButtonVisible));
            }
        }

        private bool _isGeneratedKeyVisible;
        public bool IsGeneratedKeyVisible
        {
            get { return _isGeneratedKeyVisible; }
            set
            {
                _isGeneratedKeyVisible = value;
                OnPropertyChanged(nameof(IsGeneratedKeyVisible));
            }
        }

        public ICommand GenerateKeyCommand { get; }

        public LoginPanelViewModel()
        {
            GenerateKeyCommand = new GenerateKeyCommand(this);
        }
    }
}
