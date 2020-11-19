using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Zerog.Data.Migrations
{
    public partial class AddMotherboardModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chipsets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chipsets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormFactors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFactors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Interfaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interfaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotherboardManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherboardManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Socket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Socket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoundCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportedProcessors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportedProcessors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ManufacturerId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    SocketId = table.Column<int>(nullable: false),
                    ChipsetId = table.Column<int>(nullable: false),
                    MemoryTypeId = table.Column<int>(nullable: false),
                    MemorySpeed = table.Column<int>(nullable: false),
                    MemorySlots = table.Column<int>(nullable: false),
                    SoundCardId = table.Column<int>(nullable: false),
                    LanCardId = table.Column<int>(nullable: false),
                    FormFactorId = table.Column<int>(nullable: false),
                    Demensions = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motherboards_Chipsets_ChipsetId",
                        column: x => x.ChipsetId,
                        principalTable: "Chipsets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_FormFactors_FormFactorId",
                        column: x => x.FormFactorId,
                        principalTable: "FormFactors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_LanCards_LanCardId",
                        column: x => x.LanCardId,
                        principalTable: "LanCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_MotherboardManufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "MotherboardManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_MemoryTypes_MemoryTypeId",
                        column: x => x.MemoryTypeId,
                        principalTable: "MemoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_Socket_SocketId",
                        column: x => x.SocketId,
                        principalTable: "Socket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Motherboards_SoundCards_SoundCardId",
                        column: x => x.SoundCardId,
                        principalTable: "SoundCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotherboardImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(maxLength: 200, nullable: false),
                    MotherboardId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherboardImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotherboardImage_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotherboardInterface",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    MotherboardId = table.Column<int>(nullable: false),
                    InterfaceId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherboardInterface", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotherboardInterface_Interfaces_InterfaceId",
                        column: x => x.InterfaceId,
                        principalTable: "Interfaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MotherboardInterface_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotherboardPorts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    MotherboardId = table.Column<int>(nullable: false),
                    PortId = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherboardPorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotherboardPorts_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MotherboardPorts_Ports_PortId",
                        column: x => x.PortId,
                        principalTable: "Ports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotherboardSupportedProcessor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    MotherboardId = table.Column<int>(nullable: false),
                    SupportedProcessorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherboardSupportedProcessor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MotherboardSupportedProcessor_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MotherboardSupportedProcessor_SupportedProcessors_SupportedProcessorId",
                        column: x => x.SupportedProcessorId,
                        principalTable: "SupportedProcessors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chipsets_IsDeleted",
                table: "Chipsets",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_FormFactors_IsDeleted",
                table: "FormFactors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Interfaces_IsDeleted",
                table: "Interfaces",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_LanCards_IsDeleted",
                table: "LanCards",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MemoryTypes_IsDeleted",
                table: "MemoryTypes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardImage_IsDeleted",
                table: "MotherboardImage",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardImage_MotherboardId",
                table: "MotherboardImage",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardInterface_InterfaceId",
                table: "MotherboardInterface",
                column: "InterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardInterface_MotherboardId",
                table: "MotherboardInterface",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardManufacturers_IsDeleted",
                table: "MotherboardManufacturers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardPorts_MotherboardId",
                table: "MotherboardPorts",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardPorts_PortId",
                table: "MotherboardPorts",
                column: "PortId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_ChipsetId",
                table: "Motherboards",
                column: "ChipsetId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_FormFactorId",
                table: "Motherboards",
                column: "FormFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_IsDeleted",
                table: "Motherboards",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_LanCardId",
                table: "Motherboards",
                column: "LanCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_ManufacturerId",
                table: "Motherboards",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_MemoryTypeId",
                table: "Motherboards",
                column: "MemoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_SocketId",
                table: "Motherboards",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_SoundCardId",
                table: "Motherboards",
                column: "SoundCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardSupportedProcessor_IsDeleted",
                table: "MotherboardSupportedProcessor",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardSupportedProcessor_MotherboardId",
                table: "MotherboardSupportedProcessor",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherboardSupportedProcessor_SupportedProcessorId",
                table: "MotherboardSupportedProcessor",
                column: "SupportedProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Ports_IsDeleted",
                table: "Ports",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Socket_IsDeleted",
                table: "Socket",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SoundCards_IsDeleted",
                table: "SoundCards",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SupportedProcessors_IsDeleted",
                table: "SupportedProcessors",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MotherboardImage");

            migrationBuilder.DropTable(
                name: "MotherboardInterface");

            migrationBuilder.DropTable(
                name: "MotherboardPorts");

            migrationBuilder.DropTable(
                name: "MotherboardSupportedProcessor");

            migrationBuilder.DropTable(
                name: "Interfaces");

            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "SupportedProcessors");

            migrationBuilder.DropTable(
                name: "Chipsets");

            migrationBuilder.DropTable(
                name: "FormFactors");

            migrationBuilder.DropTable(
                name: "LanCards");

            migrationBuilder.DropTable(
                name: "MotherboardManufacturers");

            migrationBuilder.DropTable(
                name: "MemoryTypes");

            migrationBuilder.DropTable(
                name: "Socket");

            migrationBuilder.DropTable(
                name: "SoundCards");
        }
    }
}
