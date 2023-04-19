using System.Collections.ObjectModel;
using System.Linq;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoAppDataAccess;

namespace ToDoApp.ViewModels
{
    public class FinishedTasksViewModel : BaseViewModel
    {
        private bool _isMoreThanOneTask;

        private ObservableCollection<TaskViewModel> _finishedTasksList;

        public int FinishedCounter 
        { 
            get { return FinishedTasksList.Count; } 
            set { OnPropertyChanged(nameof(FinishedCounter)); } 
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
        public ObservableCollection<TaskViewModel> FinishedTasksList
        {
            get { return _finishedTasksList; }
            set
            {
                _finishedTasksList = value;
                OnPropertyChanged(nameof(FinishedTasksList));
            }
        }

        public FinishedTasksViewModel()
        {
            FinishedTasksList = new ObservableCollection<TaskViewModel>();
            GetFinishedTasks();
        }
    
        public void GetFinishedTasks()
        {
            using (ToDoAppDbContext context = new ToDoAppDbContext())
            {
                var tasksListModel = context.Tasks.ToList();
                var finishedTasksListModel = tasksListModel.Where(task => task.IsCompleted == true);
                foreach (TaskModel finishedTaskModel in finishedTasksListModel)
                {
                    TaskViewModel finishedTaskVM = MappingService.ToTaskViewModel(finishedTaskModel);
                    FinishedTasksList.Add(finishedTaskVM);
                }
            }
            CountTasks();
        }

        public void CountTasks()
        {
            FinishedCounter++;
            if (FinishedTasksList.Count > 1)
            {
                IsMoreThanOneTask = true;
            }
            else
            {
                IsMoreThanOneTask = false;
            }
        }
    }
}
