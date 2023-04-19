using System;

namespace ToDoApp.ViewModels
{
    public class TaskViewModel : BaseViewModel
    {
        private Guid _taskId;

        private string _taskTitle;

        private string _taskDescription;

        private int _taskValue;

        private bool _isCompleted;

        public Guid TaskId
        {
            get { return _taskId; }
            set
            {
                _taskId = value;
                OnPropertyChanged(nameof(TaskId));
            }
        }
        public string TaskTitle
        {
            get { return _taskTitle; }
            set
            {
                _taskTitle = value;
                OnPropertyChanged(nameof(TaskTitle));
            }
        }
        public string TaskDescription
        {
            get { return _taskDescription; }
            set
            {
                _taskDescription = value;
                OnPropertyChanged(nameof(TaskDescription));
            }
        }
        public int TaskValue
        {
            get { return _taskValue; }
            set
            {
                _taskValue = value;
                OnPropertyChanged(nameof(TaskValue));
            }
        }
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
    }
}
