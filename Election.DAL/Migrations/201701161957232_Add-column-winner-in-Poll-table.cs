namespace Election.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumnwinnerinPolltable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Polls", "Winner_Id", c => c.Int());
            CreateIndex("dbo.Polls", "Winner_Id");
            AddForeignKey("dbo.Polls", "Winner_Id", "dbo.Restaurants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Polls", "Winner_Id", "dbo.Restaurants");
            DropIndex("dbo.Polls", new[] { "Winner_Id" });
            DropColumn("dbo.Polls", "Winner_Id");
        }
    }
}
