using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.API.Migrations
{
    public partial class Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servers_GlobalEnvironment_GlobalEnvironmentId",
                table: "Servers");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Servers_ServerId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServiceTypes_ServiceTypeId",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_Solutions_SolutionId",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Service",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlobalEnvironment",
                table: "GlobalEnvironment");

            migrationBuilder.RenameTable(
                name: "Service",
                newName: "Services");

            migrationBuilder.RenameTable(
                name: "GlobalEnvironment",
                newName: "GlobalEnvironments");

            migrationBuilder.RenameIndex(
                name: "IX_Service_SolutionId",
                table: "Services",
                newName: "IX_Services_SolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_ServiceTypeId",
                table: "Services",
                newName: "IX_Services_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_ServerId",
                table: "Services",
                newName: "IX_Services_ServerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlobalEnvironments",
                table: "GlobalEnvironments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_GlobalEnvironments_GlobalEnvironmentId",
                table: "Servers",
                column: "GlobalEnvironmentId",
                principalTable: "GlobalEnvironments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Servers_ServerId",
                table: "Services",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Solutions_SolutionId",
                table: "Services",
                column: "SolutionId",
                principalTable: "Solutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servers_GlobalEnvironments_GlobalEnvironmentId",
                table: "Servers");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Servers_ServerId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_ServiceTypes_ServiceTypeId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Solutions_SolutionId",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GlobalEnvironments",
                table: "GlobalEnvironments");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Service");

            migrationBuilder.RenameTable(
                name: "GlobalEnvironments",
                newName: "GlobalEnvironment");

            migrationBuilder.RenameIndex(
                name: "IX_Services_SolutionId",
                table: "Service",
                newName: "IX_Service_SolutionId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ServiceTypeId",
                table: "Service",
                newName: "IX_Service_ServiceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Services_ServerId",
                table: "Service",
                newName: "IX_Service_ServerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Service",
                table: "Service",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GlobalEnvironment",
                table: "GlobalEnvironment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Servers_GlobalEnvironment_GlobalEnvironmentId",
                table: "Servers",
                column: "GlobalEnvironmentId",
                principalTable: "GlobalEnvironment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Servers_ServerId",
                table: "Service",
                column: "ServerId",
                principalTable: "Servers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServiceTypes_ServiceTypeId",
                table: "Service",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Solutions_SolutionId",
                table: "Service",
                column: "SolutionId",
                principalTable: "Solutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
