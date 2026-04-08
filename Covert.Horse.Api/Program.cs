using Microsoft.EntityFrameworkCore;
using Covert.Horse.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
    opt.UseSqlite("Data Source=store.db"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();