using AutologApi.API.Endpoints;
using AutologApi.API.UseCases.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services
    // .AddEntityFrameworkNpgsql()
    .AddDbContext<AppDbContext>();

builder.Services.AddScoped<AuthLoginUseCase>();
builder.Services.AddScoped<CreateUserClientUseCase>();

var app = builder.Build();

// TODO: Previne o erro de data no Postgre, pensar em uma fomra melhor de adaptar isso
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();

