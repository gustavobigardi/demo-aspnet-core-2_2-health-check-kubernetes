using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace DemoHealthCheck
{
    public class MockHealthCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("https://demo9613882.mockable.io/test-health");

            if (result.IsSuccessStatusCode)
            {
                return HealthCheckResult.Healthy("The API is working fine!");
            }
            else 
            {
                return HealthCheckResult.Unhealthy("The API is DOWN!");
            }
        }
    }
}