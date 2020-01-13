namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTorneioJogo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Jogoes", "TimeVencedor_Id", "dbo.Times");
            DropIndex("dbo.Jogoes", new[] { "TimeVencedor_Id" });
            DropColumn("dbo.Jogoes", "IdTime1");
            DropColumn("dbo.Jogoes", "IdTime2");
            DropColumn("dbo.Jogoes", "TimeVencedor_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jogoes", "TimeVencedor_Id", c => c.Int());
            AddColumn("dbo.Jogoes", "IdTime2", c => c.Int(nullable: false));
            AddColumn("dbo.Jogoes", "IdTime1", c => c.Int(nullable: false));
            CreateIndex("dbo.Jogoes", "TimeVencedor_Id");
            AddForeignKey("dbo.Jogoes", "TimeVencedor_Id", "dbo.Times", "Id");
        }
    }
}
