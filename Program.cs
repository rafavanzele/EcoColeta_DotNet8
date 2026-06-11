using EcoColeta.Api.Data;
using EcoColeta.Api.Repositories.Implementations;
using EcoColeta.Api.Repositories.Interfaces;
using EcoColeta.Api.Services.Implementations;
using EcoColeta.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using EcoColeta.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte aos Controllers da API
builder.Services.AddControllers();

// Configura o Entity Framework para utilizar SQL Server
// A string de conexão será lida do arquivo appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Registra os Repositories para Injeção de Dependência
builder.Services.AddScoped<ITipoResiduoRepository, TipoResiduoRepository>();

// Registra os Services para Injeção de Dependência
builder.Services.AddScoped<ITipoResiduoService, TipoResiduoService>();

builder.Services.AddScoped<IPontoColetaRepository, PontoColetaRepository>();
builder.Services.AddScoped<IPontoColetaService, PontoColetaService>();

builder.Services.AddScoped<IColetaResiduoRepository, ColetaResiduoRepository>();
builder.Services.AddScoped<IColetaResiduoService, ColetaResiduoService>();

// Adiciona suporte ao Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuração do pipeline HTTP
if (app.Environment.IsDevelopment())
{
    // Habilita a documentação Swagger durante o desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

// Redireciona automaticamente HTTP para HTTPS
app.UseHttpsRedirection();

// Habilita o sistema de autorização
app.UseAuthorization();

// Mapeia os endpoints dos Controllers
app.MapControllers();

// Inicializa a aplicação
app.Run();