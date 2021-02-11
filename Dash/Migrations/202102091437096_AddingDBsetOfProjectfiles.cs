namespace Dash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDBsetOfProjectfiles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameP = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProjectFiles");
        }
    }
}
