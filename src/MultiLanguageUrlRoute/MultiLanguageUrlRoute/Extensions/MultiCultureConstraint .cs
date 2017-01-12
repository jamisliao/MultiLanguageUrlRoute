using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MultiLanguageUrlRoute.Extensions
{
    public class MultiCultureConstraintx : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values,
                            RouteDirection routeDirection)
        {
            string[] constraintName = new string[] { "en", "jp", "ko" };
            if (values.ContainsKey(parameterName))
            {
                var stringValue = values[parameterName] as string;
                //不考慮大小寫的比對方式
                return Array.Exists(constraintName, val => val.Equals(stringValue, StringComparison.InvariantCultureIgnoreCase));
            }
            return false;
        }
    }
}