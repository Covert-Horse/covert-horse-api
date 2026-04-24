using Covert.Horse.Api.Security;   
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Covert.Horse.Api.Data;

var builder = WebApplication.CreateBuilder(args);

string authority = builder.Configuration["Auth0:Authority"] 
    ?? throw new ArgumentNullException("Auth0:Authority");

string audience = builder.Configuration["Auth0:Audience"] 
    ?? throw new ArgumentNullException("Auth0:Audience");

// Add services
builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.Authority = authority;
    options.Audience = audience;
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("delete:catalog", policy =>
        policy.Requirements.Add(new HasScopeRequirements("delete:catalog", authority)));
});
builder.Services.AddDbContext<StoreContext>(opt =>
    opt.UseSqlite("Data Source=store.db"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure middleware
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();

app.UseAuthentication();   
app.UseAuthorization();

app.MapControllers();

app.UseAuthorization();

app.Run();