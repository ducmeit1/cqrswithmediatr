using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Customer.Data.Migrations
{
    public partial class CreateCustomerModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    customer_id = table.Column<Guid>(nullable: false, defaultValueSql: "newId()"),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    customer_name = table.Column<string>(type: "varchar", maxLength: 255, nullable: false),
                    email = table.Column<string>(maxLength: 255, nullable: false),
                    address = table.Column<string>(maxLength: 255, nullable: false),
                    age = table.Column<int>(nullable: false),
                    phone_number = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.customer_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
