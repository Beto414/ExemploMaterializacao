using ExemploMaterializacao.ServicoExposto;
using System.ServiceModel;
using System.Web.Mvc;
using System.Web.Security; 

namespace ExemploMaterializacao.Controllers
{
    public class AccountController : Controller
    {
        private readonly ServicoSoapClient _servico = new ServicoSoapClient();

        // GET: /Account/Login
        [AllowAnonymous] 
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TO.UsuarioTO model, string returnUrl)
        {
            if (!ModelState.IsValidField("NomeUsuario") || !ModelState.IsValidField("Senha"))
            {
                ModelState.AddModelError("", "Nome de usuário e senha são obrigatórios.");
                return View(model);
            }

            try
            {
                var usuarioLogado = _servico.LoginUsuario(model.NomeUsuario, model.Senha);

                if (usuarioLogado != null)
                {
                    FormsAuthentication.SetAuthCookie(usuarioLogado.NomeUsuario, false);

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Nome de usuário ou senha inválidos.");
                }
            }
            catch (FaultException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return View(model);
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TO.UsuarioTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    var usuarioParaServico = new UsuarioTO
                    {
                        Nome = model.Nome,
                        NomeUsuario = model.NomeUsuario,
                        Email = model.Email,
                        Senha = model.Senha
                    };

                    _servico.RegistrarUsuario(usuarioParaServico);

                    FormsAuthentication.SetAuthCookie(model.NomeUsuario, false);

                    return RedirectToAction("Index", "Home");
                }
                catch (FaultException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }

            return View(model);
        }

        // POST: /Account/Logout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public new ActionResult Profile()
        {
            var usuarioDoServico = _servico.GetPerfilUsuario(User.Identity.Name);
            if (usuarioDoServico == null)
            {
                return HttpNotFound();
            }

           
            var usuarioViewModel = new TO.UsuarioTO
            {
                Id = usuarioDoServico.Id,
                Nome = usuarioDoServico.Nome,
                NomeUsuario = usuarioDoServico.NomeUsuario,
                Email = usuarioDoServico.Email
            };

            return View(usuarioViewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(TO.UsuarioTO model)
        {
            if (ModelState.IsValidField("Nome") && ModelState.IsValidField("Email"))
            {
                try
                {
                    var usuarioParaServico = new UsuarioTO
                    {
                        Id = model.Id,
                        Nome = model.Nome,
                        Email = model.Email,
                        Senha = model.Senha 
                    };

                    _servico.AtualizarPerfilUsuario(usuarioParaServico);
                    TempData["SuccessMessage"] = "Perfil atualizado com sucesso!";
                    return RedirectToAction("Profile");
                }
                catch (FaultException ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }
    }
}