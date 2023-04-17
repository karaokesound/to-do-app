using System.Collections.Generic;
using ToDoApp.Models;
using ToDoApp.ViewModels;
using ToDoApp.ViewModels.Profile;

namespace ToDoApp.Services
{
    public static class MappingService
    {
        #region TASK MAPPING
        public static IEnumerable<TaskModel> ToTaskModel(IEnumerable<TaskViewModel> source)
        {
            var result = new List<TaskModel>();

            foreach (var item in source)
            {
                result.Add(ToTaskModel(item));
            }

            return result;
        }

        public static TaskModel ToTaskModel(TaskViewModel source)
        {
            return new TaskModel()
            {
                Name = source.TaskTitle,
                Description = source.TaskDescription,
                Value = source.TaskValue,
                GuidId = source.TaskId,
                IsCompleted = source.IsCompleted
            };
        }

        public static IEnumerable<TaskViewModel> ToTaskViewModel(IEnumerable<TaskModel> source)
        {
            var result = new List<TaskViewModel>();

            foreach (var item in source)
            {
                result.Add(ToTaskViewModel(item));
            }

            return result;
        }

        public static TaskViewModel ToTaskViewModel(TaskModel source)
        {
            return new TaskViewModel()
            {
                TaskTitle = source.Name,
                TaskDescription = source.Description,
                TaskValue = source.Value,
                TaskId = source.GuidId,
                IsCompleted = source.IsCompleted
            };
        }
        #endregion

        #region CATEGORY MAPPING
        public static CategoryModel ToCategoryModel(CategoryViewModel categoryVM)
        {
            return new CategoryModel()
            {
                GuidId = categoryVM.CategoryId,
                Name = categoryVM.Name,
                Hashtag = categoryVM.Hashtag,
                CategoryDate = categoryVM.CategoryDate
            };
        }

        public static CategoryViewModel ToCategoryViewModel(CategoryModel categoryModel)
        {
            return new CategoryViewModel
            {
                CategoryId = categoryModel.GuidId,
                Name = categoryModel.Name,
                Hashtag = categoryModel.Hashtag,
                CategoryDate = categoryModel.CategoryDate
            };
        }
        #endregion
    }
}
