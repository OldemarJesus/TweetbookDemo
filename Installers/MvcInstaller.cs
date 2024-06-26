﻿
namespace Tweetbook.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(x => x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Tweetbook API", Version = "v1" }));
        }
    }
}
