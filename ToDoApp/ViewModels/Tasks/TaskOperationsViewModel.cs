using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ToDoApp.Commands;
using ToDoApp.Commands.Tasks;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoAppDataAccess;

namespace ToDoApp.ViewModels
{
    public class TaskOperationsViewModel : BaseViewModel
    {
        private BaseViewModel _selectedVM;
        public BaseViewModel SelectedVM
        {
            get { return _selectedVM; }
            set
            {
                _selectedVM = value;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }

        private TaskViewModel _newTaskViewModel;
        public TaskViewModel NewTaskViewModel
        {
            get { return _newTaskViewModel; }
            set
            {
                _newTaskViewModel = value;
                OnPropertyChanged(nameof(NewTaskViewModel));
            }
        }

        private TaskViewModel _editTaskViewModel;
        public TaskViewModel EditTaskViewModel
        {
            get { return _editTaskViewModel; }
            set
            {
                _editTaskViewModel = value;
                OnPropertyChanged(nameof(EditTaskViewModel));
            }
        }

        private TaskViewModel _selectedTask;
        public TaskViewModel SelectedTask
        {
            get { return _selectedTask; }
            set
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }

        private ObservableCollection<TaskViewModel> _tasksList;
        public ObservableCollection<TaskViewModel> TasksList
        {
            get { return _tasksList; }
            set
            {
                _tasksList = value;
                OnPropertyChanged(nameof(TasksList));
            }
        }

        private bool _isCompleted;
        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

        private bool _isVisibleTaskEditor;
        public bool IsVisibleTaskEditor
        {
            get { return _isVisibleTaskEditor; }
            set
            {
                _isVisibleTaskEditor = value;
                OnPropertyChanged(nameof(IsVisibleTaskEditor));
            }
        }

        private bool _isMoreThanOneTask;
        public bool IsMoreThanOneTask
        {
            get { return _isMoreThanOneTask; }
            set
            {
                _isMoreThanOneTask = value;
                OnPropertyChanged(nameof(IsMoreThanOneTask));
            }
        }

        public int Counter
        {
            get { return _tasksList.Count; }
            set { OnPropertyChanged(nameof(Counter)); }
        }

        public ICommand UpdateTasksViewCommand { get; }

        public ICommand CreateTaskCommand { get; }

        public ICommand FinishTaskCommand { get; }

        public ICommand RemoveTaskCommand { get; }

        public ICommand EditTaskCommand { get; }

        public ICommand SaveChangesCommand { get; }

        public ICommand ExitTaskEditingCommand { get; }

        public TaskOperationsViewModel()
        {
            CreateTaskCommand = new CreateTaskCommand(this);
            RemoveTaskCommand = new RemoveTaskCommand(this);
            FinishTaskCommand = new FinishTaskCommand(this);
            SaveChangesCommand = new SaveChangesCommand(this);
            ExitTaskEditingCommand = new ExitTaskEditingCommand(this);
            EditTaskCommand = new EditTaskCommand(this);
            UpdateTasksViewCommand = new UpdateTasksViewCommand(this);
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
