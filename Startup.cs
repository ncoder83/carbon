using AutoMapper;
using Carbon.DataLayer.Context;
using Carbon.Services;
using Carbon.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Carbon
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddAutoMapper(typeof(Startup));

            //dependency injection
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IBenefitService, BenefitService>();
            services.AddScoped<IAccountService, AccountService>();

            //connect our context to the carbon data
            services.AddDbContext<CarbonDbContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("CarbonDatabase"))
            );

            //setup cors
            services.AddCors(options => 
            {
                options.AddPolicy("AllowAll",
                   
                    p => p.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod()                         
                          .WithOrigins("http://localhost:8080", "https://vuestaticapp.z19.web.core.windows.net").Build()                  
                );
            });


            services.AddSwaggerGen();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");
            
            app.UseSwagger();
            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
