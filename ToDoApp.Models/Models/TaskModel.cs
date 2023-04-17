using System;

namespace ToDoApp.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public bool IsCompleted { get; set; }
    }
}
