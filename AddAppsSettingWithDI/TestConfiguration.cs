using Microsoft.Extensions.Configuration;

namespace AddAppsSettingWithDI
{
    public class TestConfiguration
    {
        public readonly IConfiguration configration;

        public TestConfiguration(IConfiguration configuration)
        {
            this.configration = configuration;
        }

        public void TestMethod() 
        {
            var dataFromJsonFile = configration.GetSection("Name").Value;
            Console.WriteLine(dataFromJsonFile);
        }
    }
}
