namespace ToDoAppDataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class categorytasktable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CategoryTaskModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Guid(nullable: false),
                        TaskId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CategoryTaskModels");
        }
    }
}
