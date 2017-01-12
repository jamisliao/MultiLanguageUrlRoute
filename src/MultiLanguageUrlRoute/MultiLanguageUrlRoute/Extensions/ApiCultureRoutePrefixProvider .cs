using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace MultiLanguageUrlRoute.Extensions
{
    public class ApiCultureRoutePrefixProvider : DefaultDirectRouteProvider
    {
        protected override IReadOnlyList<IDirectRouteFactory> GetActionRouteFactories(HttpActionDescriptor actionDescriptor)
        {
            IReadOnlyList<IDirectRouteFactory> actionRouteFactories = base.GetActionRouteFactories(actionDescriptor);

            List<IDirectRouteFactory> actionDirectRouteFactories = new List<IDirectRouteFactory>();
            foreach (IDirectRouteFactory routeFactory in actionRouteFactories)
            {
                RouteAttribute routeAttr = routeFactory as RouteAttribute;
                if (routeAttr != null && !string.IsNullOrEmpty(routeAttr.Template))
                {
                    var template = $"API/{routeAttr.Template}";
                    var includeLangTemplate = $"{{lang}}/API/{routeAttr.Template}";

                    var routeAttribute = new RouteAttribute(template)
                    {
                        Order = routeAttr.Order,
                        Name = routeAttr.Name
                    };

                    actionDirectRouteFactories.Add(routeAttribute);

                    var includeLangRouteAttribute = new RouteAttribute(includeLangTemplate);
                    routeAttribute.Order = routeAttr.Order + 1;
                    routeAttribute.Name = routeAttr.Name;
                    actionDirectRouteFactories.Add(includeLangRouteAttribute);
                }
            }

            return new ReadOnlyCollection<IDirectRouteFactory>(actionDirectRouteFactories); ;
        }
    }
}