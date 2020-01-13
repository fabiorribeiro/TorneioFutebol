namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajustes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Jogoes", new[] { "time1_id" });
            DropIndex("dbo.Jogoes", new[] { "time2_id" });
            DropIndex("dbo.Jogoes", new[] { "Torneio_id" });
            DropIndex("dbo.Times", new[] { "Torneio_id" });
            AddColumn("dbo.Jogoes", "IdTime1", c => c.Int(nullable: false));
            AddColumn("dbo.Jogoes", "IdTime2", c => c.Int(nullable: false));
            AddColumn("dbo.Jogoes", "TimeVencedor_Id", c => c.Int());
            AddColumn("dbo.Times", "IdTorneio", c => c.Int(nullable: false));
            CreateIndex("dbo.Jogoes", "Torneio_Id");
            CreateIndex("dbo.Jogoes", "Time1_Id");
            CreateIndex("dbo.Jogoes", "Time2_Id");
            CreateIndex("dbo.Jogoes", "TimeVencedor_Id");
            CreateIndex("dbo.Times", "Torneio_Id");
            AddForeignKey("dbo.Jogoes", "TimeVencedor_Id", "dbo.Times", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogoes", "TimeVencedor_Id", "dbo.Times");
            DropIndex("dbo.Times", new[] { "Torneio_Id" });
            DropIndex("dbo.Jogoes", new[] { "TimeVencedor_Id" });
            DropIndex("dbo.Jogoes", new[] { "Time2_Id" });
            DropIndex("dbo.Jogoes", new[] { "Time1_Id" });
            DropIndex("dbo.Jogoes", new[] { "Torneio_Id" });
            DropColumn("dbo.Times", "IdTorneio");
            DropColumn("dbo.Jogoes", "TimeVencedor_Id");
            DropColumn("dbo.Jogoes", "IdTime2");
            DropColumn("dbo.Jogoes", "IdTime1");
            CreateIndex("dbo.Times", "Torneio_id");
            CreateIndex("dbo.Jogoes", "Torneio_id");
            CreateIndex("dbo.Jogoes", "time2_id");
            CreateIndex("dbo.Jogoes", "time1_id");
        }
    }
}
