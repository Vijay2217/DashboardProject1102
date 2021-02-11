namespace Dash.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thirdCreate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserID", c => c.String());
        }
    }
}
