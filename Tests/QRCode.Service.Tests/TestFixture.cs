using System;
using Microsoft.Extensions.DependencyInjection;
using QRCode.Bootstrap;

namespace QRCode.Service.Tests
{
    //Can be used to configure common infrastructure for entire test collection
    //Can mock/resolve common dependencies
    //Finds great use in integrations tests
    public class TestFixture : IDisposable
    {
        public readonly IServiceProvider ServiceProvider;

        public TestFixture()
        {
            ServiceProvider = new ServiceCollection()
                .AddAppDependencies()
                .BuildServiceProvider();
        }

        public void Dispose()
        {

        }
    }
}
