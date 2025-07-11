using EshopApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using EshopApp.Application.Interfaces;
using EshopApp.Infrastructure.Repositories;
using EshopApp.Application.UseCases.CategoryUseCases;
using EshopApp.Application.UseCases.ProductUseCases;
using EshopApp.Application.UseCases.CustomerUseCases;
using EshopApp.Application.UseCases.InvoiceUseCases;
using EshopApp.Application.UseCases.InvoiceItemUseCases;
using EshopApp.Application.UseCases.StoreInfoUseCases;
using EshopApp.Application.UseCases.ReportUseCases;
using EshopApp.Application.Exceptions;
using EshopApp.Infrastructure.Extensions;

/// <summary>
/// Entry point for the EshopApp API application.
/// Configures services, middleware, and starts the web server.
/// </summary>
var builder = WebApplication.CreateBuilder(args);

// Register Controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices();

// Register UseCases
builder.Services.AddScoped<GetAllCategoriesUseCase>();
builder.Services.AddScoped<CreateCategoryUseCase>();
builder.Services.AddScoped<UpdateCategoryUseCase>();
builder.Services.AddScoped<DeleteCategoryUseCase>();

builder.Services.AddScoped<GetAllProductsUseCase>();
builder.Services.AddScoped<GetProductByIdUseCase>();
builder.Services.AddScoped<CreateProductUseCase>();
builder.Services.AddScoped<UpdateProductUseCase>();
builder.Services.AddScoped<DeleteProductUseCase>();
builder.Services.AddScoped<AssignProductToCategoryUseCase>();
builder.Services.AddScoped<UpdateProductStockUseCase>();

builder.Services.AddScoped<CreateCustomerUseCase>();
builder.Services.AddScoped<UpdateCustomerUseCase>();
builder.Services.AddScoped<DeleteCustomerUseCase>();
builder.Services.AddScoped<GetAllCustomersUseCase>();
builder.Services.AddScoped<GetCustomerByIdUseCase>();

builder.Services.AddScoped<CreateInvoiceUseCase>();
builder.Services.AddScoped<DeleteInvoiceUseCase>();
builder.Services.AddScoped<GetAllInvoicesUseCase>();
builder.Services.AddScoped<GetInvoiceByIdUseCase>();
builder.Services.AddScoped<CalculateInvoiceTotalUseCase>();
builder.Services.AddScoped<SearchInvoiceUseCase>();

builder.Services.AddScoped<AddInvoiceItemUseCase>();
builder.Services.AddScoped<UpdateInvoiceItemUseCase>();
builder.Services.AddScoped<DeleteInvoiceItemUseCase>();
builder.Services.AddScoped<GetInvoiceItemByIdUseCase>();
builder.Services.AddScoped<GetInvoiceItemsByInvoiceIdUseCase>();

builder.Services.AddScoped<GetStoreInfoUseCase>();
builder.Services.AddScoped<UpdateStoreInfoUseCase>();

builder.Services.AddScoped<GenerateSalesReportUseCase>();

// Register Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
builder.Services.AddScoped<IStoreInfoRepository, StoreInfoRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlite(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); 
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<EshopApp.API.Middleware.ExceptionMiddleware>();
app.MapControllers();

app.Run();
