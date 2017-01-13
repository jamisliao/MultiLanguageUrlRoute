using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MultiLanguageUrlRoute.Extensions;

namespace MultiLanguageUrlRoute
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes(new ApiCultureRouteProvider());
            config.MessageHandlers.Add(new UseAcceptCultureHandler("zh-tw"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
