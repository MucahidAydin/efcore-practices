//dotnet ef migrations add mig_1 --project .\CodeFirst\CodeFirst.csproj

using CodeFirst.Contexts;
using Microsoft.EntityFrameworkCore;

NorthwindContext context = new NorthwindContext();
await context.Database.MigrateAsync();
