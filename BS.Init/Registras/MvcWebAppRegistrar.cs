using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace BS.Init.Registrars
{
    public class MvcWebAppRegistrar : IWebApplicationRegistrar
    {
        public void RegisterPipelineComponents(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
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
            });

            app.UseApiVersioning();
            
            
            
            app.UseAuthorization();

            app.MapControllers();
        }
    }
}
