using Sales.Api.Domains.Contracts;
using Sales.Api.Domains.Employees;
using Sales.Api.Domains.Products;
using Sales.Api.Models;
using Sales.Api.Services.Contratcs;
using Sales.Api.Services.Employees;
using Sales.Api.Services.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDBContext>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IEmployeeDomainService, EmployeeDomainService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDomainService, ProductDomainService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
