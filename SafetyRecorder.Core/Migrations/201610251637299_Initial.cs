namespace SafetyRecorder.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Person",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    ChangedBy = c.String(nullable: false, maxLength: 200),
                    ChangedOn = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.SafetyObservation",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ObserverId = c.Int(nullable: false),
                        ObserveredOn = c.DateTime(nullable: false),
                        Location = c.String(),
                        OtherParticipantId = c.Int(nullable: false),
                        Subject = c.String(),
                        ChangedBy = c.String(nullable: false, maxLength: 200),
                        ChangedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.Outcome",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    SafetyObservationId = c.Int(nullable: false),
                    ChangedBy = c.String(nullable: false, maxLength: 200),
                    ChangedOn = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SafetyObservation", t => t.SafetyObservationId, cascadeDelete: true)
                .Index(t => t.SafetyObservationId);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Outcome", "SafetyObservationId", "dbo.SafetyObservation");
            DropForeignKey("dbo.SafetyObservation", "Id", "dbo.Person");
            DropIndex("dbo.SafetyObservation", new[] { "Id" });
            DropIndex("dbo.Outcome", new[] { "SafetyObservationId" });
            DropTable("dbo.Person");
            DropTable("dbo.Outcome");
            DropTable("dbo.SafetyObservation");
        }
    }
}
