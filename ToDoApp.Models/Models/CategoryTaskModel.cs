using System;

namespace ToDoApp.Models
{
    public class CategoryTaskModel
    {
        public int Id { get; set; }
        public Guid CategoryGuidId { get; set; }
        public Guid TaskGuidId { get; set; }
    }
}
