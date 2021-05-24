using Domain.Models;
using Pricing.Infrastructure.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pricing.Infrastructure.Integrations
{
    public class SnappetGarageIntegration : ISnappetGarageIntegration
    {
        private readonly IHttpClientFactory _clientFactory;

        public SnappetGarageIntegration(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<SnappetCar> GetSnappetCar(int carId)
        {
            using (var httpClient = _clientFactory.CreateClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:49159/SnappetCars?carId={carId}");
                var response = await httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };

                    var snappetCar = await JsonSerializer.DeserializeAsync<SnappetCar>(responseStream, options);
                    return snappetCar;
                }
                else
                {
                    return default;
                }
            }
        }
    }
}
