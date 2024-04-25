namespace BS.Init.Registrars
{
    public interface IWebApplicationBuilderRegistrar : IRegistrar
    {
        void RegisterServices(WebApplicationBuilder builder);
    }
}
