﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using Microsoft.Owin.Security.SSQSignon;

namespace server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Auth",
                routeTemplate: "auth/{*command}",
                defaults: new { controller = "AuthProxy", command = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Home",
                routeTemplate: "",
                defaults: new { controller = "Home" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
