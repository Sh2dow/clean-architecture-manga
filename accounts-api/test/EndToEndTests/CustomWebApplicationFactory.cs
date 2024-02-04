namespace EndToEndTests;

using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using WebApi;

/// <summary>
/// </summary>
public sealed class CustomWebApplicationFactory : WebApplicationFactory<Startup>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder) => builder.ConfigureAppConfiguration(
        (context, config) =>
        {
            config.AddInMemoryCollection(
                new Dictionary<string, string>
                {
                    ["FeatureManagement:SQLServer"] = "true",
                    ["PersistenceModule:DefaultConnection"] =
                        "Data Source=.;Initial Catalog=aspnet-clean-architecture-manga;User ID=sa;Password=123;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=true",
                    ["FeatureManagement:CurrencyExchangeModule"] = "true"
                });
        });
}
