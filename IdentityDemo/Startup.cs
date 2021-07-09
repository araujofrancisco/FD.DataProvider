using IdentityDemo.Areas.Identity;
using IdentityDemo.Data;
using FD.SampleData.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace IdentityDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // set dbcontext factory options and register it as singleton to allow using memory database
            // until the service gets shutdown
            //            services.AddDbContextFactory<ApplicationDbContext>(options =>
            //            {
            //#if DEBUG
            //                options.EnableDetailedErrors(true);
            //                options.EnableSensitiveDataLogging(true);
            //#endif
            //            });
            services
                .AddSingleton<FD.SampleData.Interfaces.IDbContextFactory<ApplicationDbContext>, DbContextFactory<ApplicationDbContext>>()
                // register the method to obtain a new context and creates the database if there is no a previous connection
                .AddScoped(p => p.GetRequiredService<FD.SampleData.Interfaces.IDbContextFactory<ApplicationDbContext>>().CreateContext())
                .AddScoped(p => p.GetRequiredService<FD.SampleData.Interfaces.IDbContextFactory<ApplicationDbContext>>().ConnectionRestricted)
                // custom data access service
                .AddScoped<IDataService, DataService>();        

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // custom seeder
            SeedDb(app.ApplicationServices);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });            
        }

        // on generated data seed size will indicate how many records we want to create
        private const int seedSize = 1000;

        /// <summary>
        /// Executes database seeder just after all application services has started.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public void SeedDb(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            DbInitializer<ApplicationDbContext>.Initialize(scope, context, seedSize);
        }
    }
}
