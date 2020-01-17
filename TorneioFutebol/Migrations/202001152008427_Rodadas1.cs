namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rodadas1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Torneios", "Rodadas");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Torneios", "Rodadas", c => c.Int(nullable: false));
        }
    }
}
