using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dEV1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Завдання 1: Додавання сервісу для класу Company
            services.AddSingleton<Company>(new Company
            {
                Id = 21167,
                Name = "Grigoretta",
                Address = "Tsilynna street, 9, Mykolaiv, Mykolaiv region",
                Year = 2012
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Company company)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Заміна логіки обробки запитів
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    // Завдання 1: Повернення інформації про Company у відповідь на запит
                    await context.Response.WriteAsync($"Name: {company.Name}, Address: {company.Address}, Year: {company.Year}, Capitalization: {company.Id}");

                    // Завдання 2: Повернення випадкового числа від 0 до 100
                    int randomValue = new Random().Next(0, 101);
                    await context.Response.WriteAsync($"\nRandom value from 0 to 100: {randomValue}");
                });
            });
        }
    }
}
