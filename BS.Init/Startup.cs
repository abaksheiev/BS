using BS.Application;
using BS.Application.Posts.CommandHandlers;
using BS.Contracts.ApiDtos;
using BS.Contracts.PostAggregations.Controllers;
using BS.Contracts.PostAggregations.Validators;
using BS.Contracts.Repositories;
using BS.Domain;
using BS.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BS.Init
{
    public class Startup
    {
        public const string IS_SWAGGER_ACTIVATED = "IS_SWAGGER_ACTIVATED";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add services to the container.
            services.AddControllers();

            var assembly = typeof(PostsController).Assembly;
            services.AddMvc()
                .AddApplicationPart(assembly)
                .AddControllersAsServices();

            services.AddMediatR(i => i.RegisterServicesFromAssembly(typeof(CreatePostCommandHandler).Assembly));

            // Service
            services.AddSingleton(typeof(IValidator<PostApiDto>), typeof(PostApiDtoValidator));
            services.AddSingleton(typeof(IValidator<AuthorApiDto>), typeof(AuthorApiDtoValidator));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // DataBase
            services.AddDbContext<BlogContext>(options =>
                    options.UseInMemoryDatabase("FakeBlog"));
            // Repositories
            services.AddScoped(typeof(IPostRepository), typeof(PostRepository));

            // External nugets
            services.AddAutoMapper(typeof(MappingProfile), typeof(MappingProfile));
            services.AddAutoMapper(typeof(MappingApplicationProfile), typeof(MappingApplicationProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            // Health check
            services.AddHealthChecks();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();
            bool isSwaggerActivated;
            bool.TryParse(configuration[IS_SWAGGER_ACTIVATED], out isSwaggerActivated);

            if (isSwaggerActivated)
            {
                app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });
                app.UseSwaggerUI();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    options.RoutePrefix = string.Empty;
                });
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Posts}/{action=Get}/{id?}");

                endpoints.MapHealthChecks("/healthz");
            });
            app.UseExceptionHandler("/error");
            app.UseHsts();
        }
    }
}
