using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RPE.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Priority = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    Vendor = table.Column<string>(maxLength: 255, nullable: true),
                    Can = table.Column<string>(maxLength: 255, nullable: false),
                    ObjectClass = table.Column<string>(maxLength: 255, nullable: true),
                    PurchaseAmount = table.Column<string>(nullable: false),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Priority = table.Column<int>(nullable: false),
                    Attendee = table.Column<string>(maxLength: 500, nullable: false),
                    Vendor = table.Column<string>(maxLength: 255, nullable: true),
                    Hours = table.Column<int>(nullable: false),
                    Can = table.Column<string>(maxLength: 255, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    TrainingAmount = table.Column<double>(nullable: false),
                    ApprovedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Priority = table.Column<int>(nullable: false),
                    Travelername = table.Column<string>(maxLength: 500, nullable: false),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    State = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    Can = table.Column<string>(maxLength: 100, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ApprovedDate = table.Column<DateTime>(nullable: false),
                    AuthNumber = table.Column<string>(maxLength: 100, nullable: true),
                    AuthAmount = table.Column<double>(nullable: false),
                    VoucherAmount = table.Column<double>(nullable: false),
                    VoucherApprovedDate = table.Column<DateTime>(nullable: false),
                    TravelStatus = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Attachmentes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MimeType = table.Column<string>(maxLength: 255, nullable: false),
                    Path = table.Column<string>(maxLength: 500, nullable: true),
                    CreatedBy = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    Purchaseid = table.Column<int>(nullable: true),
                    Trainingid = table.Column<int>(nullable: true),
                    Travelid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachmentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachmentes_Purchases_Purchaseid",
                        column: x => x.Purchaseid,
                        principalTable: "Purchases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachmentes_Trainings_Trainingid",
                        column: x => x.Trainingid,
                        principalTable: "Trainings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachmentes_Travels_Travelid",
                        column: x => x.Travelid,
                        principalTable: "Travels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(maxLength: 2000, nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    Purchaseid = table.Column<int>(nullable: true),
                    Trainingid = table.Column<int>(nullable: true),
                    Travelid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Purchases_Purchaseid",
                        column: x => x.Purchaseid,
                        principalTable: "Purchases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_Trainings_Trainingid",
                        column: x => x.Trainingid,
                        principalTable: "Trainings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notes_Travels_Travelid",
                        column: x => x.Travelid,
                        principalTable: "Travels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(maxLength: 255, nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    LastUpdateDate = table.Column<DateTime>(nullable: false),
                    Purchaseid = table.Column<int>(nullable: true),
                    Trainingid = table.Column<int>(nullable: true),
                    Travelid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Purchases_Purchaseid",
                        column: x => x.Purchaseid,
                        principalTable: "Purchases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tags_Trainings_Trainingid",
                        column: x => x.Trainingid,
                        principalTable: "Trainings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tags_Travels_Travelid",
                        column: x => x.Travelid,
                        principalTable: "Travels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachmentes_Purchaseid",
                table: "Attachmentes",
                column: "Purchaseid");

            migrationBuilder.CreateIndex(
                name: "IX_Attachmentes_Trainingid",
                table: "Attachmentes",
                column: "Trainingid");

            migrationBuilder.CreateIndex(
                name: "IX_Attachmentes_Travelid",
                table: "Attachmentes",
                column: "Travelid");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Purchaseid",
                table: "Notes",
                column: "Purchaseid");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Trainingid",
                table: "Notes",
                column: "Trainingid");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_Travelid",
                table: "Notes",
                column: "Travelid");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Purchaseid",
                table: "Tags",
                column: "Purchaseid");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Trainingid",
                table: "Tags",
                column: "Trainingid");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Travelid",
                table: "Tags",
                column: "Travelid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachmentes");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Travels");
        }
    }
}
