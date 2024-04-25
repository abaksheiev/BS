namespace BS.Init.Registrars
{
    public class BogardRegistrar : IWebApplicationBuilderRegistrar
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(BS.Init.MappingProfile), typeof(BS.Init.MappingProfile));
            builder.Services.AddAutoMapper(typeof(BS.Application.MappingApplicationProfile), typeof(BS.Application.MappingApplicationProfile));

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        }
    }
}
