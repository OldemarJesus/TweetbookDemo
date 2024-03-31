using System.Runtime.CompilerServices;
using Tweetbook.Domain;

namespace Tweetbook.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssebly(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.
            var installers = typeof(Program).Assembly.ExportedTypes
                    .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                    .Select(Activator.CreateInstance)
                    .Cast<IInstaller>()
                    .ToList();
            installers.ForEach(install => install.InstallServices(services, configuration));
        }
    }
}
