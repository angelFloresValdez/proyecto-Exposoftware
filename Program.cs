using Microsoft.EntityFrameworkCore;
using ProyectoFinalPOO2;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Conexion a la base de datos
/// <summary>Configura la conexión a la base de datos utilizando Entity Framework Core.</summary>
/// <typeparam name="ApplicationDbContext">El contexto de la base de datos de la aplicación.</typeparam>
/// <returns>La instancia de la aplicación configurada con la conexión a la base de datos.</typeparam>
// builder.Services.AddDbContext<ApplicationDbContext>(opc => opc.UseSqlServer("name=MyConnection"));


 builder.Services.AddDbContext<ApplicationDbContext>(opciones 
 => opciones.UseNpgsql("name=PostgresConnection"));

 AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
var app = builder.Build();




if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();