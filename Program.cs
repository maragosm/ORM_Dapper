using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using ORM_Dapper;

var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);
var repo = new DapperDepartmentRepository(conn);

//Departments

Console.WriteLine("All Departments");
var departments = repo.GetAllDepartments();

foreach (var dept in departments)
{
    Console.WriteLine($"{dept.DepartmentID}: {dept.Name}");
}

Console.WriteLine("What is the name for the new Department?");
var deptName = Console.ReadLine();
Console.WriteLine($"Creating new department named {deptName}");
repo.InsertDepartment(deptName);
departments = repo.GetAllDepartments();

foreach (var dept in departments)
{
    Console.WriteLine($"{dept.DepartmentID}: {dept.Name}");
}

//Products
var prodRepo = new DapperProductRepository(conn);
var products = prodRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($"{product.ProductID}: {product.Name}, {product.Price}");
}

Console.WriteLine();
Console.WriteLine("What is the name of the product you would like to add?");
var prodName = Console.ReadLine();
Console.WriteLine("What is the price of the item?");
var prodPrice = double.Parse(Console.ReadLine());
Console.WriteLine("What is the category ID for the item?");
var prodCategoryID = int.Parse(Console.ReadLine());

prodRepo.CreateProduct(prodName, prodPrice, prodCategoryID);

foreach (var product in products)
{
    Console.WriteLine($"{product.ProductID}: {product.Name}, {product.Price}");
}

Console.WriteLine("What is the Product ID that you want to update?");
var prodID = int.Parse(Console.ReadLine());
Console.WriteLine("What is the updated product name?");
var newProdName = Console.ReadLine();

prodRepo.UpdateProduct(prodID, newProdName);
Console.WriteLine();

products = prodRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($"{product.ProductID}: {product.Name}, {product.Price}");
}

Console.WriteLine();

Console.WriteLine("What is the Product ID you want to delete?");
prodID = int.Parse(Console.ReadLine());

prodRepo.DeleteProduct(prodID);

products = prodRepo.GetAllProducts();

Console.WriteLine();

foreach (var product in products)
{
    Console.WriteLine($"{product.ProductID}: {product.Name}, {product.Price}");
}