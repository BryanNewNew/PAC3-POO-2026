using Planillas.API.Services.Employees;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

//Agregar controllers
builder.Services.AddTransient<IEmployeeService, EmployeeServes>();//= new no es necesario para crear un objeto ya que
//este crea un fuerte acoplamiento en el proyecto.
//Al hacer este no es necesario crear un objeto de la clase EmployeeServes ya que el framework se encarga de crear el objeto y de inyectarlo en el controlador


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();//se usa para moverse

app.Run();


