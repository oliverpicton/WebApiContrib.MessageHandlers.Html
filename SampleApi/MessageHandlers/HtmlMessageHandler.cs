using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SampleApi.MessageHandlers
{    
    public class HtmlMessageHandler : DelegatingHandler
    {
        private List<string> contentTypes = new List<string> { "text/html", "application/html", "application/xhtml+xml" };

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {                                
            if (request.Method == HttpMethod.Get && request.Headers.Accept.Any(h => contentTypes.Contains(h.ToString())))
            {
                var response = new HttpResponseMessage(HttpStatusCode.Redirect);

                var htmlUri = new Uri(String.Format("{0}/html", request.RequestUri.AbsoluteUri));
                response.Headers.Location = htmlUri;

                return Task.Factory.StartNew<HttpResponseMessage>(() => response);
            }
            else
            {
                return base.SendAsync(request, cancellationToken);
            }
        }
    }    
}