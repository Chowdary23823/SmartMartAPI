using APIController;
using ApplicationServicesOfAPI;
using ApplicationServicesOfAPI.SubCategoriesOperationsFile;
using ApplicationServicesOfAPI.SuperMarketOperations;
using ApplicationServicesOfAPI.UserOperationsFile;
using DataBaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



/*builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost4200",
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<CategoryOperations>();
builder.Services.AddScoped<SubCategoriesOperations>();
builder.Services.AddScoped<SuperMarketOperations>();
builder.Services.AddScoped<UserOperations>();
/*builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql("Server=192.168.5.150;Port=5432;User Id=postgres;Password=n@v@yUg@kw!x##;Database=SmartMarketKushal;Pooling=true;");
});*/

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=KushalSMA;Trusted_Connection=True;TrustServerCertificate=True;");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors(builder => builder.AllowAnyOrigin()
                              .AllowAnyMethod()
                              .AllowAnyHeader());



app.UseMiddleware<ExceptionUsingMiddleWare>();
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
