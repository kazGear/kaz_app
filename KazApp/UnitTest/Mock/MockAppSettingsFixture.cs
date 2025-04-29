using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;

namespace UnitTest.Mock
{
    /// <summary>
    /// IConfiguration DI用
    /// </summary>
    public class MockAppSettingsFixture
    {
        public IConfigurationRoot Configuration;

        public MockAppSettingsFixture()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(PlatformServices.Default.Application.ApplicationBasePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                ;
            Configuration = builder.Build();
        }
    }
}
