﻿using System.Web.Http;
using System.Web.Http.Cors;
using AuditoriasCiudadanas.Api.Filters;

namespace AuditoriasCiudadanas.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new RequireHttps());
            config.Filters.Add(new RequireModelValidation());

            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }
    }
}