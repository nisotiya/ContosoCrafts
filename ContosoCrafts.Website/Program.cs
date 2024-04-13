using System.Text.Json;
using ContosoCrafts.Website.Models;
using ContosoCrafts.Website.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<JsonFileProductService>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
//app.MapGet("/products", (context) =>
//    {
//        var products = app.ApplicationServices.GetService<JsonFileProductService>().GetProducts();
//        var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
//        return context.Response.WriteAsync(json);
//    });

app.Run();
