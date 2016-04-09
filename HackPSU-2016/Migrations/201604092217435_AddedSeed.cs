namespace HackPSU_2016.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSeed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.ChatMessages", "MessageTime", c => c.DateTime());
            AlterColumn("dbo.Notifications", "TimeSent", c => c.DateTime());
            AlterColumn("dbo.Notifications", "TimeDismissed", c => c.DateTime());
            AlterColumn("dbo.UsersToGroups", "DateApproved", c => c.DateTime());
            CreateIndex("dbo.Notifications", "ApplicationUser_Id");
            AddForeignKey("dbo.Notifications", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.UsersToGroups", "DateApproved", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notifications", "TimeDismissed", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Notifications", "TimeSent", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ChatMessages", "MessageTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Notifications", "ApplicationUser_Id");
        }
    }
}
