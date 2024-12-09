namespace Kiota.App
{
    internal class SaveResponseHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            var responseString = await response.Content.ReadAsStringAsync(cancellationToken);

            Console.WriteLine("Response:");
            Console.WriteLine(responseString);

            return response;
        }
    }
}
