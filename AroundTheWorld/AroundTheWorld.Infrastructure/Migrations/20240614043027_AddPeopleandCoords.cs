using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AroundTheWorld.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPeopleandCoords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "YCoordinate",
                table: "Trips",
                newName: "StartYCoordinate");

            migrationBuilder.RenameColumn(
                name: "XCoordinate",
                table: "Trips",
                newName: "StartXCoordinate");

            migrationBuilder.AddColumn<double>(
                name: "FinishXCoordinate",
                table: "Trips",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FinishYCoordinate",
                table: "Trips",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxPeopleCount",
                table: "Trips",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinishXCoordinate",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "FinishYCoordinate",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "MaxPeopleCount",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "StartYCoordinate",
                table: "Trips",
                newName: "YCoordinate");

            migrationBuilder.RenameColumn(
                name: "StartXCoordinate",
                table: "Trips",
                newName: "XCoordinate");
        }
    }
}
