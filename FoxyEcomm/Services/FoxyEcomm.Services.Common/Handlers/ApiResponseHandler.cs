using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using FoxyEcomm.Common.Models;
using Newtonsoft.Json;

namespace FoxyEcomm.Services.Common.Handlers
{
    public class ApiResponseHandler : DelegatingHandler
    {
        protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            return BuildApiResponse(request, response);
        }

        private static HttpResponseMessage BuildApiResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            object content;
            List<string> errors = new List<string>();

            if (response.TryGetContentValue(out content) && !response.IsSuccessStatusCode)
            {
                HttpError error = content as HttpError;
                if (error != null)
                {
                    content = null;
                    if (error.ModelState != null)
                    {
                        var httpErrorObject = response.Content.ReadAsStringAsync().Result;

                        var anonymousErrorObject = new {message = "", ModelState = new Dictionary<string, string[]>()};

                        var deserializedErrorObject = JsonConvert.DeserializeAnonymousType(httpErrorObject,
                            anonymousErrorObject);

                        var modelStateValues =
                            deserializedErrorObject.ModelState.Select(kvp => string.Join(". ", kvp.Value));

                        var stateValues = modelStateValues as string[] ?? modelStateValues.ToArray();
                        for (int i = 0; i < stateValues.Count(); i++)
                        {
                            errors.Add(stateValues.ElementAt(i));
                        }
                    }
                    else
                    {
                        foreach (var loopError in error)
                        {
                            errors.Add(loopError.Key == "Message"
                                ? string.Format("{0} ", loopError.Value)
                                : string.Format("{0}: {1} ", loopError.Key, loopError.Value));
                        }
                    }
                }
            }

            var newResponse = CreateHttpResponseMessage(request, response, content, errors);

            foreach (var header in response.Headers)     
            {
                if (!string.IsNullOrEmpty(header.Key) && header.Value.Any(h => !string.IsNullOrEmpty(h)))
                {
                    newResponse.Headers.Add(header.Key, header.Value);
                }
            }

            return newResponse;
         
        }

        private static HttpResponseMessage CreateHttpResponseMessage<T>(HttpRequestMessage request, HttpResponseMessage response, T content, List<string> errors)
        {
            return request.CreateResponse(response.StatusCode, new ApiResponse<T>(response.StatusCode, content, errors));
        }
        
    }
}
