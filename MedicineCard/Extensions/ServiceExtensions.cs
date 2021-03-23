using MedicineCard.Logger;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineCard.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin() //else WithOrigins("http://www.somewebsite.com") allow requests from the specified source
                    .AllowAnyMethod() //else WithMethods("POST", "GET"...) allow only specified HTTP methods
                    .AllowAnyHeader()); //else WithHeadesr("accept", "conten-type") method to allow only specified headers
            });
            
        }

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
