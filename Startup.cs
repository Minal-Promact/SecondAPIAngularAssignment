using Microsoft.EntityFrameworkCore;
using SecondAPIAngularAssignment.Data;

namespace SecondAPIAngularAssignment
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddScoped<EFDataContext>();            
            services.AddDbContext<EFDataContext>(options =>
            options.UseNpgsql(configRoot.GetConnectionString("WebApiDatabase")));
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //    builder => builder
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .AllowCredentials()
            //    );
            //});
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularOrigins",
                builder =>
                {
                    builder.WithOrigins(
                                        "http://localhost:4200", "https://localhost:7278"
                                        )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });

        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseResponseCaching();
            app.UseCors("AllowAngularOrigins");
            app.MapRazorPages();
            app.Run();
        }
    }
}
