using InventarySystemAPI.Context;
using InventarySystemAPI.Modules.Authentication.Application;
using InventarySystemAPI.Modules.Authentication.Domain.Interfaces;
using InventarySystemAPI.Modules.Authentication.Infrastructure;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add Services CORS
builder.Services.AddCors(policy => {
    policy.AddPolicy(name: MyAllowSpecificOrigins,
        p => p.WithOrigins("http://localhost:5174").AllowAnyMethod()
    );
});
// Mapping Controller with JSON Options.
builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
// Add DbContext
builder.Services.AddDbContextPool<InventarySystemContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

// Add Dependency Inversion - Auth Module
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Swagger UI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Scoped Database
using (var scoped = app.Services.CreateScope())
{
    var context = scoped.ServiceProvider.GetRequiredService<InventarySystemContext>();
    context.Database.EnsureCreated();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);
// app.UseHttpsRedirection();
app.MapControllers();

app.Run();
