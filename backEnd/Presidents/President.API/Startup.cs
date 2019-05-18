using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using President.Data;
using President.Data.DBInitialize;
using PresidentES.Service;

namespace President.API
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
            services.AddDbContext<PresidentContext>
            (options => options.UseSqlServer(Configuration.GetConnectionString("PresidentDatabase")));
            services.AddMvc();

            services.AddCors(option =>
            {
                option.AddPolicy("miPolitica",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                    });
            });

            services.AddTransient<IPresidentService, PresidentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, PresidentContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("miPolitica");
            app.UseMvc();
            context.Database.EnsureCreated();
            DBInitializer.Initialize(context);
        }
    }
}
