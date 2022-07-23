namespace AntBlazor.Client.Providers
{
    public class HttpClientProvider
    {
        public readonly HttpClient Client;

        public HttpClientProvider(IHttpClientFactory httpClientFactory)
        {
            Client = httpClientFactory.CreateClient("API");
        }
    }
}
