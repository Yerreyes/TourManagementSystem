using Microsoft.AspNetCore.Authentication.Cookies; // fuente para lo de la autentificacion y roles:https://www.youtube.com/watch?v=IvoDzgrjMOY&t=762s 
using ProyectoDos.UI.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IServicioCliente, ServicioCliente>();
builder.Services.AddScoped<IServicioProveedor, ServicioProveedor>();
builder.Services.AddScoped<IServicioProducto, ServicioProducto>();
builder.Services.AddScoped<IServicioTour, ServicioTour>();
builder.Services.AddScoped<IServicioProducto, ServicioProducto>();
builder.Services.AddScoped<IServicioFactura, ServicioFactura>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Acesso/Index";  // dice le formulario de logeo
        option.ExpireTimeSpan = TimeSpan.FromMinutes(45); // tiempo de sesion
        option.AccessDeniedPath = "/Home/Privacy"; // pagina que indica acceso dedengado
    });
    

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); //se agrega autentication

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acesso}/{action=Index}/{id?}");

app.Run();
