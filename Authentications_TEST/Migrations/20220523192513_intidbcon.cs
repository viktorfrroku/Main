using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Authentications_TEST.Migrations
{
    public partial class intidbcon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

           

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b09b912e-98c8-4a15-a1dc-787d6c58a048", "02fd3b93-b8a0-4f28-8447-6557f5db93ae", "SuperAdmin", null },
                    { "9568d390-45b7-4ce3-b697-ef4423720129", "c0132ba1-7afb-4065-bb38-302f2f22e70a", "Admin", null },
                    { "a590cc86-eb96-4ede-9eed-0afb2ec93204", "ebacc051-e6bb-4a32-9174-cff4321c4d16", "Manager", null },
                    { "405cfda7-f970-45ed-80ac-70d4395bd048", "38d19c9f-2914-4dd6-bb9c-b01983a98000", "Customer", null },
                    { "6f92e353-a7e6-41c6-a035-ea15c5f40513", "dba085eb-2b78-4aa2-bb33-9cd9425dadae", "User", null }
                });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          ;

            migrationBuilder.DropTable(
                name: "AspNetRoles");

        }
    }
}
