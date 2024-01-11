using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using oshopAPI.Context;
using oshopAPI.Entities.Security;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);


//configure CORS
builder.Services.AddCors(options =>
{
    //if (env.IsDevelopment())
    //{
    options.AddPolicy("AllowAnyOriginPolicy",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
    //}
    //else
    //{
    //    // Configurazione più restrittiva per l'ambiente di produzione
    //    options.AddPolicy("AllowSpecificOriginPolicy",
    //        builder => builder
    //            .WithOrigins("http://localhost:4200")  // Specifica l'origine consentita in produzione
    //            .AllowAnyMethod()
    //            .AllowAnyHeader());
    //}

});

// Add services to the container.


//add DbContext
builder.Services.AddDbContext<OShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
       .AddEntityFrameworkStores<OShopDbContext>()
       .AddDefaultTokenProviders();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAnyOriginPolicy");
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
