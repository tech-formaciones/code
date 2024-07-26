using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddHttpClient("Default");

builder.Services.AddHttpClient("APIApp", conf => {
    conf.BaseAddress = new Uri("http://127.0.0.1:5000/api/");
    conf.DefaultRequestHeaders.Add("Authorization", "8aaWPy5SzLubp9ApRQbZkWkHA6PFZ33n");
    //conf.DefaultRequestHeaders.Add(HeaderNames.ContentType, "application/json");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
