using System;
using System.Web.Http;

namespace FoxyEcomm.Service
{
    [RoutePrefix("api")]
    public sealed class SystemServiceController : ApiController
    {
        [HttpGet]
        [Route("system/info")]
        public IHttpActionResult GetSystemInfo()
        {
            return Ok(new
            {
                Date = DateTime.Now
            });
        }
    }
}
