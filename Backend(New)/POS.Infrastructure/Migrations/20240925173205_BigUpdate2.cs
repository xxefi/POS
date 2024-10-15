using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BigUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Financials");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transactions",
                newName: "TransactionDate");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(32)",
                oldMaxLength: 32);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Transactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StatisticsEntityId",
                table: "Sales",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Payments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryEntityId",
                table: "MenuItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IngredientEntityId",
                table: "MenuItems",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StatisticsEntityId",
                table: "Inventories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentEntityId",
                table: "Customers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TransactionEntityId",
                table: "Customers",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "CategoryMenus",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MenuItemId",
                table: "CategoryMenus",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryMenuEntityId",
                table: "Categories",
                type: "uuid",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cashiers",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cashiers",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Cashiers",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_StatisticsEntityId",
                table: "Sales",
                column: "StatisticsEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_CategoryEntityId",
                table: "MenuItems",
                column: "CategoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_IngredientEntityId",
                table: "MenuItems",
                column: "IngredientEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_StatisticsEntityId",
                table: "Inventories",
                column: "StatisticsEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PaymentEntityId",
                table: "Customers",
                column: "PaymentEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_TransactionEntityId",
                table: "Customers",
                column: "TransactionEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryMenuEntityId",
                table: "Categories",
                column: "CategoryMenuEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_CategoryMenus_CategoryMenuEntityId",
                table: "Categories",
                column: "CategoryMenuEntityId",
                principalTable: "CategoryMenus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Payments_PaymentEntityId",
                table: "Customers",
                column: "PaymentEntityId",
                principalTable: "Payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Transactions_TransactionEntityId",
                table: "Customers",
                column: "TransactionEntityId",
                principalTable: "Transactions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Statistics_StatisticsEntityId",
                table: "Inventories",
                column: "StatisticsEntityId",
                principalTable: "Statistics",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Categories_CategoryEntityId",
                table: "MenuItems",
                column: "CategoryEntityId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Ingredients_IngredientEntityId",
                table: "MenuItems",
                column: "IngredientEntityId",
                principalTable: "Ingredients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Statistics_StatisticsEntityId",
                table: "Sales",
                column: "StatisticsEntityId",
                principalTable: "Statistics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_CategoryMenus_CategoryMenuEntityId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Payments_PaymentEntityId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Transactions_TransactionEntityId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Statistics_StatisticsEntityId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Categories_CategoryEntityId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Ingredients_IngredientEntityId",
                table: "MenuItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Statistics_StatisticsEntityId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Sales_StatisticsEntityId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_CategoryEntityId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_MenuItems_IngredientEntityId",
                table: "MenuItems");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_StatisticsEntityId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Customers_PaymentEntityId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_TransactionEntityId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryMenuEntityId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "StatisticsEntityId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "CategoryEntityId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "IngredientEntityId",
                table: "MenuItems");

            migrationBuilder.DropColumn(
                name: "StatisticsEntityId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "PaymentEntityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TransactionEntityId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "CategoryMenus");

            migrationBuilder.DropColumn(
                name: "MenuItemId",
                table: "CategoryMenus");

            migrationBuilder.DropColumn(
                name: "CategoryMenuEntityId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cashiers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Cashiers");

            migrationBuilder.RenameColumn(
                name: "TransactionDate",
                table: "Transactions",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "character varying(32)",
                maxLength: 32,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cashiers",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Financials",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financials_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Financials_AccountId",
                table: "Financials",
                column: "AccountId");
        }
    }
}
