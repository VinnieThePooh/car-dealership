// See https://aka.ms/new-console-template for more information

using CarDealership.DataAccess;
using CarDealership.DataAccess.Extensions;
using Microsoft.EntityFrameworkCore;

var path = Path.Combine(AppContext.BaseDirectory, "CarsDb.db");
var builder = new DbContextOptionsBuilder<CarsContext>();
builder.UseSqlite($"Filename={path}");

Console.Write("Migration is running...");

await using var context = new CarsContext(builder.Options);
await context.Database.MigrateAsync();
Console.WriteLine("completed");

Console.Write("Seeding is running...");
await context.TrySeedSoldCars();
Console.WriteLine("completed");