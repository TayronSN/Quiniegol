using Quiniegol.Web.Components;
using Quiniegol.Core.Data;
using Quiniegol.Core.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Registra los componentes Razor y habilita la interactividad mediante el servidor.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Registra el servicio de sesión con ciclo de vida Scoped.
// Cada conexión de usuario recibe su propia instancia, evitando que se compartan datos entre usuarios.
builder.Services.AddScoped<SesionService>();

// Registra AppDbContext.
// La conexión con SQLite se configura dentro de AppDbContext.
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

// Aplica automáticamente las migraciones pendientes.
using (var scope = app.Services.CreateScope())
{
    AppDbContext db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    db.Database.Migrate();
}

// Carga los equipos iniciales si la tabla está vacía.
EquiposData.InicializarEquipos();

// Carga los partidos iniciales si la tabla está vacía.
PartidosData.InicializarPartidos();

// Carga los usuarios iniciales si la tabla está vacía.
UsuariosData.InicializarUsuarios();

// Carga los pronósticos iniciales si la tabla está vacía.
PronosticosData.InicializarPronosticos();

// Configura el comportamiento de la aplicación según el entorno.
if (!app.Environment.IsDevelopment())
{
    // En producción, dirige los errores no controlados a la página de errores.
    app.UseExceptionHandler("/Error",createScopeForErrors: true);

    // Habilita HSTS para indicar al navegador que debe utilizar HTTPS.
    app.UseHsts();
}

// Si se solicita una ruta que no existe, muestra la página NotFound.
app.UseStatusCodePagesWithReExecute( "/not-found",createScopeForStatusCodePages: true);

// Redirige las solicitudes HTTP a HTTPS.
app.UseHttpsRedirection();

// Agrega protección contra ataques CSRF mediante tokens antiforgery.
app.UseAntiforgery();

// Permite servir los archivos estáticos de la aplicación.
app.MapStaticAssets();

// Registra el componente principal de Blazor y habilita
// el modo interactivo mediante el servidor.
app.MapRazorComponents<App>() .AddInteractiveServerRenderMode();

// Inicia la aplicación.
app.Run();
