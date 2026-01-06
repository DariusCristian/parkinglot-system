using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkingLotSystem.Migrations
{
    /// <inheritdoc />
    public partial class Subscriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriber",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriberID = table.Column<int>(type: "int", nullable: true),
                    SubscriptionPlanID = table.Column<int>(type: "int", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subscription_Subscriber_SubscriberID",
                        column: x => x.SubscriberID,
                        principalTable: "Subscriber",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Subscription_SubscriptionPlan_SubscriptionPlanID",
                        column: x => x.SubscriptionPlanID,
                        principalTable: "SubscriptionPlan",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_SubscriberID",
                table: "Subscription",
                column: "SubscriberID");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_SubscriptionPlanID",
                table: "Subscription",
                column: "SubscriptionPlanID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Subscriber");
        }
    }
}
