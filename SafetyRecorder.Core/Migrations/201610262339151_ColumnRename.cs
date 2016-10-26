namespace SafetyRecorder.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ColumnRename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SafetyObservation", "ObservedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.SafetyObservation", "ObserveredOn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SafetyObservation", "ObserveredOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.SafetyObservation", "ObservedOn");
        }
    }
}
