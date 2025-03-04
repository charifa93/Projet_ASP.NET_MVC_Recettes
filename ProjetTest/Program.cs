using Common.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Ajout d'implémentation du service d'accès à l'HttpContext
//(dans le but d'atteindre nos variables de session en dehors du controller ou de la vue)
builder.Services.AddHttpContextAccessor();

//Ajout de nos services : Ceux de la BLL et ceux de la DAL
builder.Services.AddScoped<IUserRepository<BLL.Entities.User>, BLL.Services.UserService>();
builder.Services.AddScoped<IUserRepository<DAL.Entities.User>, DAL.Services.UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
;


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
