using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAPI.Migrations
{
    public partial class starter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ms_storage_location",
                columns: table => new
                {
                    location_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    location_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ms_storage_location", x => x.location_id);
                });

            migrationBuilder.CreateTable(
                name: "ms_user",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ms_user", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "tr_bpkb",
                columns: table => new
                {
                    agreement_number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bpkb_no = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    branch_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    bpkb_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    faktur_no = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    faktur_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    location_id = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    police_no = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    bpkb_date_in = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_by = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    created_on = table.Column<DateTime>(type: "datetime2", nullable: false),
                    last_updated_by = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    last_updated_on = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tr_bpkb", x => x.agreement_number);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ms_storage_location");

            migrationBuilder.DropTable(
                name: "ms_user");

            migrationBuilder.DropTable(
                name: "tr_bpkb");
        }
    }
}
