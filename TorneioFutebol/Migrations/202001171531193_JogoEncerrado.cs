namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JogoEncerrado : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jogoes", "JogoEncerrado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jogoes", "JogoEncerrado");
        }
    }
}
