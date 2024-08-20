using Microsoft.Extensions.Options;
using ServiceOrderManagerV3.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Injetando dependencia do db context options do arquivo AppDbCOntext
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ServiceOrderManagerV3")));

// (options => options.UseSqlServer == Usanda metodos do options como argumento que herda do entity framework
// Metodo use sql server usa sql server == Recebe uma string de conexao definida no appsetting (Examamente mesmo nome )
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

app.UseAuthorization();

// Valores padrao das rotas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Por padrao o controller ira olhar para o metodos index
// o metodo  index ira olhar para a view padra (index )usando o nome nome do controller
// == nome dir em views que tera uma view correspondente ao nome do metodo no controller


app.Run();
