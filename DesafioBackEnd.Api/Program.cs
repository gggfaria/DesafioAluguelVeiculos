using DesafioBackEnd.Domain.Entities;
using DesafioBackEnd.Domain.Repositories;
using DesafioBackEnd.Infra;
using DesafioBackEnd.Infra.Context;
using DesafioBackEnd.Service.Interfaces.People;
using DesafioBackEnd.Service.Services.People;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test", Version = "v1" });
    //Adição do header de autenticação no Swagger 
    c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
                                              Escreva 'Bearer' [espaço] e o token gerado no login na caixa abaixo.
                                              Exemplo: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                },
            },
            new List<string>()
        }
    });
});

builder.Services.AddSingleton<InjectionStrings>
(
    _=> new InjectionStrings(
        builder.Configuration.GetSection("jwtTokenKey").Get<string>(),
              builder.Configuration.GetConnectionString("SqlConnection")
        )
);

builder.Services.AddDbContext<DesafioContext>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





// EnableSensitiveDataLogging()
//     .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();