namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTorneioJogo1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Jogoes", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jogoes", "Nome", c => c.Int(nullable: false));
        }
    }
}
