namespace ToDoAppDataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Guid(nullable: false),
                        Name = c.String(),
                        Hashtag = c.String(),
                        CategoryDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaskModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TaskId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Value = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TaskModels");
            DropTable("dbo.CategoryModels");
        }
    }
}
