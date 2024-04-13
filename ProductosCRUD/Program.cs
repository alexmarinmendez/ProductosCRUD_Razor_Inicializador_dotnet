using Microsoft.EntityFrameworkCore;
using ProductosCRUD.Datos;
using ProductosCRUD.Inicializador;

var builder = WebApplication.CreateBuilder(args);

Environment.SetEnvironmentVariable("ASPNETCORE_COSO", builder.Configuration.GetSection("CualquierCosa").GetSection("OtraCosa").Value);

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));
builder.Services.AddScoped<IBdInicializador, DBInicializador>();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

using(var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var inicializador = services.GetRequiredService<IBdInicializador>() as IBdInicializador;
        inicializador.Inicializar();
    }
    catch (Exception)
    {
        throw;
    }
}

app.Run();
