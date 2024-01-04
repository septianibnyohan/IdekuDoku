using IdekuDoku.Api.Services;
using IdekuDoku.Api.Services.Cc;
using IdekuDoku.Api.Services.Va;
using IdekuDoku.Domain.Entities;
using IdekuDoku.Domain.Mongo.Entities;
using IdekuDoku.Domain.Mongo.Repositories;
using IdekuDoku.Domain.Mongo.UnitOfWork;
using IdekuDoku.Domain.Repositories;
using IdekuDoku.Domain.Settings;
using IdekuDoku.Infrastructure.Factories;
using IdekuDoku.Lib.Client.Va;
using IdekuDoku.Lib.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IdekuDokuContext>(options =>
{
  options.UseMySql(
    builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 28))
  );
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPaymentMethodFactory, CreditCardFactory>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<PaymentService>();
builder.Services.AddScoped<PaymentTokenServices>();
builder.Services.AddScoped<TransactionServices>();
builder.Services.AddScoped<TransactionCcServices>();
builder.Services.AddScoped<ITransactionCcRepository, TransactionCcRepository>();
builder.Services.AddScoped<SetupConfigurationVaServices>();
builder.Services.AddScoped<SetupConfigurationCcServices>();
builder.Services.AddScoped<GeneratePaymentCodeServices>();
builder.Services.AddScoped<SetupConfigurationCcRepository>();

builder.Services.AddScoped<VaServices>();
builder.Services.AddScoped<DokuVaClient>();
builder.Services.AddScoped<BcaVaClient>();
builder.Services.AddScoped<MandiriVaClient>();
builder.Services.AddScoped<BsmVaClient>();
builder.Services.AddScoped<PermataVaClient>();
builder.Services.AddScoped<RequestVaClient>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<NotificationServices>();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.Configure<DokuSettings>(builder.Configuration.GetSection(nameof(DokuSettings)));
builder.Services.AddSingleton<IDokuSettings>(sp => sp.GetRequiredService<IOptions<DokuSettings>>().Value);

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

builder.Services.Configure<ConnectionSetting>(
  options =>
  {
    options.ConnectionString = builder.Configuration.GetSection("MongoDb:ConnectionString").Value;
    options.Database = builder.Configuration.GetSection("MongoDb:Database").Value;
  });

builder.Services.AddTransient<IMongoContext, MongoContext>();
builder.Services.AddTransient<IWebhookLogRepo, WebhookLogRepo>();

builder.Services.AddSingleton<IMongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(sp =>
{
  var settings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
  return new MongoClient(settings.ConnectionString);
});

//builder.Services.AddSingleton<IMongoDBContext, MongoDBContext>();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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