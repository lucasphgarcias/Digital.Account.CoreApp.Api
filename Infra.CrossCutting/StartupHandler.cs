using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infra.CrossCutting.Services;

namespace Infra.CrossCutting
{
    public class StartupHandler
    {
        private readonly List<IServicesStartup> _servicesToStartup;
        private readonly List<IApplicationBuilderStartup> _appBuilders;

        public StartupHandler()
        {
            _servicesToStartup = new List<IServicesStartup>()
            {
                new RepositoryStartup(),
                new UseCaseStartup(),
                new ControllerStartup(),
                new SwaggerStartup()
            };

            _appBuilders = new List<IApplicationBuilderStartup>()
            {
                new RepositoryStartup(),
                new ControllerStartup(),
                new SwaggerStartup()
            };
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            _servicesToStartup.ForEach(service => service.ConfigureServices(services, configuration));
        }

        public void ConfigureApp(IApplicationBuilder app)
        {
            _appBuilders.ForEach(service => service.ConfigureApp(app));

            app.UseHttpsRedirection();
            app.UseAuthorization();
        }
    }

    public interface IServicesStartup
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }

    public interface IApplicationBuilderStartup
    {
        void ConfigureApp(IApplicationBuilder app);
    }
} 