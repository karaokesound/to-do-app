using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ToDoApp.Commands;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoAppDataAccess;

namespace ToDoApp.ViewModels
{
    public class TaskOperationsViewModel : BaseViewModel
    {
        private TaskViewModel _newTaskViewModel;

        private TaskViewModel _editTaskViewModel;

        private TaskViewModel _selectedTask;

        private ObservableCollection<TaskViewModel> _tasksList;

        private bool _isCompleted;

        private bool _isVisibleTaskEditor;

        private bool _isMoreThanOneTask;
        public ICommand CreateTaskCommand { get; }
        public ICommand FinishTaskCommand { get; }
        public ICommand RemoveTaskCommand { get; }
        public ICommand EditTaskCommand { get; }
        public ICommand SaveChangesCommand { get; }
        public ICommand ExitTaskEditingCommand { get; }

        public TaskViewModel NewTaskViewModel
        {
            get { return _newTaskViewModel; }
            set
            {
                _newTaskViewModel = value;
                OnPropertyChanged(nameof(NewTaskViewModel));
            }
        }
        
        public TaskViewModel EditTaskViewModel
        {
            get { return _editTaskViewModel; }
            set
            {
                _editTaskViewModel = value;
                OnPropertyChanged(nameof(EditTaskViewModel));
            }
        }

        public TaskViewModel SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }
       
        public ObservableCollection<TaskViewModel> TasksList
        {
            get { return _tasksList; }
            set
            {
                _tasksList = value;
                OnPropertyChanged(nameof(TasksList));
            }
        }

        public int Counter 
        { 
            get { return _tasksList.Count; } 
            set { OnPropertyChanged(nameof(Counter)); } 
        }

        #region Booleans properties
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
       
        public bool IsVisibleTaskEditor
        {
            get { return _isVisibleTaskEditor; }
            set
            {
                _isVisibleTaskEditor = value;
                OnPropertyChanged(nameof(IsVisibleTaskEditor));
            }
        }
      
        public bool IsMoreThanOneTask
        {
            get { return _isMoreThanOneTask; }
            set
            {
                _isMoreThanOneTask = value;
                OnPropertyChanged(nameof(IsMoreThanOneTask));
            }
        }
        #endregion

        public TaskOperationsViewModel()
        {
            CreateTaskCommand = new CreateTaskCommand(this);
            RemoveTaskCommand = new RemoveTaskCommand(this);
            FinishTaskCommand = new FinishTaskCommand(this);
            SaveChangesCommand = new SaveChangesCommand(this);
            ExitTaskEditingCommand = new ExitTaskEditingCommand(this);
            EditTaskCommand = new EditTaskCommand(this);
            TasksList = new ObservableCollection<TaskViewModel>();
            NewTaskViewModel = new TaskViewModel();
            EditTaskViewModel = new TaskViewModel();
            GetAllTasks();
        }

        public void GetAllTasks()
        {
            TasksList.Clear();

            using (var context = new ToDoAppDbContext())
            {
                var tasksList = context.Tasks.ToList();
                if (tasksList != null)
                {
                    foreach (TaskModel taskModel in tasksList.Where(task => task.IsCompleted == false))
                    {
                        TaskViewModel taskVM = MappingService.ToTaskViewModel(taskModel);
                        TasksList.Add(taskVM);
                    }
                }
                else return;
            }
            CountTasks();
        }

        public void CountTasks()
        {
            Counter++;
            if (TasksList.Count > 1)
            {
                IsMoreThanOneTask = true;
            }
            else IsMoreThanOneTask = false;
        }
    }
}
