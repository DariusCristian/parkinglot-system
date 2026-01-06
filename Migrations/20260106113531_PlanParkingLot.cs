using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingLotSystem.Migrations
{
    /// <inheritdoc />
    public partial class PlanParkingLot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubscriptionPlan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    MonthlyPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    DurationDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlan", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PlanParkingLot",
                columns: table => new
                {
                    SubscriptionPlanID = table.Column<int>(type: "int", nullable: false),
                    ParkingLotID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanParkingLot", x => new { x.SubscriptionPlanID, x.ParkingLotID });
                    table.ForeignKey(
                        name: "FK_PlanParkingLot_ParkingLot_ParkingLotID",
                        column: x => x.ParkingLotID,
                        principalTable: "ParkingLot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanParkingLot_SubscriptionPlan_SubscriptionPlanID",
                        column: x => x.SubscriptionPlanID,
                        principalTable: "SubscriptionPlan",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanParkingLot_ParkingLotID",
                table: "PlanParkingLot",
                column: "ParkingLotID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanParkingLot");

            migrationBuilder.DropTable(
                name: "SubscriptionPlan");
        }
    }
}
