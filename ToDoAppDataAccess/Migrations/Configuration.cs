namespace ToDoAppDataAccess.Migrations
{
    using System.Data.Entity.Migrations;
    using ToDoApp.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ToDoAppDataAccess.ToDoAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ToDoAppDataAccess.ToDoAppDbContext context)
        {
        }
    }
}
