using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Services;
using AgendaPro.Domain.Entities;
using AgendaPro.Infrastructure;
using AgendaPro.Infrastructure.Repositories;
using AgendaPro.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAgendamentoService, AgendamentoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPagamentoService, PagamentoService>();
builder.Services.AddScoped<IProfissionalService, ProfissionalService>();
builder.Services.AddScoped<IServicoService, ServicoService>();
builder.Services.AddScoped<IGeralRepo, GeralRepo>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySQL(
            builder.Configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string não encontrada")
        )
);

builder.Services
    .AddIdentityApiEndpoints<Usuario>(options =>
    {
        options.User.RequireUniqueEmail = true;

        options.Password.RequiredLength = 8;
        options.Password.RequireDigit = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<DataContext>();

builder.Services.AddAuthorization();

builder.Services.AddDataProtection();

builder.Services
    .AddIdentityCore<Usuario>()
    .AddEntityFrameworkStores<DataContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//Usando endpoints prontos do nosso Identity
app.MapGroup("/api/auth")
   .MapIdentityApi<Usuario>();

app.Run();
