using Drugs;
using Logic;
using Medicines;
using WebAPI.Filters;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.Filters.Add(new HeaderValidationFilter()); // Agrega el filtro de validación de encabezado
    options.Filters.Add(new CommonResponseFilter()); // Agrega el filtro de respuesta común
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMedicineService, MedicineService>();
builder.Services.AddScoped<IDrugsService, DrugsService>();
builder.Services.AddScoped<HeaderValidationFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
