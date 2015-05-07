namespace Integra.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Modulo",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);

            CreateTable(
                "dbo.Perfil",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Grupo_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Grupos", t => t.Grupo_Codigo)
                .Index(t => t.Grupo_Codigo);

            CreateTable(
                "dbo.Grupos",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);

            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        PenultimoAcesso = c.DateTime(nullable: false),
                        NomeDeUsuario = c.String(),
                        Senha = c.String(),
                        UltimoAcesso = c.DateTime(nullable: false),
                        DataDeCriacao = c.DateTime(nullable: false),
                        Perfil_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Perfil", t => t.Perfil_Codigo, cascadeDelete: true)
                .Index(t => t.Perfil_Codigo);

            CreateTable(
                "dbo.TipoDeCrm",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);

            CreateTable(
                "dbo.CRM",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        NumeroDoCRM = c.String(),
                        Tipo_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.TipoDeCrm", t => t.Tipo_Codigo)
                .Index(t => t.Tipo_Codigo);

            CreateTable(
                "dbo.Departamento",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);

            CreateTable(
                "dbo.Cargo",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);

            CreateTable(
                "dbo.Pessoa",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        Inativo = c.Boolean(nullable: false),
                        Descricao = c.String(),
                        Departamento_Codigo = c.Int(),
                        Cargo_Codigo = c.Int(),
                        CRM_Codigo = c.Int(),
                        Usuario_Codigo = c.Int(),
                        Programa_Codigo = c.Int(),
                        TipoDaPessoa = c.Byte(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Departamento", t => t.Departamento_Codigo)
                .ForeignKey("dbo.Cargo", t => t.Cargo_Codigo)
                .ForeignKey("dbo.CRM", t => t.CRM_Codigo)
                .ForeignKey("dbo.Usuario", t => t.Usuario_Codigo)
                .ForeignKey("dbo.Programa", t => t.Programa_Codigo)
                .Index(t => t.Departamento_Codigo)
                .Index(t => t.Cargo_Codigo)
                .Index(t => t.CRM_Codigo)
                .Index(t => t.Usuario_Codigo)
                .Index(t => t.Programa_Codigo);

            CreateTable(
                "dbo.Programa",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.Codigo);

            CreateTable(
                "dbo.Equipe",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Programa_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Programa", t => t.Programa_Codigo, cascadeDelete: true)
                .Index(t => t.Programa_Codigo);

            CreateTable(
                "dbo.Fatura",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(),
                        MesDeReferencia = c.Int(nullable: false),
                        Tipo = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Documento = c.Int(nullable: false),
                        NumeroDoDocumento = c.String(),
                        Status = c.Int(nullable: false),
                        Programa_Codigo = c.Int(),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.Programa", t => t.Programa_Codigo)
                .Index(t => t.Programa_Codigo);

            CreateTable(
                "dbo.PerfilModulo",
                c => new
                    {
                        Perfil_Codigo = c.Int(nullable: false),
                        Modulo_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Perfil_Codigo, t.Modulo_Codigo })
                .ForeignKey("dbo.Perfil", t => t.Perfil_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Modulo", t => t.Modulo_Codigo, cascadeDelete: true)
                .Index(t => t.Perfil_Codigo)
                .Index(t => t.Modulo_Codigo);

            CreateTable(
                "dbo.EquipeFuncionario",
                c => new
                    {
                        Equipe_Codigo = c.Int(nullable: false),
                        Funcionario_Codigo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Equipe_Codigo, t.Funcionario_Codigo })
                .ForeignKey("dbo.Equipe", t => t.Equipe_Codigo, cascadeDelete: true)
                .ForeignKey("dbo.Pessoa", t => t.Funcionario_Codigo, cascadeDelete: true)
                .Index(t => t.Equipe_Codigo)
                .Index(t => t.Funcionario_Codigo);
            Sql(Properties.Resources.Initial);
        }

        public override void Down()
        {
            DropIndex("dbo.EquipeFuncionario", new[] { "Funcionario_Codigo" });
            DropIndex("dbo.EquipeFuncionario", new[] { "Equipe_Codigo" });
            DropIndex("dbo.PerfilModulo", new[] { "Modulo_Codigo" });
            DropIndex("dbo.PerfilModulo", new[] { "Perfil_Codigo" });
            DropIndex("dbo.Fatura", new[] { "Programa_Codigo" });
            DropIndex("dbo.Equipe", new[] { "Programa_Codigo" });
            DropIndex("dbo.Pessoa", new[] { "Programa_Codigo" });
            DropIndex("dbo.Pessoa", new[] { "Usuario_Codigo" });
            DropIndex("dbo.Pessoa", new[] { "CRM_Codigo" });
            DropIndex("dbo.Pessoa", new[] { "Cargo_Codigo" });
            DropIndex("dbo.Pessoa", new[] { "Departamento_Codigo" });
            DropIndex("dbo.CRM", new[] { "Tipo_Codigo" });
            DropIndex("dbo.Usuario", new[] { "Perfil_Codigo" });
            DropIndex("dbo.Perfil", new[] { "Grupo_Codigo" });
            DropForeignKey("dbo.EquipeFuncionario", "Funcionario_Codigo", "dbo.Pessoa");
            DropForeignKey("dbo.EquipeFuncionario", "Equipe_Codigo", "dbo.Equipe");
            DropForeignKey("dbo.PerfilModulo", "Modulo_Codigo", "dbo.Modulo");
            DropForeignKey("dbo.PerfilModulo", "Perfil_Codigo", "dbo.Perfil");
            DropForeignKey("dbo.Fatura", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.Equipe", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.Pessoa", "Programa_Codigo", "dbo.Programa");
            DropForeignKey("dbo.Pessoa", "Usuario_Codigo", "dbo.Usuario");
            DropForeignKey("dbo.Pessoa", "CRM_Codigo", "dbo.CRM");
            DropForeignKey("dbo.Pessoa", "Cargo_Codigo", "dbo.Cargo");
            DropForeignKey("dbo.Pessoa", "Departamento_Codigo", "dbo.Departamento");
            DropForeignKey("dbo.CRM", "Tipo_Codigo", "dbo.TipoDeCrm");
            DropForeignKey("dbo.Usuario", "Perfil_Codigo", "dbo.Perfil");
            DropForeignKey("dbo.Perfil", "Grupo_Codigo", "dbo.Grupos");
            DropTable("dbo.EquipeFuncionario");
            DropTable("dbo.PerfilModulo");
            DropTable("dbo.Fatura");
            DropTable("dbo.Equipe");
            DropTable("dbo.Programa");
            DropTable("dbo.Pessoa");
            DropTable("dbo.Cargo");
            DropTable("dbo.Departamento");
            DropTable("dbo.CRM");
            DropTable("dbo.TipoDeCrm");
            DropTable("dbo.Usuario");
            DropTable("dbo.Grupos");
            DropTable("dbo.Perfil");
            DropTable("dbo.Modulo");
        }
    }
}
