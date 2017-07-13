using System;
using System.Collections.Generic;
using System.Web.Http.Routing;
using FoxyEcomm.Services.Common.Models;

namespace FoxyEcomm.Services.Common.Attributes
{
    public class VersionedRoute : RouteFactoryAttribute
    {
        public VersionedRoute(String template, Int32 allowedVersion)
            : base(template)
        {
            AllowedVersion = allowedVersion;
        }

        public Int32 AllowedVersion
        {
            get;
            private set;
        }

        public override IDictionary<String, Object> Constraints
        {
            get
            {
                var constraints = new HttpRouteValueDictionary();
                constraints.Add("version", new VersionConstraint(AllowedVersion));
                return constraints;
            }
        }
    }
}
