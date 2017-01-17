namespace Election.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removingsomerequiredvaluesfromvote : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Votes", "UserToken", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Votes", "UserToken", c => c.String(nullable: false));
        }
    }
}
