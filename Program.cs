using Microservices.Data;
using Microservices.Mapper;
using Microservices.Repository;
using Microservices.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(typeof(PatientsMapper));

builder.Services.AddScoped<IPatientRepository,PatientRepository>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));

});


// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://example.com")
                          .AllowAnyMethod()
                          .AllowAnyHeader()
                          .AllowCredentials());
});



var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




// Usar CORS
app.UseCors("AllowSpecificOrigin");


app.UseAuthorization();

app.MapControllers();

app.Run();
