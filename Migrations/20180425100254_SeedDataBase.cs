using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NGWSite.Migrations {
    public partial class SeedDataBase : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql ("INSERT INTO ProductCategorys(Name) VALUES ('Breakfast')");
            migrationBuilder.Sql ("INSERT INTO ProductCategorys(Name) VALUES ('Lunch')");
            migrationBuilder.Sql ("INSERT INTO ProductCategorys(Name) VALUES ('Snack')");
            migrationBuilder.Sql ("INSERT INTO ProductCategorys(Name) VALUES ('Dinner')");
            migrationBuilder.Sql ("INSERT INTO ProductCategorys(Name) VALUES ('HotDrinks')");
            migrationBuilder.Sql ("INSERT INTO ProductCategorys(Name) VALUES ('ColdDrinks')");

            migrationBuilder.Sql ("INSERT INTO Products(Name, Price, ProductCategoryId) VALUES ('Egg', 1.2, (Select ProductCategoryId FROM ProductCategorys as pc WHERE Name='Breakfast' ))");
            migrationBuilder.Sql ("INSERT INTO Products(Name, Price, ProductCategoryId) VALUES ('Fried Rice', 8.9, (Select ProductCategoryId FROM ProductCategorys as pc WHERE Name='Lunch' ))");
            migrationBuilder.Sql ("INSERT INTO Products(Name, Price, ProductCategoryId) VALUES ('Donut', 2.5, (Select ProductCategoryId FROM ProductCategorys as pc WHERE Name='Snack' ))");
            migrationBuilder.Sql ("INSERT INTO Products(Name, Price, ProductCategoryId) VALUES ('Fried Chicken', 12.0, (Select ProductCategoryId FROM ProductCategorys as pc WHERE Name='Dinner' ))");
            migrationBuilder.Sql ("INSERT INTO Products(Name, Price, ProductCategoryId) VALUES ('Cappuccino', 8.2, (Select ProductCategoryId FROM ProductCategorys as pc WHERE Name='HotDrinks' ))");
            migrationBuilder.Sql ("INSERT INTO Products(Name, Price, ProductCategoryId) VALUES ('Ice Tea', 4.0, (Select ProductCategoryId FROM ProductCategorys as pc WHERE Name='ColdDrinks' ))");

            migrationBuilder.Sql ("INSERT INTO Orders(Date) VALUES('2012-12-31')");
            migrationBuilder.Sql ("INSERT INTO Orders(Date) VALUES('2013-01-01')");

            migrationBuilder.Sql ("INSERT INTO OrderItems(OrderId, ProductId, Quantity) VALUES((SELECT OrderId FROM Orders WHERE Date='2012-12-31'), (SELECT ProductId FROM Products WHERE Name='Egg'), 2)");
            migrationBuilder.Sql ("INSERT INTO OrderItems(OrderId, ProductId, Quantity) VALUES((SELECT OrderId FROM Orders WHERE Date='2013-01-01'), (SELECT ProductId FROM Products WHERE Name='Donut'), 4)");
            migrationBuilder.Sql ("INSERT INTO OrderItems(OrderId, ProductId, Quantity) VALUES((SELECT OrderId FROM Orders WHERE Date='2012-12-31'), (SELECT ProductId FROM Products WHERE Name='Cappuccino'), 2)");
            migrationBuilder.Sql ("INSERT INTO OrderItems(OrderId, ProductId, Quantity) VALUES((SELECT OrderId FROM Orders WHERE Date='2013-01-01'), (SELECT ProductId FROM Products WHERE Name='Ice Tea'), 1)");

        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.Sql ("DELETE FROM ProductCategorys WHERE Name='Breakfast'");
            migrationBuilder.Sql ("DELETE FROM ProductCategorys WHERE Name='Lunch'");
            migrationBuilder.Sql ("DELETE FROM ProductCategorys WHERE Name='Snack'");
            migrationBuilder.Sql ("DELETE FROM ProductCategorys WHERE Name='Dinner'");
            migrationBuilder.Sql ("DELETE FROM ProductCategorys WHERE Name='HotDrinks'");
            migrationBuilder.Sql ("DELETE FROM ProductCategorys WHERE Name='ColdDrinks'");

            migrationBuilder.Sql ("DELETE FROM Products WHERE Name='Egg'");
            migrationBuilder.Sql ("DELETE FROM Products WHERE Name='Fried Rice'");
            migrationBuilder.Sql ("DELETE FROM Products WHERE Name='Donut'");
            migrationBuilder.Sql ("DELETE FROM Products WHERE Name='Fried Chicken'");
            migrationBuilder.Sql ("DELETE FROM Products WHERE Name='Cappuccino'");
            migrationBuilder.Sql ("DELETE FROM Products WHERE Name='Ice Tea'");

            migrationBuilder.Sql ("DELETE FROM Orders WHERE Date='2012-12-31'");
            migrationBuilder.Sql ("DELETE FROM Orders WHERE Date='2013-01-01'");

            migrationBuilder.Sql ("DELETE FROM OrderItems WHERE OrderId=(SELECT OrderId FROM Orders WHERE Date='2012-12-31')");
            migrationBuilder.Sql ("DELETE FROM OrderItems WHERE OrderId=(SELECT OrderId FROM Orders WHERE Date='2013-01-01')");

        }
    }
}