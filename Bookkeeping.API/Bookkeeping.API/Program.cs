using Bookkeeping.API;
using Bookkeeping.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IReconciliationManager, ReconciliationManager>();
builder.Services.AddTransient<IReconciliationService, ReconciliationService>();

async static Task SeedDataAsync(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var context = scope.ServiceProvider.GetService<BookkeepingContext>();
        await SeedData.ExecuteScriptAsync(context);
    }
}

builder.Services.AddDbContext<BookkeepingContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

var app = builder.Build();
await SeedDataAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
