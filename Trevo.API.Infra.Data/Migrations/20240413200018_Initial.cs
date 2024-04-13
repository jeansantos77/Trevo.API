using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Trevo.API.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acessorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acessorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cambios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cambios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasDespesas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasDespesas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasVeiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Combustiveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combustiveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormasPagamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPagamento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacoesVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacoesVeiculo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposDespesa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDespesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Login = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Senha = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Perfil = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Placa = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false),
                    Renavam = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    AnoFabricacao = table.Column<short>(type: "smallint", nullable: false),
                    AnoModelo = table.Column<short>(type: "smallint", nullable: false),
                    Portas = table.Column<short>(type: "smallint", nullable: false),
                    NumeroMotor = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    Chassi = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CategoriaVeiculoId = table.Column<int>(type: "integer", nullable: false),
                    ModeloId = table.Column<int>(type: "integer", nullable: false),
                    VersaoId = table.Column<int>(type: "integer", nullable: false),
                    CorId = table.Column<int>(type: "integer", nullable: false),
                    CombustivelId = table.Column<int>(type: "integer", nullable: false),
                    CambioId = table.Column<int>(type: "integer", nullable: false),
                    SituacaoVeiculoId = table.Column<int>(type: "integer", nullable: false),
                    ValorVenda = table.Column<double>(type: "numeric(18,2)", nullable: true),
                    ValorMinimoVenda = table.Column<double>(type: "numeric(18,2)", nullable: true),
                    ValorFipeEntrada = table.Column<double>(type: "numeric(18,2)", nullable: true),
                    ValorFipeAtual = table.Column<double>(type: "numeric(18,2)", nullable: true),
                    CodigoFipe = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: true),
                    Obs = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MarcaId = table.Column<int>(type: "integer", nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelos_Marcas_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "Marcas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UF = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    PaisId = table.Column<int>(type: "integer", nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estados_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FotosVeiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Caminho = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nome = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    VeiculoId = table.Column<int>(type: "integer", nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotosVeiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FotosVeiculo_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Versoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ModeloId = table.Column<int>(type: "integer", nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Versoes_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    EstadoId = table.Column<int>(type: "integer", nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Nascimento = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Complemento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CidadeId = table.Column<int>(type: "integer", nullable: false),
                    FormaPagamentoId = table.Column<int>(type: "integer", nullable: false),
                    Obs = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Clientes_FormasPagamento_FormaPagamentoId",
                        column: x => x.FormaPagamentoId,
                        principalTable: "FormasPagamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    Cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    Logradouro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CidadeId = table.Column<int>(type: "integer", nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Financeiras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    Contato = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Logradouro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CidadeId = table.Column<int>(type: "integer", nullable: false),
                    Obs = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financeiras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financeiras_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    TipoPessoa = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    Contato = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Logradouro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CidadeId = table.Column<int>(type: "integer", nullable: false),
                    Obs = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fornecedores_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Cep = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    Logradouro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Numero = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Bairro = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CidadeId = table.Column<int>(type: "integer", nullable: false),
                    Obs = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendedores_Cidades_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "Cidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ModelosDesejados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ModeloId = table.Column<int>(type: "integer", nullable: false),
                    VersaoId = table.Column<int>(type: "integer", nullable: true),
                    CorId = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    CriadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp", nullable: false),
                    AtualizadoPor = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelosDesejados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelosDesejados_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModelosDesejados_Cores_CorId",
                        column: x => x.CorId,
                        principalTable: "Cores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModelosDesejados_Modelos_ModeloId",
                        column: x => x.ModeloId,
                        principalTable: "Modelos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ModelosDesejados_Versoes_VersaoId",
                        column: x => x.VersaoId,
                        principalTable: "Versoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidades",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CidadeId",
                table: "Clientes",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_FormaPagamentoId",
                table: "Clientes",
                column: "FormaPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_CidadeId",
                table: "Empresas",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_PaisId",
                table: "Estados",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Financeiras_CidadeId",
                table: "Financeiras",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fornecedores_CidadeId",
                table: "Fornecedores",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_FotosVeiculo_VeiculoId",
                table: "FotosVeiculo",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_MarcaId",
                table: "Modelos",
                column: "MarcaId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelosDesejados_ClienteId_ModeloId_VersaoId_CorId",
                table: "ModelosDesejados",
                columns: new[] { "ClienteId", "ModeloId", "VersaoId", "CorId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModelosDesejados_CorId",
                table: "ModelosDesejados",
                column: "CorId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelosDesejados_ModeloId",
                table: "ModelosDesejados",
                column: "ModeloId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelosDesejados_VersaoId",
                table: "ModelosDesejados",
                column: "VersaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Login",
                table: "Usuarios",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendedores_CidadeId",
                table: "Vendedores",
                column: "CidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Versoes_ModeloId",
                table: "Versoes",
                column: "ModeloId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acessorios");

            migrationBuilder.DropTable(
                name: "Cambios");

            migrationBuilder.DropTable(
                name: "CategoriasDespesas");

            migrationBuilder.DropTable(
                name: "CategoriasVeiculo");

            migrationBuilder.DropTable(
                name: "Combustiveis");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Financeiras");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "FotosVeiculo");

            migrationBuilder.DropTable(
                name: "ModelosDesejados");

            migrationBuilder.DropTable(
                name: "SituacoesVeiculo");

            migrationBuilder.DropTable(
                name: "TiposDespesa");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Cores");

            migrationBuilder.DropTable(
                name: "Versoes");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "FormasPagamento");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
