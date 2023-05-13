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
        public CategoryViewModel NewCategoryVM
        {
            get { return _newCategoryVM; }
            set
            {
                _newCategoryVM = value;
                OnPropertyChanged(nameof(NewCategoryVM));
            }
        }

        private CategoryViewModel _selectedCategory;
        public CategoryViewModel SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        private ObservableCollection<CategoryViewModel> _categoryList;
        public ObservableCollection<CategoryViewModel> CategoryList
        {
            get { return _categoryList; }
            set
            {
                _categoryList = value;
                OnPropertyChanged(nameof(CategoryList));
            }
        }

        private ObservableCollection<TaskViewModel> _categoryTasksList;
        public ObservableCollection<TaskViewModel> CategoryTasksList
        {
            get { return _categoryTasksList; }
            set
            {
                _categoryTasksList = value;
                OnPropertyChanged(nameof(CategoryTasksList));
            }
        }
      
        private bool _isAddPanelVisible;
        public bool IsAddPanelVisible
        {
            get { return _isAddPanelVisible; }
            set
            {
                _isAddPanelVisible = value;
                OnPropertyChanged(nameof(IsAddPanelVisible));
            }
        }

        private bool _isListviewVisible;
        public bool IsListviewVisible
        {
            get { return _isListviewVisible; }
            set
            {
                _isListviewVisible = value;
                OnPropertyChanged(nameof(IsListviewVisible));
            }
        }

        private bool _isCategoryInfoVisible;
        public bool IsCategoryInfoVisible
        {
            get { return _isCategoryInfoVisible; }
            set
            {
                _isCategoryInfoVisible = value;
                OnPropertyChanged(nameof(IsCategoryInfoVisible));
            }
        }

        private int _taskCounter;
        public int TaskCounter
        {
            get { return _taskCounter; }
            set
            {
                _taskCounter = _allTasks.Count;
                OnPropertyChanged(nameof(TaskCounter));
            }
        }

        private int _finishedTaskCounter;
        public int FinishedTaskCounter
        {
            get { return _finishedTaskCounter; }
            set
            {
                _finishedTaskCounter = _finishedTasks.Count;
                OnPropertyChanged(nameof(FinishedTaskCounter));
            }
        }

        private int _remainingTasks;
        public int RemainingTasks
        {
            get { return _remainingTasks; }
            set
            {
                _remainingTasks = _allTasks.Count - _finishedTasks.Count;
                OnPropertyChanged(nameof(RemainingTasks));
            }
        }
      
        public ICommand DisplayCategoriesCommand { get; }

        public ICommand AddCategoryCommand { get; }

        public ICommand DisplayAddPanelCommand { get; }

        public ICommand DisplayTaskListviewCommand { get; }

        public ICommand RemoveCategoryCommand { get; }

        public ICommand DisplayButtonCommand { get; }

        private List<TaskViewModel> _finishedTasks;

        private List<TaskViewModel> _allTasks;

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
            RaiseCounters();

            if (categoryTasksList.Count == 0)
            {
                return;
            }

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
