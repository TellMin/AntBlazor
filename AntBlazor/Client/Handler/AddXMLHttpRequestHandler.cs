using System.Net.Http;

namespace AntBlazor.Client.Handler
{
    public class AddXMLHttpRequestHandler : DelegatingHandler
    {
        public AddXMLHttpRequestHandler() : base(new HttpClientHandler()) { }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
