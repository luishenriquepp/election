namespace Election.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changingpollprimarykeytoint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Votes", "Poll_WeekOfYear", "dbo.Polls");
            DropIndex("dbo.Votes", new[] { "Poll_WeekOfYear" });
            RenameColumn(table: "dbo.Votes", name: "Poll_WeekOfYear", newName: "Poll_Id");
            DropPrimaryKey("dbo.Polls");
            AddColumn("dbo.Polls", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Polls", "DayOfWeek", c => c.Int(nullable: false));
            AlterColumn("dbo.Polls", "WeekOfYear", c => c.String());
            AlterColumn("dbo.Votes", "Poll_Id", c => c.Int());
            AddPrimaryKey("dbo.Polls", "Id");
            CreateIndex("dbo.Votes", "Poll_Id");
            AddForeignKey("dbo.Votes", "Poll_Id", "dbo.Polls", "Id");
            DropColumn("dbo.Polls", "Day");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Polls", "Day", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Votes", "Poll_Id", "dbo.Polls");
            DropIndex("dbo.Votes", new[] { "Poll_Id" });
            DropPrimaryKey("dbo.Polls");
            AlterColumn("dbo.Votes", "Poll_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Polls", "WeekOfYear", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Polls", "DayOfWeek");
            DropColumn("dbo.Polls", "Id");
            AddPrimaryKey("dbo.Polls", "WeekOfYear");
            RenameColumn(table: "dbo.Votes", name: "Poll_Id", newName: "Poll_WeekOfYear");
            CreateIndex("dbo.Votes", "Poll_WeekOfYear");
            AddForeignKey("dbo.Votes", "Poll_WeekOfYear", "dbo.Polls", "WeekOfYear");
        }
    }
}
