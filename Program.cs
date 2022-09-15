using Classes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors("CorsPolicy");
app.MapGet("/", () => "Hello World!");

app.MapControllers();
app.MapHub<ChartHub>("/chart");

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
