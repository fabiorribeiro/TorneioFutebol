namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajustes1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Times", "IdTorneio");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Times", "IdTorneio", c => c.Int(nullable: false));
        }
    }
}
