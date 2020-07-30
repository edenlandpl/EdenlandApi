using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EdenlandAPI.Migrations
{
    public partial class FirstModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "B_Beautician",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_Beautician", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "B_Treatments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameTreatment = table.Column<string>(nullable: true),
                    DescriptionTreatment = table.Column<string>(nullable: true),
                    TimeSpanTreatment = table.Column<TimeSpan>(nullable: false),
                    PriceTreatment = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_Treatments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "B_ BeauticiansTreatments",
                columns: table => new
                {
                    BeauticianId = table.Column<int>(nullable: false),
                    TreatmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B_ BeauticiansTreatments", x => new { x.BeauticianId, x.TreatmentId });
                    table.ForeignKey(
                        name: "FK_B_ BeauticiansTreatments_B_Beautician_BeauticianId",
                        column: x => x.BeauticianId,
                        principalTable: "B_Beautician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_B_ BeauticiansTreatments_B_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "B_Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    QuantityInPackage = table.Column<short>(nullable: false),
                    UnitOfMeasurement = table.Column<byte>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "B_Beautician",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 100, "Andżelika", "Wągrowiec" },
                    { 101, "Dorota", "Źdźbło" }
                });

            migrationBuilder.InsertData(
                table: "B_Treatments",
                columns: new[] { "Id", "DescriptionTreatment", "NameTreatment", "PriceTreatment", "TimeSpanTreatment" },
                values: new object[,]
                {
                    { 110, "Polewanie z konewki", "Bicze wodne", 120.0, new TimeSpan(0, 0, 10, 10, 0) },
                    { 111, "Gorzka czekolada z dodatkiem olejków ukoi Twoje zmysły i przyniesie ukojenie", "Masaż czekoladowy", 220.0, new TimeSpan(0, 0, 30, 10, 0) }
                });

            migrationBuilder.InsertData(
                table: "B_ BeauticiansTreatments",
                columns: new[] { "BeauticianId", "TreatmentId" },
                values: new object[] { 100, 110 });

            migrationBuilder.InsertData(
                table: "B_ BeauticiansTreatments",
                columns: new[] { "BeauticianId", "TreatmentId" },
                values: new object[] { 101, 110 });

            migrationBuilder.InsertData(
                table: "B_ BeauticiansTreatments",
                columns: new[] { "BeauticianId", "TreatmentId" },
                values: new object[] { 100, 111 });

            migrationBuilder.CreateIndex(
                name: "IX_B_ BeauticiansTreatments_TreatmentId",
                table: "B_ BeauticiansTreatments",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "B_ BeauticiansTreatments");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "B_Beautician");

            migrationBuilder.DropTable(
                name: "B_Treatments");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
