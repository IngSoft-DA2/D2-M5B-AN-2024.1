using Logic;
using Logic.Models;
using Drugs;
using Medicines;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;
namespace ServicesFactoryy;

public class ServicesFactory
{


    public ServicesFactory()
    {

    }


    public void RegistrateServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IDrugsService, DrugsService>();
        serviceCollection.AddScoped<IMedicineService, MedicineService>();

        serviceCollection.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins("http://localhost:8080", "http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });
    }


}
