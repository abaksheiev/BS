namespace BS.Init.Registrars
{
    public interface IWebApplicationRegistrar : IRegistrar
    {
        void RegisterPipelineComponents(WebApplication app);
    }
}
