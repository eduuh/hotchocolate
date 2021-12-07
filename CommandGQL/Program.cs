using CommandGQL.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var connectionStr = builder.Configuration.GetConnectionString("CommandConStr");
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionStr));
app.MapGet("/", () => "Hello World!");

app.Run();
