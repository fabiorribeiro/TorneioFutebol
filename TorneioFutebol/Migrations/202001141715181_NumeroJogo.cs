namespace TorneioFutebol.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumeroJogo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jogoes", "NumeroJogo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jogoes", "NumeroJogo");
        }
    }
}
