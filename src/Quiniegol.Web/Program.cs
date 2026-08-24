using Quiniegol.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Registra los componentes Razor y habilita la interactividad mediante el servidor.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();

// Configura el comportamiento de la aplicación según el entorno.
if (!app.Environment.IsDevelopment())
{
    // En producción, dirige los errores no controlados a la página de errores.
    app.UseExceptionHandler("/Error", createScopeForErrors: true);

    // Habilita HSTS para indicar al navegador que debe utilizar HTTPS.
    app.UseHsts();
}

// Si se solicita una ruta que no existe, muestra la página NotFound.
app.UseStatusCodePagesWithReExecute("/not-found",createScopeForStatusCodePages: true);

// Redirige las solicitudes HTTP a HTTPS.
app.UseHttpsRedirection();

// Agrega protección contra ataques CSRF mediante tokens antiforgery.
app.UseAntiforgery();

// Permite servir los archivos estáticos de la aplicación.
app.MapStaticAssets();

// Registra el componente principal de Blazor y habilita
// el modo interactivo mediante el servidor.
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Inicia la aplicación web.
app.Run();