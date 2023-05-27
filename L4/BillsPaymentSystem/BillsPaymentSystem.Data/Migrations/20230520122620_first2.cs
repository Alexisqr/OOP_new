using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BillsPaymentSystem.Data.Migrations
{
    public partial class first2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "BankAccountId", "Balance", "BankName", "SWIFT" },
                values: new object[,]
                {
                    { 1, 0.6m, "1234567891", "12-06-2018" },
                    { 2, 0.8m, "1234567891", "12-06-2018" }
                });

            migrationBuilder.InsertData(
                table: "CreditCards",
                columns: new[] { "CreditCardId", "ExpirationDate", "Limit", "MoneyOwed" },
                values: new object[] { 1, new DateTime(2018, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.7m, 0.9m });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "alexis.cv1824@gmail.com", "LALALA", "PAPAPA", "12345" });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "BankAccountId", "CreditCardId", "Type", "UserId" },
                values: new object[] { 1, 1, 1, 0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "BankAccountId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BankAccounts",
                keyColumn: "BankAccountId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CreditCards",
                keyColumn: "CreditCardId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
