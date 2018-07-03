namespace DvdLibraryWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DirectorEF", newName: "Director");
            RenameTable(name: "dbo.RatingEF", newName: "Rating");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Rating", newName: "RatingEF");
            RenameTable(name: "dbo.Director", newName: "DirectorEF");
        }
    }
}
