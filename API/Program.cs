using Microsoft.EntityFrameworkCore;
using Repositorio.IRepositorio;
using Repositorio;
using Servicio.IServicio;
using Servicio;
using Repositorio.DBContext;
using Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbecommerceSalonComunalContext>(options =>
{
    //leyendo appsettings para pasarle la cadena de conexion de sql server
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
});


//inyectando el R epositorio e IRepositorio
builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));
builder.Services.AddScoped<IReservaRepositorio, ReservaRepositorio>();
builder.Services.AddScoped<IDetalleReservaRepositorio, DetalleReservaRepositorio>();

//
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<ICategoriaServicio, CategoriaServicio>();
builder.Services.AddScoped<IProductoServicio, ProductoServicio>();
builder.Services.AddScoped<IReservaServicio, ReservaServicio>();
builder.Services.AddScoped<IDetalleReservaServicio, DetalleReservaServicio>();
builder.Services.AddScoped<IDashboardServicio, DashboardServicio>();

builder.Services.AddScoped<IPaymentRepositorio, PaymentRepositorio>();

builder.Services.AddScoped<IEmailSenderService, EmailSenderService>();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("policyCORS", app =>
    {
        app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    }
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//
app.UseCors("policyCORS");

app.UseAuthorization();

app.MapControllers();

app.Run();
