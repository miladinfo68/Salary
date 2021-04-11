using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wage.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessLinks",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Area = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Controller = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessLinks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupManagers",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ProfCode = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    ProfName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BaseAmount = table.Column<string>(maxLength: 10, nullable: false),
                    Year = table.Column<string>(maxLength: 4, nullable: true),
                    Month = table.Column<string>(maxLength: 2, nullable: true),
                    StartAt = table.Column<string>(maxLength: 10, nullable: true),
                    ChkCouncil = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    CouncilDate = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupManagers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    HolidayDate = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Username = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenExpireTime = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupManagerDetails",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    EntranceDate = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    EntranceTime = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    ExitTime = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    GroupManagerId = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupManagerDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupManagerDetails_GroupManagers_GroupManagerId",
                        column: x => x.GroupManagerId,
                        principalTable: "GroupManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupManagerSchedules",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    EntranceDate = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    EntranceTime = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    ExitTime = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    MinTime = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    GroupManagerId = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupManagerSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupManagerSchedules_GroupManagers_GroupManagerId",
                        column: x => x.GroupManagerId,
                        principalTable: "GroupManagers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleAccesses",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    RoleId = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    AccessLinkId = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleAccesses_AccessLinks_AccessLinkId",
                        column: x => x.AccessLinkId,
                        principalTable: "AccessLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleAccesses_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    UserId = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    RoleId = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "GroupManagers",
                columns: new[] { "Id", "Active", "BaseAmount", "CouncilDate", "Month", "ProfCode", "ProfName", "StartAt", "Year" },
                values: new object[,]
                {
                    { 1m, true, "1000000", null, "01", "10", "فربد ساسانی", "1399/01/01", "1399" },
                    { 12m, true, "45000", null, "08", "12", "محمد سرگزی", "1399/08/01", "1399" },
                    { 11m, true, "63000", null, "08", "11", "مهدی جلالی", "1399/08/01", "1399" },
                    { 10m, true, "145266", null, "08", "10", "فربد ساسانی", "1399/08/01", "1399" },
                    { 8m, true, "800000", null, "07", "11", "مهدی جلالی", "1399/07/01", "1399" },
                    { 7m, true, "1000000", null, "07", "10", "فربد ساسانی", "1399/07/01", "1399" },
                    { 9m, true, "500000", null, "07", "12", "محمد سرگزی", "1399/07/01", "1399" },
                    { 5m, true, "5000", null, "02", "11", "مهدی جلالی", "1399/02/01", "1399" },
                    { 4m, true, "20000", null, "02", "10", "فربد ساسانی", "1399/02/01", "1399" },
                    { 3m, true, "500000", null, "01", "12", "محمد سرگزی", "1399/01/01", "1399" },
                    { 2m, true, "800000", null, "01", "11", "مهدی جلالی", "1399/01/01", "1399" },
                    { 6m, true, "70000", null, "02", "12", "محمد سرگزی", "1399/02/01", "1399" }
                });

            migrationBuilder.InsertData(
                table: "Holidays",
                columns: new[] { "Id", "Active", "HolidayDate", "Note" },
                values: new object[,]
                {
                    { 7m, true, "1399/09/13", "برف سنگین" },
                    { 10m, true, "1399/12/12", "آلودگی هوا" },
                    { 9m, true, "1399/11/11", "آلودگی هوا" },
                    { 8m, true, "1399/10/18", "آلودگی هوا" },
                    { 6m, true, "1399/09/12", "برف سنگین" },
                    { 2m, true, "1399/07/10", "آلودگی هوا" },
                    { 4m, true, "1399/08/01", "برف سنگین" },
                    { 3m, true, "1399/07/27", "آلودگی هوا" },
                    { 1m, true, "1399/07/03", "آلودگی هوا" },
                    { 5m, true, "1399/08/19", "سقوط هواپیما" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Active", "DisplayName", "RoleName" },
                values: new object[,]
                {
                    { 1m, true, "کاربر ارشد", "Admin" },
                    { 2m, true, "کاربر", "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Active", "FirstName", "LastName", "Password", "Token", "TokenExpireTime", "Username" },
                values: new object[,]
                {
                    { 2m, true, "فربد", "ساسانی", "GEwa01iaRNvdbsOGhIFi4w==", null, null, "feri@gmail.com" },
                    { 1m, true, "میلاد", "جلالی", "GEwa01iaRNvdbsOGhIFi4w==", null, null, "milad@gmail.com" },
                    { 3m, true, "رضا", "عطاران", "GEwa01iaRNvdbsOGhIFi4w==", null, null, "reza@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId" },
                values: new object[,]
                {
                    { 1m, true, "1399/01/01", "09:00", "00:30", 1m },
                    { 6m, true, "1399/01/02", "09:00", "09:30", 2m }
                });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId", "IsOnline" },
                values: new object[] { 7m, true, "1399/01/03", "08:30", "14:50", 2m, true });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId" },
                values: new object[,]
                {
                    { 15m, true, "1399/01/08", "08:00", "10:00", 2m },
                    { 16m, true, "1399/01/09", "08:00", "11:30", 2m }
                });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId", "IsOnline" },
                values: new object[] { 17m, true, "1399/01/10", "08:30", "14:50", 2m, true });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId" },
                values: new object[,]
                {
                    { 20m, true, "1399/01/10", "09:00", "11:00", 3m },
                    { 19m, true, "1399/01/09", "08:00", "11:00", 3m }
                });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId", "IsOnline" },
                values: new object[] { 18m, true, "1399/01/08", "08:00", "11:00", 3m, true });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId" },
                values: new object[,]
                {
                    { 10m, true, "1399/01/04", "09:00", "09:30", 3m },
                    { 9m, true, "1399/01/02", "08:00", "11:00", 3m }
                });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId", "IsOnline" },
                values: new object[] { 8m, true, "1399/01/01", "08:00", "11:00", 3m, true });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId" },
                values: new object[] { 14m, true, "1399/01/14", "08:00", "10:00", 1m });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId", "IsOnline" },
                values: new object[] { 13m, true, "1399/01/10", "08:00", "10:00", 1m, true });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId" },
                values: new object[,]
                {
                    { 12m, true, "1399/01/09", "08:00", "15:00", 1m },
                    { 11m, true, "1399/01/08", "08:00", "10:00", 1m },
                    { 4m, true, "1399/01/04", "08:00", "10:00", 1m }
                });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId", "IsOnline" },
                values: new object[] { 3m, true, "1399/01/03", "08:00", "10:00", 1m, true });

            migrationBuilder.InsertData(
                table: "GroupManagerDetails",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId" },
                values: new object[,]
                {
                    { 2m, true, "1399/01/02", "08:00", "15:00", 1m },
                    { 5m, true, "1399/01/01", "08:00", "10:00", 2m }
                });

            migrationBuilder.InsertData(
                table: "GroupManagerSchedules",
                columns: new[] { "Id", "Active", "EntranceDate", "EntranceTime", "ExitTime", "GroupManagerId", "MinTime" },
                values: new object[,]
                {
                    { 34m, true, "1399/01/17", "08:00", "11:00", 2m, "03:00" },
                    { 33m, true, "1399/01/16", "08:00", "16:30", 2m, "08:00" },
                    { 32m, true, "1399/01/15", "08:00", "14:30", 2m, "06:30" },
                    { 35m, true, "1399/01/01", "08:00", "17:00", 3m, "09:00" },
                    { 39m, true, "1399/01/05", "08:00", "15:10", 3m, "07:10" },
                    { 37m, true, "1399/01/03", "08:00", "17:00", 3m, "09:00" },
                    { 51m, true, "1399/01/17", "08:00", "11:00", 3m, "03:00" },
                    { 50m, true, "1399/01/16", "08:00", "16:30", 3m, "08:00" },
                    { 49m, true, "1399/01/15", "08:00", "14:30", 3m, "06:30" },
                    { 48m, true, "1399/01/14", "08:00", "17:30", 3m, "09:30" },
                    { 47m, true, "1399/01/13", "08:00", "14:20", 3m, "06:20" },
                    { 46m, true, "1399/01/12", "08:00", "17:00", 3m, "09:00" },
                    { 36m, true, "1399/01/02", "08:00", "16:00", 3m, "08:00" },
                    { 45m, true, "1399/01/11", "08:00", "15:00", 3m, "07:00" },
                    { 43m, true, "1399/01/09", "08:00", "13:00", 3m, "05:00" },
                    { 42m, true, "1399/01/08", "08:00", "16:00", 3m, "08:00" },
                    { 41m, true, "1399/01/07", "08:00", "12:00", 3m, "04:00" },
                    { 40m, true, "1399/01/06", "08:00", "16:30", 3m, "08:30" },
                    { 31m, true, "1399/01/14", "08:00", "17:30", 2m, "09:30" },
                    { 38m, true, "1399/01/04", "08:00", "13:45", 3m, "05:45" },
                    { 44m, true, "1399/01/10", "08:00", "17:00", 3m, "09:00" },
                    { 30m, true, "1399/01/13", "08:00", "14:20", 2m, "06:20" },
                    { 23m, true, "1399/01/06", "08:00", "16:30", 2m, "08:30" },
                    { 28m, true, "1399/01/11", "08:00", "15:00", 2m, "07:00" },
                    { 1m, true, "1399/01/01", "08:00", "17:00", 1m, "09:00" },
                    { 2m, true, "1399/01/02", "08:00", "16:00", 1m, "08:00" },
                    { 3m, true, "1399/01/03", "08:00", "17:00", 1m, "09:00" },
                    { 4m, true, "1399/01/04", "08:00", "13:45", 1m, "05:45" },
                    { 5m, true, "1399/01/05", "08:00", "15:10", 1m, "07:10" },
                    { 6m, true, "1399/01/06", "08:00", "16:30", 1m, "08:30" },
                    { 7m, true, "1399/01/07", "08:00", "12:00", 1m, "04:00" },
                    { 8m, true, "1399/01/08", "08:00", "16:00", 1m, "08:00" },
                    { 9m, true, "1399/01/09", "08:00", "13:00", 1m, "05:00" },
                    { 10m, true, "1399/01/10", "08:00", "17:00", 1m, "09:00" },
                    { 11m, true, "1399/01/11", "08:00", "15:00", 1m, "07:00" },
                    { 12m, true, "1399/01/12", "08:00", "17:00", 1m, "09:00" },
                    { 13m, true, "1399/01/13", "08:00", "14:20", 1m, "06:20" },
                    { 14m, true, "1399/01/14", "08:00", "17:30", 1m, "09:30" },
                    { 15m, true, "1399/01/15", "08:00", "14:30", 1m, "06:30" },
                    { 16m, true, "1399/01/16", "08:00", "16:30", 1m, "08:00" },
                    { 17m, true, "1399/01/17", "08:00", "11:00", 1m, "03:00" },
                    { 18m, true, "1399/01/01", "08:00", "17:00", 2m, "09:00" },
                    { 19m, true, "1399/01/02", "08:00", "16:00", 2m, "08:00" },
                    { 20m, true, "1399/01/03", "08:00", "17:00", 2m, "09:00" },
                    { 21m, true, "1399/01/04", "08:00", "13:45", 2m, "05:45" },
                    { 22m, true, "1399/01/05", "08:00", "15:10", 2m, "07:10" },
                    { 24m, true, "1399/01/07", "08:00", "12:00", 2m, "04:00" },
                    { 25m, true, "1399/01/08", "08:00", "16:00", 2m, "08:00" },
                    { 26m, true, "1399/01/09", "08:00", "13:00", 2m, "05:00" },
                    { 27m, true, "1399/01/10", "08:00", "17:00", 2m, "09:00" },
                    { 29m, true, "1399/01/12", "08:00", "17:00", 2m, "09:00" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Active", "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1m, true, 1m, 1m },
                    { 2m, true, 2m, 2m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupManagerDetails_GroupManagerId",
                table: "GroupManagerDetails",
                column: "GroupManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupManagerSchedules_GroupManagerId",
                table: "GroupManagerSchedules",
                column: "GroupManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccesses_AccessLinkId",
                table: "RoleAccesses",
                column: "AccessLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleAccesses_RoleId",
                table: "RoleAccesses",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupManagerDetails");

            migrationBuilder.DropTable(
                name: "GroupManagerSchedules");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "RoleAccesses");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "GroupManagers");

            migrationBuilder.DropTable(
                name: "AccessLinks");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
