using System.Data.Entity;
using ToDoApp.Models;

namespace ToDoAppDataAccess
{
    public class ToDoAppDbContext : DbContext
    {
        public ToDoAppDbContext():base("ToDoAppDb")
        {
        }

        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CategoryTaskModel> CategoryTasks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
