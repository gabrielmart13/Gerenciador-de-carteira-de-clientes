using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace AgendaPro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    telefone = table.Column<string>(type: "longtext", nullable: false),
                    ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.idCliente);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "profissional",
                columns: table => new
                {
                    idProfissional = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: true),
                    telefone = table.Column<string>(type: "longtext", nullable: true),
                    ativo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    horaInicio = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    horaFinal = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profissional", x => x.idProfissional);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "servico",
                columns: table => new
                {
                    idServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    descricao = table.Column<string>(type: "longtext", nullable: true),
                    duracaoMinutos = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ativo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servico", x => x.idServico);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "agendamento",
                columns: table => new
                {
                    idAgendamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    idProfissional = table.Column<int>(type: "int", nullable: false),
                    idServico = table.Column<int>(type: "int", nullable: false),
                    dataHoraInicio = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    dataHoraFim = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    precoAplicado = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false),
                    observacao = table.Column<string>(type: "longtext", nullable: true),
                    dataCriacao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agendamento", x => x.idAgendamento);
                    table.ForeignKey(
                        name: "FK_agendamento_cliente_idCliente",
                        column: x => x.idCliente,
                        principalTable: "cliente",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_agendamento_profissional_idProfissional",
                        column: x => x.idProfissional,
                        principalTable: "profissional",
                        principalColumn: "idProfissional",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_agendamento_servico_idServico",
                        column: x => x.idServico,
                        principalTable: "servico",
                        principalColumn: "idServico",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pagamento",
                columns: table => new
                {
                    idPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idAgendamento = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dataPagamento = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    metodoPagamento = table.Column<string>(type: "longtext", nullable: false),
                    status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pagamento", x => x.idPagamento);
                    table.ForeignKey(
                        name: "FK_pagamento_agendamento_idAgendamento",
                        column: x => x.idAgendamento,
                        principalTable: "agendamento",
                        principalColumn: "idAgendamento",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_agendamento_idCliente",
                table: "agendamento",
                column: "idCliente");

            migrationBuilder.CreateIndex(
                name: "IX_agendamento_idProfissional",
                table: "agendamento",
                column: "idProfissional");

            migrationBuilder.CreateIndex(
                name: "IX_agendamento_idServico",
                table: "agendamento",
                column: "idServico");

            migrationBuilder.CreateIndex(
                name: "IX_cliente_email",
                table: "cliente",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pagamento_idAgendamento",
                table: "pagamento",
                column: "idAgendamento");

            migrationBuilder.CreateIndex(
                name: "IX_profissional_email",
                table: "profissional",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_servico_nome",
                table: "servico",
                column: "nome",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pagamento");

            migrationBuilder.DropTable(
                name: "agendamento");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "profissional");

            migrationBuilder.DropTable(
                name: "servico");
        }
    }
}
