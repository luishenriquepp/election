namespace Election.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        WeekOfYear = c.String(nullable: false, maxLength: 128),
                        Day = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.WeekOfYear);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestaurantId = c.Int(nullable: false),
                        UserToken = c.String(nullable: false),
                        Poll_WeekOfYear = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId, cascadeDelete: true)
                .ForeignKey("dbo.Polls", t => t.Poll_WeekOfYear)
                .Index(t => t.RestaurantId)
                .Index(t => t.Poll_WeekOfYear);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Adress = c.String(),
                        Neighborhood = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "Poll_WeekOfYear", "dbo.Polls");
            DropForeignKey("dbo.Votes", "RestaurantId", "dbo.Restaurants");
            DropIndex("dbo.Votes", new[] { "Poll_WeekOfYear" });
            DropIndex("dbo.Votes", new[] { "RestaurantId" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.Votes");
            DropTable("dbo.Polls");
        }
    }
}
