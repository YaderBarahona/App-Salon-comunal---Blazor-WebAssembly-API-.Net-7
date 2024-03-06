using Blazored.LocalStorage;
using Blazored.Toast;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAssembly;
using WebAssembly.Servicios.IServicios;
using WebAssembly.Servicios;
using WebAssembly.Auth;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7002/api/") });

//agregando localstorage
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<IReservaServicio, ReservaServicio>();
builder.Services.AddScoped<IDetalleReservaServicio, DetalleReservaServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();
builder.Services.AddScoped<ICarritoServicio, CarritoServicio>();
builder.Services.AddScoped<ICheckoutService, CheckoutService>();

builder.Services.AddScoped<IEmailServicio, EmailServicio>();


builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, Authentication>();

builder.Services.AddTransient<IReCaptchaService, ReCaptchaService>();

//toast
builder.Services.AddBlazoredToast();
builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
