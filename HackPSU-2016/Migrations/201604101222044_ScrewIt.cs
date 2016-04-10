namespace HackPSU_2016.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScrewIt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatMessages", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChatMessages", "UserName");
        }
    }
}
