using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ToDoApp.Commands;
using ToDoApp.Commands.Profile;
using ToDoApp.Models;
using ToDoApp.Services;
using ToDoApp.ViewModels.Profile;
using ToDoAppDataAccess;

namespace ToDoApp.ViewModels
{
    public class CategoriesPanelViewModel : BaseViewModel
    {
        private CategoryViewModel _newCategoryVM;

        private CategoryViewModel _selectedCategory;

        private ObservableCollection<CategoryViewModel> _categoryList;

        private ObservableCollection<TaskViewModel> _categoryTasksList;

        private List<TaskViewModel> _finishedTasks;

        private List<TaskViewModel> _allTasks;

        private bool _isAnyTask;

        private bool _isVisibleCategories;

        private bool _isVisibleAddPanel;

        private bool _isVisibleCalendar;

        private bool _isVisibleListview;

        private bool _isVisibleCategoryInfo;

        private string _noTasks;

        private int _taskCounter;

        private int _finishedTaskCounter;

        private int _remainingTasks;

        public ICommand DisplayCategoriesCommand { get; }
        public ICommand AddCategoryCommand { get; }
        public ICommand DisplayAddPanelCommand { get; }
        public ICommand ShowCalendarCommand { get; }
        public ICommand DisplayTaskListviewCommand { get; }
        public ICommand RemoveCategoryCommand { get; }
        public ICommand DisplayButtonCommand { get; }

        public CategoriesPanelViewModel()
        {
            DisplayCategoriesCommand = new DisplayCategoriesCommand(this);
            DisplayAddPanelCommand = new DisplayAddPanelCommand(this);
            AddCategoryCommand = new AddCategoryCommand(this);
            DisplayTaskListviewCommand = new DisplayTaskListviewCommand(this);
            RemoveCategoryCommand = new RemoveCategoryCommand(this);
            DisplayButtonCommand = new DisplayButtonCommand(this);
            _newCategoryVM = new CategoryViewModel();
            _categoryList = new ObservableCollection<CategoryViewModel>();
            _selectedCategory = new CategoryViewModel();
            _categoryTasksList = new ObservableCollection<TaskViewModel>();
            _finishedTasks = new List<TaskViewModel>();
            _allTasks = new List<TaskViewModel>();
            GetCategories();
        }

        #region Categories booleans properties
        public bool IsAnyTask
        {
            get { return _isAnyTask; }
            set 
            { 
                _isAnyTask = value;
                OnPropertyChanged(nameof(IsAnyTask));
            }
        }
        
        public bool IsVisibleCategories
        {
            get { return _isVisibleCategories; }
            set
            {
                _isVisibleCategories = value;
                OnPropertyChanged(nameof(IsVisibleCategories));
            }
        }
       
        public bool IsVisibleAddPanel
        {
            get { return _isVisibleAddPanel; }
            set
            {
                _isVisibleAddPanel = value;
                OnPropertyChanged(nameof(IsVisibleAddPanel));
            }
        }
       
        public bool IsVisibleCalendar
        {
            get { return _isVisibleCalendar; }
            set
            {
                _isVisibleCalendar = value;
                OnPropertyChanged(nameof(IsVisibleCalendar));
            }
        }

        public bool IsVisibleListview
        {
            get { return _isVisibleListview; }
            set
            {
                _isVisibleListview = value;
                OnPropertyChanged(nameof(IsVisibleListview));
            }
        }
    
        public bool IsVisibleCategoryInfo 
        {
            get { return _isVisibleCategoryInfo; }
            set
            {
                _isVisibleCategoryInfo = value;
                OnPropertyChanged(nameof(IsVisibleCategoryInfo));
            }
        }
        #endregion

        public CategoryViewModel NewCategoryVM
        {
            get { return _newCategoryVM; }
            set
            {
                _newCategoryVM = value;
                OnPropertyChanged(nameof(NewCategoryVM));
            }
        }
        
        public CategoryViewModel SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
        
        public ObservableCollection<CategoryViewModel> CategoryList
        {
            get { return _categoryList; }
            set
            {
                _categoryList = value;
                OnPropertyChanged(nameof(CategoryList));
            }
        }
      
        public ObservableCollection<TaskViewModel> CategoryTasksList
        {
            get { return _categoryTasksList; }
            set
            {
                _categoryTasksList = value;
                OnPropertyChanged(nameof(CategoryTasksList));
            }
        }

        public string NoTasks
        {
            get { return _noTasks; }
            set 
            { 
                _noTasks = value;
                OnPropertyChanged(nameof(NoTasks));
            }
        }
    
        public int TaskCounter
        {
            get { return _taskCounter; }
            set
            {
                _taskCounter = _allTasks.Count;
                if (_taskCounter > 0)
                {
                   IsAnyTask = true;
                }
                else
                {
                    IsAnyTask = false;
                    _noTasks = "no tasks here";
                } 
                    
                OnPropertyChanged(nameof(TaskCounter));
                OnPropertyChanged(nameof(IsAnyTask));
            }
        }
       
        public int FinishedTaskCounter
        {
            get { return _finishedTaskCounter; }
            set
            {
                _finishedTaskCounter = _finishedTasks.Count;
                OnPropertyChanged(nameof(FinishedTaskCounter));
            }
        }
       
        public int RemainingTasks 
        { 
            get { return _remainingTasks; }
            set
            {
                _remainingTasks = _allTasks.Count - _finishedTasks.Count;
                OnPropertyChanged(nameof(RemainingTasks));
            } 
        }

        public void GetCategories()
        {
            CategoryList.Clear();

            using (ToDoAppDbContext context = new ToDoAppDbContext())
            {
                var categoryListModel = context.Categories.ToList();
                foreach (CategoryModel categoryModel in categoryListModel)
                {
                    CategoryViewModel categoryVM = MappingService.ToCategoryViewModel(categoryModel);
                    CategoryList.Add(categoryVM);
                }
            }
        }

        public void GetCategoryTaskList(List<TaskModel> categoryTasksList)
        {
            CategoryTasksList.Clear();
            _finishedTasks.Clear();
            _allTasks.Clear();

            foreach (TaskModel taskModel in categoryTasksList)
            {
                if (taskModel.IsCompleted == false)
                {
                    TaskViewModel taskVM = MappingService.ToTaskViewModel(taskModel);
                    _categoryTasksList.Add(taskVM);
                    _allTasks.Add(taskVM);

                }
                else
                {
                    TaskViewModel taskVM = MappingService.ToTaskViewModel(taskModel);
                    _finishedTasks.Add(taskVM);
                    _allTasks.Add(taskVM);
                }

                RaiseCounters();
            }
        }

        public void RaiseCounters()
        {
            TaskCounter++;
            FinishedTaskCounter++;
            RemainingTasks++;
        }
    }
}
