using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class MessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.OriginalString.Contains("swagger"))
                return await base.SendAsync(request, cancellationToken);

            var bearerToken = request.Headers.GetValues("Authorization");   
           
            return await base.SendAsync(request, cancellationToken);
        }
    }
}