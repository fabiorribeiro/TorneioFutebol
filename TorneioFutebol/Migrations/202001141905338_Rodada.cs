namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Rodada : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jogoes", "Rodada", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jogoes", "Rodada");
        }
    }
}
