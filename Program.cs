using AppExemplo.Components;
using AppExemplo.Configs;
using AppExemplo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    
builder.Services.AddSingleton<Conexao>();
builder.Services.AddSingleton<AgendamentoDAO>();
builder.Services.AddSingleton<ClienteDAO>();
builder.Services.AddSingleton<FuncionarioDAO>();
builder.Services.AddSingleton<QuadraDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
