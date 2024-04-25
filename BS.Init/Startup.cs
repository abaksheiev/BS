﻿using BS.Repositories;
using BS.Repositories.Posts.CommandHandlers;
using BS.Contracts.ApiDtos;
using BS.Contracts.PostAggregations.Controllers;
using BS.Contracts.PostAggregations.Validators;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

namespace BS.Init
{
    public class Startup
    {
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

            // External nugets
            services.AddAutoMapper(typeof(BS.Init.MappingProfile), typeof(BS.Init.MappingProfile));
            services.AddAutoMapper(typeof(BS.Repositories.MappingApplicationProfile), typeof(BS.Repositories.MappingApplicationProfile));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
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


                app.UseRouting();
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Posts}/{action=Get}/{id?}");
                });
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }
        }
    }
}
