using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connString = builder.Configuration["ConnectionStrings:SqlConnectionString"];

var sqlBuilder = new SqlConnectionStringBuilder(connString);

sqlBuilder.Password = builder.Configuration["Password:SqlPassword"]; // bu �ekilde sadece passwordu secret.json'da da tutup birle�tirme i�lemini yapabiliriz.   


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
