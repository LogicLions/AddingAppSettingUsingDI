using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AddAppsSettingWithDI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Create service collection for DI
            var serviceCollection = new ServiceCollection();

            // 2. Build Configuration
            IConfiguration configuration;
            configuration = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                      .AddJsonFile("appsettings.json")
                      .Build();

            // 3. Add configuration to ServiceCollection
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<TestConfiguration>();

            // 4. Test
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var testInstance = serviceProvider.GetService<TestConfiguration>();
            testInstance.TestMethod();
        }
    }
}
