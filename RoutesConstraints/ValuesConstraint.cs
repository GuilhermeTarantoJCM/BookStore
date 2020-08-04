using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.RoutesConstraints
{
    public class ValuesConstraint : IRouteConstraint
    {
        private readonly string[] validOptions;
        public ValuesConstraint(string options)
        {
            validOptions = options.Split('|');
        }

        public bool Match(HttpContext httpContext, IRouter route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(parameterName, out object value) && value != null)
            {
                return validOptions.Contains(value.ToString(), StringComparer.OrdinalIgnoreCase);
            }
            return false;
        }
    }
}
