using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Manager",
                schema: "dbo",
                columns: table => new
                {
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.ManagerId);
                });

            migrationBuilder.CreateTable(
                name: "Resident",
                schema: "dbo",
                columns: table => new
                {
                    ResidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TCNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    VehiclePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resident", x => x.ResidentId);
                });

            migrationBuilder.CreateTable(
                name: "Apartment",
                schema: "dbo",
                columns: table => new
                {
                    ApartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Block = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ResidentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartment", x => x.ApartmentID);
                    table.ForeignKey(
                        name: "FK_Apartment_Resident_ResidentId",
                        column: x => x.ResidentId,
                        principalSchema: "dbo",
                        principalTable: "Resident",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManagerMessage",
                schema: "dbo",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    SenderManagerId = table.Column<int>(type: "int", nullable: false),
                    ReceiverResidentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerMessage", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_ManagerMessage_Manager_SenderManagerId",
                        column: x => x.SenderManagerId,
                        principalSchema: "dbo",
                        principalTable: "Manager",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManagerMessage_Resident_ReceiverResidentId",
                        column: x => x.ReceiverResidentId,
                        principalSchema: "dbo",
                        principalTable: "Resident",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResidentMessage",
                schema: "dbo",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    SenderResidentId = table.Column<int>(type: "int", nullable: false),
                    ReceiverManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentMessage", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_ResidentMessage_Manager_ReceiverManagerId",
                        column: x => x.ReceiverManagerId,
                        principalSchema: "dbo",
                        principalTable: "Manager",
                        principalColumn: "ManagerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ResidentMessage_Resident_SenderResidentId",
                        column: x => x.SenderResidentId,
                        principalSchema: "dbo",
                        principalTable: "Resident",
                        principalColumn: "ResidentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bill",
                schema: "dbo",
                columns: table => new
                {
                    BillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentID = table.Column<int>(type: "int", nullable: false),
                    BillType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bill", x => x.BillID);
                    table.ForeignKey(
                        name: "FK_Bill_Apartment_ApartmentID",
                        column: x => x.ApartmentID,
                        principalSchema: "dbo",
                        principalTable: "Apartment",
                        principalColumn: "ApartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dues",
                schema: "dbo",
                columns: table => new
                {
                    DuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentID = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dues", x => x.DuestID);
                    table.ForeignKey(
                        name: "FK_Dues_Apartment_ApartmentID",
                        column: x => x.ApartmentID,
                        principalSchema: "dbo",
                        principalTable: "Apartment",
                        principalColumn: "ApartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_ApartmentNumber",
                schema: "dbo",
                table: "Apartment",
                column: "ApartmentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apartment_ResidentId",
                schema: "dbo",
                table: "Apartment",
                column: "ResidentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bill_ApartmentID",
                schema: "dbo",
                table: "Bill",
                column: "ApartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Dues_ApartmentID",
                schema: "dbo",
                table: "Dues",
                column: "ApartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerMessage_ReceiverResidentId",
                schema: "dbo",
                table: "ManagerMessage",
                column: "ReceiverResidentId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerMessage_SenderManagerId",
                schema: "dbo",
                table: "ManagerMessage",
                column: "SenderManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentMessage_ReceiverManagerId",
                schema: "dbo",
                table: "ResidentMessage",
                column: "ReceiverManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentMessage_SenderResidentId",
                schema: "dbo",
                table: "ResidentMessage",
                column: "SenderResidentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bill",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Dues",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ManagerMessage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ResidentMessage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Apartment",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Manager",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Resident",
                schema: "dbo");
        }
    }
}
