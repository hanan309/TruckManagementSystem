using Microsoft.EntityFrameworkCore;
using TruckManagementSystem.API.Data;
using TruckManagementSystem.API.Repositories;
using TruckManagementSystem.API.Services;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// ------------------ DbContext ------------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ------------------ Repositories ------------------
builder.Services.AddScoped<IRouteRepository, RouteRepository>();
builder.Services.AddScoped<ITruckRepository, TruckRepository>();
builder.Services.AddScoped<ITruckAssignmentRepository, TruckAssignmentRepository>();

// ------------------ Services ------------------
builder.Services.AddScoped<IRouteService, RouteService>();
builder.Services.AddScoped<ITruckService, TruckService>();
builder.Services.AddScoped<ITruckAssignmentService, TruckAssignmentService>();

// ------------------ Controllers & JSON ------------------
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        // FIX: Return camelCase JSON so Angular can read property names correctly
        // e.g. "truckId" instead of "TruckId", "fromCity" instead of "FromCity"
        options.SerializerSettings.ContractResolver =
            new CamelCasePropertyNamesContractResolver();

        // Keep existing fix for circular reference loops
        options.SerializerSettings.ReferenceLoopHandling =
            Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// ------------------ CORS ------------------
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// ------------------ Swagger ------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();