using BS.Application;
using Microsoft.EntityFrameworkCore;

namespace BS.Init.Registrars
{
    public class DbRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<BlogContext>(options =>
                    options.UseInMemoryDatabase("FakeBlog"));
        }
    }
}
