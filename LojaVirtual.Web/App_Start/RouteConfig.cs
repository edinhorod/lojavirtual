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

            //1 ROTA: LISTA TODOS OS PRODUTOS
            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    categoria = (string)null,
                    pagina = 1
                });

            //2 ROTA: TODOS OS PRODUTOS DIVIDIDOS POR PAGINA
            routes.MapRoute(null,
                 "Pagina{pagina}",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    categoria = (string)null
                },
                    new { pagina = @"\d+" }
            );

            //3 ROTA: PRIMEIRA PAGINA DE UMA CATEGORIA
            routes.MapRoute(null, "{categoria}",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                    pagina = 1
                });

            //4 ROTA: TODAS AS CATEGORIAS DIVIDIDAS POR PAGINA
            routes.MapRoute(null,
                 "{categoria}Pagina{pagina}",
                new
                {
                    controller = "Vitrine",
                    action = "ListaProdutos",
                },
                    new { pagina = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");


        }
    }
}
