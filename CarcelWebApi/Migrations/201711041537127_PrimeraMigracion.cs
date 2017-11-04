namespace CarcelWebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeraMigracion : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Condenas", newName: "Condena");
            RenameTable(name: "dbo.Delitoes", newName: "Delito");
            RenameTable(name: "dbo.Juezs", newName: "Juez");
            RenameTable(name: "dbo.Presoes", newName: "Preso");
            AddColumn("dbo.CondenaDelitoes", "Preso_ID", c => c.Int());
            CreateIndex("dbo.CondenaDelitoes", "Preso_ID");
            CreateIndex("dbo.Condena", "JuezId");
            AddForeignKey("dbo.Condena", "JuezId", "dbo.Juez", "ID");
            AddForeignKey("dbo.CondenaDelitoes", "Preso_ID", "dbo.Preso", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CondenaDelitoes", "Preso_ID", "dbo.Preso");
            DropForeignKey("dbo.Condena", "JuezId", "dbo.Juez");
            DropIndex("dbo.Condena", new[] { "JuezId" });
            DropIndex("dbo.CondenaDelitoes", new[] { "Preso_ID" });
            DropColumn("dbo.CondenaDelitoes", "Preso_ID");
            RenameTable(name: "dbo.Preso", newName: "Presoes");
            RenameTable(name: "dbo.Juez", newName: "Juezs");
            RenameTable(name: "dbo.Delito", newName: "Delitoes");
            RenameTable(name: "dbo.Condena", newName: "Condenas");
        }
    }
}
