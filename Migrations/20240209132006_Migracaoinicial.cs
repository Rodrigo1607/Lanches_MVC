﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lanches_Mac.Migrations
{
    /// <inheritdoc />
    public partial class Migracaoinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategotiaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoriaNome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategotiaId);
                });

            migrationBuilder.CreateTable(
                name: "Lanche",
                columns: table => new
                {
                    LancheId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    DescricaoCurta = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DescricaoDetalhada = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ImagemUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ImagemThumbnailUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ISLanchePreferido = table.Column<bool>(type: "bit", nullable: false),
                    EmEstoque = table.Column<bool>(type: "bit", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lanche", x => x.LancheId);
                    table.ForeignKey(
                        name: "FK_Lanche_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categoria",
                        principalColumn: "CategotiaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lanche_CategoriaId",
                table: "Lanche",
                column: "CategoriaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lanche");

            migrationBuilder.DropTable(
                name: "Categoria");
        }
    }
}
