using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversity.Data;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

/*El nombre de la cadena de conexión se pasa al contexto mediante una llamada a un método en un objeto DbContextOptions. 
Para el desarrollo local, el sistema de configuración de ASP.NET Core lee la cadena de conexión desde el archivo appsettings.json*/
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext")));

//AddDatabaseDeveloperPageExceptionFilter proporciona información de error útil para errores de migración de EF.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

/*El método EnsureCreated no realiza ninguna acción si existe una base de datos para el contexto. 
Si no existe ninguna base de datos, se crean la base de datos y el esquema. 
EnsureCreated habilita el flujo de trabajo siguiente para controlar los cambios del modelo de datos:*/
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<SchoolContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);//llama la clase inicializar la base de datos de prueba
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
