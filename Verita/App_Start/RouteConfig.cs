using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Verita
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Urunlerimiz",
               url: "urunlerimiz/{id}",
               defaults: new { controller = "Home", action = "Urunlerimiz", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "MerakEttikleriniz",
                url: "merak-ettikleriniz/{id}",
                defaults: new { controller = "Home", action = "MerakEttikleriniz", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Verita",
                url: "verita/{id}",
                defaults: new { controller = "Home", action = "Verita", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "B2bUrun",
                url: "B2bUrun/{id}",
                defaults: new { controller = "Home", action = "B2bUrun", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "B2bUrunler",
                url: "b2b-urunler/{f}",
                defaults: new { controller = "Home", action = "B2bUrunler", f = UrlParameter.Optional });

            routes.MapRoute(
                name: "GidaGuvenligi",
                url: "gida-guvenligi/{id}",
                defaults: new { controller = "Home", action = "GidaGuvenligi", id = UrlParameter.Optional });

            routes.MapRoute(
              name: "BunlariBiliyorMusunuz",
              url: "bunlari-biliyor-musunuz/{id}",
              defaults: new { controller = "Home", action = "BunlariBiliyorMusunuz", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Iletisim",
                url: "bize-ulasin/{id}",
                defaults: new { controller = "Home", action = "Iletisim", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "BasindaBiz",
                url: "basinda-biz/{id}",
                defaults: new { controller = "Home", action = "BasindaBiz", id = UrlParameter.Optional });

            routes.MapRoute(
            name: "Hakkimizda",
            url: "hakkimizda/{id}",
            defaults: new { controller = "Home", action = "Hakkimizda", id = UrlParameter.Optional });


            routes.MapRoute(
            name: "EgzotikMeyveler",
            url: "egzotik-meyveler/{id}",
            defaults: new { controller = "Home", action = "EgzotikMeyveler", id = UrlParameter.Optional });

            routes.MapRoute(
           name: "VeritaGurmeKivi",
           url: "verita-gurme-kivi/{id}",
           defaults: new { controller = "Home", action = "VeritaGurmeKivi", id = UrlParameter.Optional });

            routes.MapRoute(
         name: "OrganizasyonYapisi",
         url: "organizasyon-yapisi/{id}",
         defaults: new { controller = "Home", action = "OrganizasyonYapisi", id = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });


        }
    }
}
