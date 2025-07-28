using Microsoft.EntityFrameworkCore;
using sampleforchecking.Data;
using sampleforchecking.Repository.Interfaces;
using sampleforchecking.Repository.Implementation;
using sampleforchecking.Services.Interfaces;
using sampleforchecking.Services.Implementation;
using sampleforchecking.Data;
using PharmacyBackend.Repository.VatRepository;
using sampleforchecking.Repository.Interfaces.ISale;
using sampleforchecking.Repository.Implementation.Sale;
using sampleforchecking.Services.Interfaces.ISale;
using sampleforchecking.Services.Implementation.Sale;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PharmacyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IVATEntryRepository, VATEntryRepository>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<ISalesTransactionRepository, SalesTransactionRepository>();

//Service
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IVatEntryService, VatEntryService>();
builder.Services.AddScoped<IDiscountService, DiscountService>();
builder.Services.AddScoped<ISalesService, SalesService>();


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
