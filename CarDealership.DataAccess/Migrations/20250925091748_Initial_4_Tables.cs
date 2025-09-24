using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarDealership.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initial_4_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 300, nullable: false),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_CarBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "CarBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AvailableSku",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ProductionYear = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    FeatureSet = table.Column<string>(type: "TEXT", nullable: true),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailableSku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailableSku_CarBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "CarBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvailableSku_CarModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SoldSku",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SellingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ProductionYear = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: true),
                    FeatureSet = table.Column<string>(type: "TEXT", nullable: true),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldSku", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldSku_CarBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "CarBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SoldSku_CarModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CarBrands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bmw" },
                    { 2, "Mercedes" },
                    { 3, "Audi" },
                    { 4, "Volkswagen" },
                    { 5, "Peugeot" },
                    { 6, "Toyota" },
                    { 7, "Nissan" },
                    { 8, "Honda" },
                    { 9, "Lifan" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "BMW E30 M3" },
                    { 2, 1, "BMW X5" },
                    { 3, 1, "BMW X6" },
                    { 4, 1, "BMW M1" },
                    { 5, 1, "BMW M2" },
                    { 6, 2, "Mercedes-Benz GLE" },
                    { 7, 2, "Mercedes-Benz S-Class" },
                    { 8, 2, "Mercedes C-Class" },
                    { 9, 2, "Mercedes-AMG GT" },
                    { 10, 2, "Mercedes GLA-Class" },
                    { 11, 3, "Audi A3" },
                    { 12, 3, "Audi A5" },
                    { 13, 3, "Audi Q5" },
                    { 14, 3, "Audi Q3" },
                    { 15, 3, "Audi TT" },
                    { 16, 4, "Volkswagen Golf" },
                    { 17, 4, "Volkswagen Passat" },
                    { 18, 4, "Volkswagen Tiguan" },
                    { 19, 4, "Volkswagen Jetta" },
                    { 20, 4, "Volkswagen Touareg" },
                    { 21, 5, "Peugeot 208 hatchback" },
                    { 22, 5, "Peugeot 3008 SUV" },
                    { 23, 5, "Peugeot 206" },
                    { 24, 5, "Peugeot 3008" },
                    { 25, 5, "Peugeot 308" },
                    { 26, 6, "Toyota Camry" },
                    { 27, 6, "Toyota Corolla" },
                    { 28, 6, "Toyota RAV4" },
                    { 29, 6, "Toyota Tundra" },
                    { 30, 6, "Toyota Land Cruiser" },
                    { 31, 6, "Toyota Tacoma" },
                    { 32, 6, "Toyota Prius" },
                    { 33, 7, "Nissan Note" },
                    { 34, 7, "Nissan Sunny" },
                    { 35, 7, "Nissan Skyline" },
                    { 36, 7, "Nissan Juke" },
                    { 37, 7, "Nissan Murano" },
                    { 38, 7, "Nissan Qashqai" },
                    { 39, 8, "Honda Accord" },
                    { 40, 8, "Honda Civic Hybrid" },
                    { 41, 8, "Honda CR-V" },
                    { 42, 8, "Honda Odyssey" },
                    { 43, 8, "Honda Prelude" },
                    { 44, 8, "Honda Integra" },
                    { 45, 9, "Lifan X60" },
                    { 46, 9, "Lifan X70" },
                    { 47, 9, "Lifan X80" },
                    { 48, 9, "Lifan 820" },
                    { 49, 9, "Lifan Maiwei" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSku_BrandId",
                table: "AvailableSku",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_AvailableSku_ModelId",
                table: "AvailableSku",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarBrands_Name",
                table: "CarBrands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_BrandId",
                table: "CarModels",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_Name",
                table: "CarModels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoldSku_BrandId",
                table: "SoldSku",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldSku_ModelId",
                table: "SoldSku",
                column: "ModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableSku");

            migrationBuilder.DropTable(
                name: "SoldSku");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "CarBrands");
        }
    }
}
