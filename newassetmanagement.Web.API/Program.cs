
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Register services of all the layers
builder.Services.AddApplication()
    .AddPresentation()
    .AddInfrastructure();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
