using Sales.Api.Domains.Contracts;
using Sales.Api.Domains.Customers;
using Sales.Api.Domains.Employees;
using Sales.Api.Domains.OrderStatuses;
using Sales.Api.Domains.Products;
using Sales.Api.Models;
using Sales.Api.Services.Contratcs;
using Sales.Api.Services.Customers;
using Sales.Api.Services.Employees;
using Sales.Api.Services.OrderStatuses;
using Sales.Api.Services.Products;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "https://localhost:4200/");
                      });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StoreDBContext>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerDomainService, CustomerDomainService>();
builder.Services.AddScoped<IOrderStatusService, OrderStatusService>();
builder.Services.AddScoped<IOrderStatusDomainService, OrderStatusDomainService>();
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

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();


app.Run();
