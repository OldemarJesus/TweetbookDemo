﻿
using Cosmonaut;
using Cosmonaut.Extensions.Microsoft.DependencyInjection;
using Microsoft.Azure.Documents.Client;
using Tweetbook.Domain;

namespace Tweetbook.Installers
{
    public class CosmosInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var cosmosStoreSettings = new CosmosStoreSettings(
                configuration["CosmosSettings:DatabaseName"],
                configuration["CosmosSettings:AccountUri"],
                configuration["CosmosSettings:AccountKey"],
                new ConnectionPolicy { 
                    ConnectionMode = ConnectionMode.Direct, 
                    ConnectionProtocol = Protocol.Tcp,
                });
            services.AddCosmosStore<CosmosPostDto>(cosmosStoreSettings);
        }
    }
}
