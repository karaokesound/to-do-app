using System;

namespace ToDoApp.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        public string Name { get; set; }
        public string Hashtag { get; set; }
        public DateTime CategoryDate { get; set; }
    }
}
