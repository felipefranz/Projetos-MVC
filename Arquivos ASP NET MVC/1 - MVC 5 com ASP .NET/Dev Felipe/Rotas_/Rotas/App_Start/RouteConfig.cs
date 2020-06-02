using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Rotas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Todas as Noticias", //Nome de definição
                url: "noticias/", //Url no navegador
                defaults: new { controller = "Home", action = "TodasasNoticias" } //Nome do Controller e nome Action chamada
            );

            routes.MapRoute(
                name: "Categoria Especifica", //Nome de definição
                url: "noticias/{categoria}", //Url no navegador
                defaults: new { controller = "Home", action = "MostraCategoria" } //Nome do Controller e nome Action chamada
            );

            routes.MapRoute(
                name: "Mostra Noticia", //Nome de definição
                url: "noticias/{categoria}/{titulo}-{noticiaId}", //Url no navegador
                defaults: new { controller = "Home", action = "MostraNoticia" } //Nome do Controller e nome Action chamada
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
