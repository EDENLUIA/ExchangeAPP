

using ExchangeR.Application;

using ExchangeR.Domain.Repositories;
using ExchangeR.Infrastructure;
using ExchangeR.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DbContext, ExchangeDbContext>(options =>
         options
             .UseInMemoryDatabase(databaseName: "Exchange")
             .EnableSensitiveDataLogging(true)

         );

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin() //Se puede cambiar este  metodo AllowAnyOrigin() que permite recibir peticiones desde cualquier punto y  usar en cambio WithOrigins("http://www.something.com") que recibira peticiones  solo de esa punto
                          .AllowAnyMethod() //En vez de usar AllowAnyMethod() que  permite recibir cualquier metodo HTTP, se puede usar WithMethods("POST", "GET")  que permitira solo metodos HTTP especificos
                          .AllowAnyHeader()); //Los mismos cambios se pueden aplicar para  AllowAnyHeader(), que podria usar, por ejemplo el metodo WithHeaders("accept",  "content-type") que permitira solo headers especificos

    //Cuando intento poner este metodo me sale error, al hacer un request
    //'The CORS protocol does not allow specifying a wildcard (any) origin and credentials at the same time. Configure the CORS policy by listing individual origins if credentials needs to be supported.'
    //TODO : VERIFICAR OTRA VEZ DESPUES DE IMPLEMENTAR EL TOKEN
    //.AllowCredentials());
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<CurrencyService>();
builder.Services.AddScoped<ExchangeRateService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Auth:Secret"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NombreDeMiApi", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                 "NombreDeMiApi v1"));

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

