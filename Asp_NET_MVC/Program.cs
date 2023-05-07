var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();


//app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute
    (
    name: "default",
    pattern: "{controller}/{action}/{id?}"

    );
});

app.Run();
