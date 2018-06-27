using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TreeBranchWeb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Keys",
                url: "Keys/{keyName}/{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Keys",
                    action = "Index",
                    id = UrlParameter.Optional
                },
                constraints: new
                {
                    keyName = @"(\p{L})+",
                    controller = "Keys|Questions|Matches"
                }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new
                {
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }
            );
        }
    }
}
