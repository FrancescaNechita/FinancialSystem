using FinancialSystem.IoC;
using FinancialSystem.WebApi.ApiKey;
using FinancialSystem.WebApi.ApiKey.Requirements;
using FinancialSystem.WebApi.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FinancialSystem.WebApi
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "FinancialSystem.WebApi", Version = "v1"});
            });

            services.AddIoc(Configuration);

            //services.AddAuthorization(authConfig =>
            //{
            //    authConfig.AddPolicy("Admin",
            //        policyBuilder => policyBuilder
            //            .AddRequirements(new ApiKeyRequirement(
            //                new List<ApiKey>{ new ApiKey("admin123", "1"), new ApiKey("admin345", "2") })));
            //    authConfig.AddPolicy("User",
            //        policyBuilder => policyBuilder
            //            .AddRequirements(new ApiKeyRequirement(
            //                new List<ApiKey> { new ApiKey("admin123", "1"), new ApiKey("admin345", "2") })));
            //});

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                    options.DefaultChallengeScheme = ApiKeyAuthenticationOptions.DefaultScheme;
                })
                .AddApiKeySupport(options => { });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.OnlyAdmins, policy => policy.Requirements.Add(new OnlyAdminsRequirement()));
                options.AddPolicy(Policies.AllUsers, policy => policy.Requirements.Add(new AllUsersRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, AuthorizationHandler>();
            services.AddSingleton<IGetApiKeyQuery, InMemoryGetApiKeyQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinancialSystem.WebApi v1"));
            }

            app.UseAppMiddlewares();
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
