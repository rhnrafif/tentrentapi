using EventTentRental.Application.Services.Authentications;
using EventTentRental.Application.Services.Customers;
using EventTentRental.Application.Services.Mitras;
using EventTentRental.Application.Services.Products;
using EventTentRental.Application.Services.Transactions;
using EventTentRental.Databases;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<TentContext>(option => option.UseSqlServer(connString));

// Add services to the container.
builder.Services.AddTransient<IAuthAppService, AuthAppService>();
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddTransient<IMitraAppService, MitraAppService>();
builder.Services.AddTransient<IProductAppService, ProductAppService>();
builder.Services.AddTransient<ITransactionAppService, TransactionAppService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
