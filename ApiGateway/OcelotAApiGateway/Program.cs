using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
using JwtTokenAuthentication;
using OcelotAApiGateway.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddJwtAuthentication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<JwtTokenService>();
builder.Services.AddSwaggerGen();
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration)
    .AddCacheManager(x =>
    {
        x.WithDictionaryHandle();
    });
builder.Services.AddControllers();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
// app.MapControllers();
app.UseEndpoints(e => {
    e.MapControllers();
});
app.UseOcelot().Wait();
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");
// });

app.Run();
