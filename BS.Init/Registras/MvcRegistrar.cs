using BS.Application.Posts.CommandHandlers;
using BS.Contracts.ApiDtos;
using BS.Contracts.PostAggregations.Controllers;
using BS.Contracts.PostAggregations.Validators;

namespace BS.Init.Registrars
{
    public class MvcRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            
            // Add services to the container.
             builder.Services.AddControllers();

            var assembly = typeof(PostsController).Assembly;
            builder.Services.AddMvc()
                .AddApplicationPart(assembly)
                .AddControllersAsServices();
        
            builder.Services.AddMediatR(i => i.RegisterServicesFromAssembly(typeof(CreatePostCommandHandler).Assembly));

            // Service
            builder.Services.AddSingleton(typeof(IValidator<PostApiDto>), typeof(PostCreateModelValidator));
            builder.Services.AddSingleton(typeof(IValidator<AuthorApiDto>), typeof(AuthorApiDtoValidator));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}
