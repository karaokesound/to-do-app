namespace ToDoAppDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CategoryModels", "GuidId", c => c.Guid(nullable: false));
            AddColumn("dbo.CategoryTaskModels", "CategoryGuidId", c => c.Guid(nullable: false));
            AddColumn("dbo.CategoryTaskModels", "TaskGuidId", c => c.Guid(nullable: false));
            AddColumn("dbo.TaskModels", "GuidId", c => c.Guid(nullable: false));
            DropColumn("dbo.CategoryModels", "CategoryId");
            DropColumn("dbo.CategoryTaskModels", "CategoryId");
            DropColumn("dbo.CategoryTaskModels", "TaskId");
            DropColumn("dbo.TaskModels", "TaskId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TaskModels", "TaskId", c => c.Guid(nullable: false));
            AddColumn("dbo.CategoryTaskModels", "TaskId", c => c.Guid(nullable: false));
            AddColumn("dbo.CategoryTaskModels", "CategoryId", c => c.Guid(nullable: false));
            AddColumn("dbo.CategoryModels", "CategoryId", c => c.Guid(nullable: false));
            DropColumn("dbo.TaskModels", "GuidId");
            DropColumn("dbo.CategoryTaskModels", "TaskGuidId");
            DropColumn("dbo.CategoryTaskModels", "CategoryGuidId");
            DropColumn("dbo.CategoryModels", "GuidId");
        }
    }
}
