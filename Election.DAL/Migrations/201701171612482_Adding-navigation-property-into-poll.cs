namespace Election.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingnavigationpropertyintopoll : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Polls", name: "Winner_Id", newName: "WinnerId");
            RenameIndex(table: "dbo.Polls", name: "IX_Winner_Id", newName: "IX_WinnerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Polls", name: "IX_WinnerId", newName: "IX_Winner_Id");
            RenameColumn(table: "dbo.Polls", name: "WinnerId", newName: "Winner_Id");
        }
    }
}
