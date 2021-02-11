namespace Dash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "UserID");
        }
    }
}
