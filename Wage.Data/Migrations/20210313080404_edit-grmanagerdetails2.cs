using Microsoft.EntityFrameworkCore.Migrations;

namespace Wage.Data.Migrations
{
    public partial class editgrmanagerdetails2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsOnline",
                table: "GroupManagerDetails",
                type: "bit",
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 1m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 3m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 4m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 5m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 6m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 7m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 8m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 9m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 10m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 11m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 12m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 13m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 14m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 15m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 16m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 17m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 18m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 19m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 20m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 1m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 3m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 4m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 5m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 6m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 7m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 8m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 9m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 10m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 11m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 12m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 13m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 14m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 15m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 16m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 17m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 18m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 19m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 20m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 21m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 22m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 23m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 24m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 25m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 26m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 27m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 28m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 29m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 30m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 31m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 32m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 33m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 34m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 35m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 36m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 37m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 38m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 39m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 40m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 41m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 42m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 43m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 44m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 45m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 46m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 47m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 48m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 49m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 50m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 51m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 1m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 3m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 4m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 5m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 6m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 7m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 8m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 9m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 10m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 11m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 12m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 1m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 3m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 4m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 5m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 6m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 7m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 8m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 9m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 10m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 11m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 12m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 13m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 14m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3m,
                column: "Active",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsOnline",
                table: "GroupManagerDetails",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValueSql: "((0))");

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 1m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 3m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, false });

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 4m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 5m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 6m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 7m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, false });

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 8m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, false });

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 9m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 10m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 11m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 12m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 13m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, false });

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 14m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 15m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 16m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 17m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, false });

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 18m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, false });

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 19m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerDetails",
                keyColumn: "Id",
                keyValue: 20m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 1m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 3m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 4m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 5m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 6m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 7m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 8m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 9m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 10m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 11m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 12m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 13m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 14m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 15m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 16m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 17m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 18m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 19m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 20m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 21m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 22m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 23m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 24m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 25m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 26m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 27m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 28m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 29m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 30m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 31m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 32m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 33m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 34m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 35m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 36m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 37m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 38m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 39m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 40m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 41m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 42m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 43m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 44m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 45m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 46m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 47m,
                columns: new[] { "Active", "IsOnline" },
                values: new object[] { true, true });

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 48m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 49m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 50m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagerSchedules",
                keyColumn: "Id",
                keyValue: 51m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 1m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 3m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 4m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 5m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 6m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 7m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 8m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 9m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 10m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 11m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "GroupManagers",
                keyColumn: "Id",
                keyValue: 12m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 1m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 3m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 4m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 5m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 6m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 7m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 8m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 9m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 10m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 11m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 12m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 13m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Holidays",
                keyColumn: "Id",
                keyValue: 14m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2m,
                column: "Active",
                value: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3m,
                column: "Active",
                value: true);
        }
    }
}
