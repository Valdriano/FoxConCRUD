namespace FoxConCRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "SYSTEM.DEPARTAMENTOS",
                c => new
                    {
                        id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        name = c.String(nullable: false, maxLength: 54),
                        active = c.String(nullable: false, maxLength: 1),
                        created_at = c.DateTime(nullable: false),
                        modifield_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "SYSTEM.FUNCIONARIOS",
                c => new
                    {
                        id = c.Decimal(nullable: false, precision: 10, scale: 0, identity: true),
                        id_departamento = c.Decimal(nullable: false, precision: 10, scale: 0),
                        name = c.String(nullable: false, maxLength: 104),
                        salary = c.Decimal(nullable: false, precision: 10, scale: 2),
                        gender = c.String(nullable: false, maxLength: 1),
                        active = c.String(nullable: false, maxLength: 1),
                        created_at = c.DateTime(nullable: false),
                        modifield_at = c.DateTime(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("SYSTEM.DEPARTAMENTOS", t => t.id_departamento)
                .Index(t => t.id_departamento);
            
        }
        
        public override void Down()
        {
            DropForeignKey("SYSTEM.FUNCIONARIOS", "id_departamento", "SYSTEM.DEPARTAMENTOS");
            DropIndex("SYSTEM.FUNCIONARIOS", new[] { "id_departamento" });
            DropTable("SYSTEM.FUNCIONARIOS");
            DropTable("SYSTEM.DEPARTAMENTOS");
        }
    }
}
