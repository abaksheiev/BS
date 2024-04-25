using BS.Application;
using BS.Application.Posts.CommandHandlers;
using BS.Contracts.ApiDtos;
using BS.Contracts.PostAggregations.Controllers;
using BS.Contracts.PostAggregations.Validators;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BS.IntegrationTests.Core
{
    public class StartupContext
    {
        public IConfiguration Configuration { get; }

        public StartupContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(BS.Init.MappingProfile), typeof(BS.Init.MappingProfile));
            services.AddAutoMapper(typeof(BS.Application.MappingApplicationProfile), typeof(BS.Application.MappingApplicationProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            
            services.AddDbContext<BlogContext>(options =>
                   options.UseInMemoryDatabase("FakeBlog"));
            //-----------//-----------//-----------//-----------//-----------
            // Add services to the container.
            services.AddControllers();

            var assembly = typeof(PostsController).Assembly;
            services.AddMvc()
                .AddApplicationPart(assembly)
                .AddControllersAsServices();

            services.AddMediatR(i => i.RegisterServicesFromAssembly(typeof(CreatePostCommandHandler).Assembly));

            // Service
            services.AddSingleton(typeof(IValidator<PostApiDto>), typeof(PostCreateModelValidator));
            services.AddSingleton(typeof(IValidator<AuthorApiDto>), typeof(AuthorApiDtoValidator));

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            //-----------//-----------//-----------//-----------//-----------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.MapControllers();
        }
    }
}