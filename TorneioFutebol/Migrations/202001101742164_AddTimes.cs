namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Times", "Torneio_id", c => c.Int());
            CreateIndex("dbo.Times", "Torneio_id");
            AddForeignKey("dbo.Times", "Torneio_id", "dbo.Torneios", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Times", "Torneio_id", "dbo.Torneios");
            DropIndex("dbo.Times", new[] { "Torneio_id" });
            DropColumn("dbo.Times", "Torneio_id");
        }
    }
}
