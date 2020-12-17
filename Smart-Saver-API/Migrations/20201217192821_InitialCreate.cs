using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Smart_Saver_API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesDB",
                columns: table => new
                {
                    categoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesDB", x => x.categoryId);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseDB",
                columns: table => new
                {
                    expenseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    expenseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    expenseAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    expenseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expenseCategory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseDB", x => x.expenseId);
                });

            migrationBuilder.CreateTable(
                name: "GoalDB",
                columns: table => new
                {
                    goalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    goalName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    goalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    goalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalDB", x => x.goalId);
                });

            migrationBuilder.CreateTable(
                name: "IncomeDB",
                columns: table => new
                {
                    incomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    incomeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    incomeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeDB", x => x.incomeId);
                });

            migrationBuilder.CreateTable(
                name: "ReccuringIncomeDB",
                columns: table => new
                {
                    reccuringincomeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reccuringincomeAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    reccuringincomeDateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    reccuringincomeDateUntil = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReccuringIncomeDB", x => x.reccuringincomeId);
                });

            migrationBuilder.CreateTable(
                name: "UserDB",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    userAge = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDB", x => x.userId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesDB");

            migrationBuilder.DropTable(
                name: "ExpenseDB");

            migrationBuilder.DropTable(
                name: "GoalDB");

            migrationBuilder.DropTable(
                name: "IncomeDB");

            migrationBuilder.DropTable(
                name: "ReccuringIncomeDB");

            migrationBuilder.DropTable(
                name: "UserDB");
        }
    }
}
