namespace DeskPowerApp.DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intialMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Draft",
                c => new
                    {
                        DraftId = c.Int(nullable: false, identity: true),
                        DraftTitle = c.String(nullable: false),
                        DraftContent = c.String(nullable: false),
                        DraftCategory = c.Int(nullable: false),
                        DraftImageUrl = c.String(),
                        DraftCreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.DraftId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.PersonDraft",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        DraftId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.DraftId })
                .ForeignKey("dbo.Draft", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Person", t => t.DraftId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.DraftId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonDraft", "DraftId", "dbo.Person");
            DropForeignKey("dbo.PersonDraft", "PersonId", "dbo.Draft");
            DropIndex("dbo.PersonDraft", new[] { "DraftId" });
            DropIndex("dbo.PersonDraft", new[] { "PersonId" });
            DropTable("dbo.PersonDraft");
            DropTable("dbo.Person");
            DropTable("dbo.Draft");
        }
    }
}
