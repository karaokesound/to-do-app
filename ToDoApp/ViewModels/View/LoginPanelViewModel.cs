using System;
using System.Windows.Input;
using ToDoApp.Commands;

namespace ToDoApp.ViewModels
{
    public class LoginPanelViewModel : BaseViewModel
    {
        public ICommand GenerateKeyCommand { get; }

        public ICommand LoginCommand { get; }

		private string _username;

        private int _key;

        private int _generatedKey;

        private bool _isVisibleGeneratedKey;

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

        public bool IsVisibleGeneratedKey
        {
            get { return _isVisibleGeneratedKey; }
            set
            {
                _isVisibleGeneratedKey = value;
                OnPropertyChanged(nameof(IsVisibleGeneratedKey));
            }
        }

        public string Username
		{
			get { return _username; }
			set 
			{
				_username = value;
                OnPropertyChanged(nameof(Username));
			}
		}

        public int Key
        {
            get { return _key; }
            set
            {
                _key = value;
                OnPropertyChanged(nameof(Key));
            }
        }

        public int GeneratedKey
        {
            get { return _generatedKey; }
            set
            {
                _generatedKey = value;
                OnPropertyChanged(nameof(GeneratedKey));
            }
        }

        public LoginPanelViewModel()
        {
            GenerateKeyCommand = new GenerateKeyCommand(this);
            LoginCommand = new LoginCommand(this);
        }
    }
}
