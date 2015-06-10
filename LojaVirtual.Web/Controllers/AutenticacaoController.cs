using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LojaVirtual.Dominio.Entidade;
using LojaVirtual.Dominio.Repositorio;

namespace LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AdministradoresRepositorio _repositorio;
        
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Administrador());
        }

        [HttpPost]
        public ActionResult Login(Administrador administrador, string returnUrl)
        {
            _repositorio = new AdministradoresRepositorio();
            if(ModelState.IsValid)
            {
                Administrador admin = _repositorio.ObterAdministrador(administrador);
                /*Validando o administrador:
                 Se admin (repostirório, BD) não for válido é porque ele não achou o administrador no banco
                 */
                if(admin!= null)
                {
                    /*Validando a senha:
                      Verificando se a senha recebida do administrador (passado po parâmetro para o método através
                      dos inputs na tela de login) é igual a senha do admin que está no repositório (BD)*/
                    if(!Equals(administrador.Senha, admin.Senha))
                    {
                        ModelState.AddModelError("","Senha não confere");                        
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(admin.Login, false);
                        if (Url.IsLocalUrl(returnUrl)
                            && returnUrl.Length > 1
                            && returnUrl.StartsWith("/")
                            && !returnUrl.StartsWith("//")
                            && returnUrl.StartsWith("/\\")
                            )
                        {
                            return Redirect(returnUrl);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuário não encontrado");
                }
            }
            return View(new Administrador());
        }

        
	}
}