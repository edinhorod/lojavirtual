using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //CRIANDO UM NOVA ROTA PARA UM URL AMIGÁVEL PARA A PAGINA DE LISTA DE PRODUTOS
            //ANTES: ?pagina=2, DEPOIS: Pagina2
            routes.MapRoute(
                name:null,//NOME DA ROTA 
                url: "Pagina{pagina}", //COMO FICARÁ A URL. {pagina} É O PARÂMETRO
                defaults: new  {controller = "Vitrine", action = "ListaProdutos" }
                //controller: INFORMANDO O CONTROLLER, action: QUAL PÁGINA IRÁ RECEBER ESSA ROTA
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
