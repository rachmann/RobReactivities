var builder = WebApplication.CreateBuilder(args);

///////////////////////////////////////////////
// Add services to the container.
builder.Services.AddControllers();

///////////////////////////////////////////////
// Configure the HTTP request pipeline.
var app = builder.Build();

app.MapControllers();

app.Run();
