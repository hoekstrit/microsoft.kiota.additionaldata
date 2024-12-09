using Kiota.Api.Client;
using Kiota.Api.Client.Models;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;

namespace Kiota.App
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            KiotaApiClient client = CreateKiotaApiClient();

            await RunProblemDetailsScenario(client);

            Console.WriteLine(Environment.NewLine);

            await RunHttpValidationProblemDetailsScenario(client);

            Console.ReadKey();
        }

        private static async Task RunHttpValidationProblemDetailsScenario(KiotaApiClient client)
        {
            Console.WriteLine($"HttpValidationProblemDetails scenario");

            // Weather Forecast will be invalid because of missing 'Summary'
            var invalidWeatherForecast = new WeatherForecast
            {
                Date = new Date(DateTime.Now),
                TemperatureC = 32,
                TemperatureF = 100,
            };

            try
            {
                _ = await client.Api.V1.WeatherForecast.PostAsync(invalidWeatherForecast);
            }
            catch (HttpValidationProblemDetails httpValidationProblemDetails)
            {
                httpValidationProblemDetails.AdditionalData.TryGetValue("traceId", out object traceId);
                Console.WriteLine($"TraceId: {traceId}");
            }
        }

        private static async Task RunProblemDetailsScenario(KiotaApiClient client)
        {
            Console.WriteLine($"ProblemDetails scenario");

            // Weather Forecast will throw ArgumentOutOfRangeException because of Date is before today
            var yesterdaysWeatherForecast = new WeatherForecast
            {
                Date = new Date(DateTime.Now.AddDays(-1)),
                Summary = "Yesterdays weather forecast",
                TemperatureC = 32,
                TemperatureF = 100,
            };

            try
            {
                await client.Api.V1.WeatherForecast.PostAsync(yesterdaysWeatherForecast);
            }
            catch (ProblemDetails problemDetails)
            {
                problemDetails.AdditionalData.TryGetValue("traceId", out object traceId);
                Console.WriteLine($"TraceId: {traceId}");
            }
        }

        private static KiotaApiClient CreateKiotaApiClient()
        {
            var handlers = new List<DelegatingHandler>
            {
                new SaveResponseHandler()
            };

            var httpMessageHandler =
                KiotaClientFactory.ChainHandlersCollectionAndGetFirstLink(
                    KiotaClientFactory.GetDefaultHttpMessageHandler(),
                    handlers.ToArray());

            var httpClient = new HttpClient(httpMessageHandler!);

            var httpClientRequestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient)
            {
                BaseUrl = "https://localhost:5003"
            };

            return new KiotaApiClient(httpClientRequestAdapter);
        }
    }
}
