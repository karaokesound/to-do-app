using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.ViewModels.Profile
{
    public class CategoryViewModel : BaseViewModel
    {
        private Guid _categoryId;
        private string _name;
        private string _hashtag;
        private DateTime _categoryDate = DateTime.Now;

        public Guid CategoryId { get { return _categoryId; } set { _categoryId = value; OnPropertyChanged(nameof(CategoryId)); } }
        public string Name { get { return _name; } set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Hashtag { get { return _hashtag; } set { _hashtag = value; OnPropertyChanged(nameof(Hashtag)); } }
        public DateTime CategoryDate
        {
            get { return _categoryDate; }
            set
            {
                _categoryDate = value;
                OnPropertyChanged(nameof(CategoryDate));
                OnPropertyChanged(nameof(CategoryDateToString));
            }
        }
        public string CategoryDateToString
        {
            get
            {
                string dateOfCategoryYear = _categoryDate.Year.ToString();
                string dateOfCategoryMonth = _categoryDate.Month.ToString();
                string dateOfCategoryDay = _categoryDate.Day.ToString();

                if (_categoryDate.Day < 10 && _categoryDate.Day > 0)
                {
                    dateOfCategoryDay = ($"0{_categoryDate.Day}");
                }

                if (_categoryDate.Month < 10 && _categoryDate.Month > 0)
                {
                    dateOfCategoryMonth = ($"0{_categoryDate.Month}");
                }

                string dateOfCategory = string.Format("{0}/{1}/{2}", dateOfCategoryDay, dateOfCategoryMonth, dateOfCategoryYear);
                return dateOfCategory;
            }
            set { }

    }

    }
}
