namespace DvdLibraryWebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DirectorEF",
                c => new
                    {
                        DirectorId = c.Int(nullable: false, identity: true),
                        DirectorName = c.String(),
                    })
                .PrimaryKey(t => t.DirectorId);
            
            CreateTable(
                "dbo.RatingEF",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        Rating = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.RatingId);

            CreateTable(
                "dbo.DVDEF",
                c => new
                {
                    DvdId = c.Int(nullable: false, identity: true),
                    RatingId = c.Int(nullable: false),
                    DirectorId = c.Int(nullable: false),
                    Title = c.String(maxLength: 30),
                    ReleaseYear = c.Int(nullable: false),
                    Notes = c.String(maxLength: 500),
                })
                .PrimaryKey(t => t.DvdId)
                .ForeignKey("dbo.DirectorEF", t => t.DirectorId, cascadeDelete: true)
                .ForeignKey("dbo.RatingEF", t => t.RatingId, cascadeDelete: true)
                .Index(t => t.RatingId)
                .Index(t => t.DirectorId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DVDEF", "RatingId", "dbo.RatingEF");
            DropForeignKey("dbo.DVDEF", "DirectorId", "dbo.DirectorEF");
            DropIndex("dbo.DVDEF", new[] { "DirectorId" });
            DropIndex("dbo.DVDEF", new[] { "RatingId" });
            DropTable("dbo.RatingEF");
            DropTable("dbo.DVDEF");
            DropTable("dbo.DirectorEF");
        }
    }
}
