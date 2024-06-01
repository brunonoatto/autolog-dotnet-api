using System.Text;
using System.Text.Json.Serialization;
using AutologApi.API.Endpoints;
using AutologApi.API.Infra.Repository;
using AutologApi.API.UseCases;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var secretKeyBytes = Encoding.ASCII.GetBytes(TokenService.SecretByte);

builder
    .Services.AddAuthentication(config =>
    {
        config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(config =>
    {
        config.RequireHttpsMetadata = false;
        config.SaveToken = true;
        config.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddSingleton<TokenService>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

// Auth
builder.Services.AddScoped<AuthLoginUseCase>();

//Users
builder.Services.AddScoped<CreateUserClientUseCase>();
builder.Services.AddScoped<TransferCarUseCase>();
builder.Services.AddScoped<CreateUserGarageUseCase>();

// Client
builder.Services.AddScoped<GetClientUseCase>();
builder.Services.AddScoped<GetClientCarsUseCase>();

//Car
builder.Services.AddScoped<CreateCarUseCase>();
builder.Services.AddScoped<GetCarByLicenseUseCase>();
builder.Services.AddScoped<ListClientCarsUseCase>();

//Budget
builder.Services.AddScoped<CreateBudgetUseCase>();
builder.Services.AddScoped<GetBudgetUseCase>();
builder.Services.AddScoped<ListBudgetsUseCase>();
builder.Services.AddScoped<CreateBudgetItemUseCase>();
builder.Services.AddScoped<DeleteBudgetItemUseCase>();
builder.Services.AddScoped<UpdateStatusBudgetUseCase>();
builder.Services.AddScoped<GetWhatsAppLinkBudgetUseCase>();

// Dashboard
builder.Services.AddScoped<GarageDashboardUseCase>();

var app = builder.Build();

// TODO: Previne o erro de data no Postgre, pensar em uma fomra melhor de adaptar isso
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseCors();

// app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();
