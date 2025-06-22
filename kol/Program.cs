using System.Text.Json.Serialization;
using kol.Data;
using kol.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(opt => {
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    opt.JsonSerializerOptions.WriteIndented = true;
});

var connectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<KolDbContext>(opt => opt.UseSqlServer(connectionStr));
builder.Services.AddScoped<IKolService, KolService>();


builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v0", new OpenApiInfo{
        Version = "v0",
        Title = "APBD Kol API",
        Description = "Kolokwium EF/CF docs"
    });
});

var app = builder.Build();

app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v0/swagger.json", "APBD Kol API");
    c.DocExpansion(DocExpansion.List);
    c.DefaultModelExpandDepth(0);
    c.DisplayRequestDuration();
    c.EnableFilter();
});


// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();

app.Run();




