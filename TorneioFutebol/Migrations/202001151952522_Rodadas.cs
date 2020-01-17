namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rodadas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Torneios", "Rodadas", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Torneios", "Rodadas");
        }
    }
}
