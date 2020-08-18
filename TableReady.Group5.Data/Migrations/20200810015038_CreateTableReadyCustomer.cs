using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TableReady.Group5.Data.Migrations
{
    public partial class CreateTableReadyCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(nullable: false),
                    RestaurantDescription = table.Column<string>(nullable: true),
                    RestaurantImage = table.Column<byte[]>(type: "Image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationStatus = table.Column<string>(nullable: true),
                    ReservationDate = table.Column<DateTime>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    RestaurantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservation_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Restaurant_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reward",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Points = table.Column<int>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    FreeProduct = table.Column<string>(nullable: true),
                    CustomerID = table.Column<int>(nullable: false),
                    RestaurantID = table.Column<int>(nullable: true),
                    IsChecked = table.Column<bool>(nullable: true),
                    CheckedValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reward", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reward_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reward_Restaurant_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WaitList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Position = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false),
                    RestaurantID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaitList", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WaitList_Customer_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customer",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WaitList_Restaurant_RestaurantID",
                        column: x => x.RestaurantID,
                        principalTable: "Restaurant",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "ID", "City", "Email", "FirstName", "LastName", "Password", "State", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Vancouver", "John@gmail.com", "John", "Robert", "password", "BC", "14t6f" },
                    { 2, "Calgary", "Rose@gmail.com", "Rose", "Wilson", "password", "AB", "5r4c1d" },
                    { 3, "Banff", "Sally@yahoo.com", "Sally", "Smith", "password", "AB", "1e2r3d3" },
                    { 4, "Edmonton", "Andrew@yahoo.com", "Andrew", "Jacob", "password", "AB", "t3b5d4" }
                });

            migrationBuilder.InsertData(
                table: "Restaurant",
                columns: new[] { "ID", "RestaurantDescription", "RestaurantImage", "RestaurantName" },
                values: new object[,]
                {
                    { 1, "Buckets, Feasts, Box Meals and More. Get Original Recipe Chicken Delivered Now!", null, "KFC" },
                    { 2, "Looking for some hometown goodness? Take a look at whats going on at your local A&W, stop in and lets us know how we are doing!", null, "A&W" },
                    { 3, "Treat yourself to some expertly made steak in either a classic or non-traditional steak house setting.", null, "SteakHouse" },
                    { 4, "Fast-food chain serving Mexican-inspired fare such as tacos, quesadillas & nachos.", null, "Taco Bell" }
                });

            migrationBuilder.InsertData(
                table: "Reservation",
                columns: new[] { "ID", "CustomerID", "ReservationDate", "ReservationStatus", "RestaurantID" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 5, 15, 13, 45, 0, 0, DateTimeKind.Unspecified), "Accept", 3 },
                    { 2, 2, new DateTime(2020, 8, 8, 16, 45, 0, 0, DateTimeKind.Unspecified), "Accept", 4 }
                });

            migrationBuilder.InsertData(
                table: "Reward",
                columns: new[] { "ID", "CheckedValue", "CustomerID", "Discount", "FreeProduct", "IsChecked", "Points", "RestaurantID" },
                values: new object[,]
                {
                    { 1, null, 2, 5m, "drink", false, 20, 1 },
                    { 4, null, 1, 0m, "drink", false, 25, 1 },
                    { 3, null, 4, 1m, "desert", false, 10, 2 },
                    { 2, null, 3, 2m, "", false, 50, 4 }
                });

            migrationBuilder.InsertData(
                table: "WaitList",
                columns: new[] { "ID", "CustomerID", "Position", "RestaurantID" },
                values: new object[,]
                {
                    { 1, 3, 2, 1 },
                    { 2, 1, 5, 2 },
                    { 3, 2, 4, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_CustomerID",
                table: "Reservation",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_RestaurantID",
                table: "Reservation",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_Reward_CustomerID",
                table: "Reward",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_Reward_RestaurantID",
                table: "Reward",
                column: "RestaurantID");

            migrationBuilder.CreateIndex(
                name: "IX_WaitList_CustomerID",
                table: "WaitList",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_WaitList_RestaurantID",
                table: "WaitList",
                column: "RestaurantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Reward");

            migrationBuilder.DropTable(
                name: "WaitList");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Restaurant");
        }
    }
}
