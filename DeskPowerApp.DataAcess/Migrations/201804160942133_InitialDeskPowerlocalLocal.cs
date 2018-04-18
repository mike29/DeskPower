namespace DeskPowerApp.DataAcess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDeskPowerlocalLocal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Draft",
                c => new
                    {
                        DraftID = c.Int(nullable: false, identity: true),
                        DrafTitle = c.String(),
                        DraftContent = c.String(),
                        DraftCategory = c.Int(nullable: false),
                        DraftImage = c.String(),
                        DraftCreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DraftID);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.String(),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.DraftPerson",
                c => new
                    {
                        PersonRefId = c.Int(nullable: false),
                        DraftRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonRefId, t.DraftRefId })
                .ForeignKey("dbo.Person", t => t.PersonRefId, cascadeDelete: true)
                .ForeignKey("dbo.Draft", t => t.DraftRefId, cascadeDelete: true)
                .Index(t => t.PersonRefId)
                .Index(t => t.DraftRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DraftPerson", "DraftRefId", "dbo.Draft");
            DropForeignKey("dbo.DraftPerson", "PersonRefId", "dbo.Person");
            DropIndex("dbo.DraftPerson", new[] { "DraftRefId" });
            DropIndex("dbo.DraftPerson", new[] { "PersonRefId" });
            DropTable("dbo.DraftPerson");
            DropTable("dbo.Person");
            DropTable("dbo.Draft");
        }
    }
}
