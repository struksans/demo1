using Microsoft.Extensions.DependencyInjection;
using QRCode.Service;

namespace QRCode.Bootstrap
{
    public static class ConfigureDependencies
    {
        public static IServiceCollection AddAppDependencies(this ServiceCollection serviceProvider)
        {
            serviceProvider
                .AddHttpClient()
                .AddTransient<IQRScannerService, QRScannerService>()
                .AddTransient<IQRServerClient, QRServerClient>()
                .AddTransient<IFileHandler, FileHandler>();
            return serviceProvider;
        }
    }
}
