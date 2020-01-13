namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TotalTimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Torneios", "TotalTimes", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Torneios", "TotalTimes");
        }
    }
}
