namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jogoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.Int(nullable: false),
                        idTimeVencedor = c.Int(nullable: false),
                        time1_id = c.Int(),
                        time2_id = c.Int(),
                        Torneio_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Times", t => t.time1_id)
                .ForeignKey("dbo.Times", t => t.time2_id)
                .ForeignKey("dbo.Torneios", t => t.Torneio_id)
                .Index(t => t.time1_id)
                .Index(t => t.time2_id)
                .Index(t => t.Torneio_id);
            
            CreateTable(
                "dbo.Times",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Torneios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogoes", "Torneio_id", "dbo.Torneios");
            DropForeignKey("dbo.Jogoes", "time2_id", "dbo.Times");
            DropForeignKey("dbo.Jogoes", "time1_id", "dbo.Times");
            DropIndex("dbo.Jogoes", new[] { "Torneio_id" });
            DropIndex("dbo.Jogoes", new[] { "time2_id" });
            DropIndex("dbo.Jogoes", new[] { "time1_id" });
            DropTable("dbo.Torneios");
            DropTable("dbo.Times");
            DropTable("dbo.Jogoes");
        }
    }
}
