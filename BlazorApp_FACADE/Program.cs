using BlazorApp_FACADE;
using BlazorApp_FACADE.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// HttpClient para ApiCitasMedicas
builder.Services.AddHttpClient("CitasApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7043/");
});

// HttpClient para ApiFacturacion
builder.Services.AddHttpClient("FacturacionApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7204/");
});

// Servicios API Citas
builder.Services.AddScoped<ICitaService, CitaService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IServicioService, ServicioService>();
builder.Services.AddScoped<IEvolucionService, EvolucionService>();

// Servicios API Facturación
builder.Services.AddScoped<IPagoService, PagoService>();
builder.Services.AddScoped<IDetallePagoService, DetallePagoService>();

await builder.Build().RunAsync();
