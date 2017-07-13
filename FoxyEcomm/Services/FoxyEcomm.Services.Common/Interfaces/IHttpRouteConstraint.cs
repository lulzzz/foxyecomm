using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;

namespace FoxyEcomm.Services.Common.Interfaces
{
    public interface IHttpRouteConstraint
    {
        bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName, IDictionary<string, object> values, HttpRouteDirection routeDirection);
    }
}
