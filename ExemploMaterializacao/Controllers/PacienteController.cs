using System.Linq;
using System.Web.Mvc;
using ExemploMaterializacao.ServicoExposto;

namespace ExemploMaterializacao.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ServicoSoapClient _servico;

        public PacienteController()
        {
            _servico = new ServicoSoapClient();
        }

        public ActionResult Index()
        {
            var pacientesDoServico = _servico.GetMeusPacientes();
            var pacientesViewModel = pacientesDoServico.Select(p => new TO.PacienteTO
            {
                Id = p.Id,
                Nome = p.Nome,
                NomeMae = p.NomeMae,
                Nascimento = p.Nascimento,
                Sexo = (TO.SexoEnum)p.Sexo
            }).ToList();
            return View(pacientesViewModel);
        }

        public ActionResult Details(int id)
        {
            var pacienteDoServico = _servico.GetPacientePorId(id);
            if (pacienteDoServico == null)
            {
                return HttpNotFound();
            }
            var pacienteViewModel = new TO.PacienteTO
            {
                Id = pacienteDoServico.Id,
                Nome = pacienteDoServico.Nome,
                NomeMae = pacienteDoServico.NomeMae,
                Nascimento = pacienteDoServico.Nascimento,
                Sexo = (TO.SexoEnum)pacienteDoServico.Sexo
            };
            return View(pacienteViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TO.PacienteTO pacienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var pacienteParaServico = new PacienteTO
                {
                    Id = pacienteViewModel.Id,
                    Nome = pacienteViewModel.Nome,
                    NomeMae = pacienteViewModel.NomeMae,
                    Nascimento = pacienteViewModel.Nascimento,
                    Sexo = (SexoEnum)pacienteViewModel.Sexo
                };
                _servico.AdicionarPaciente(pacienteParaServico);
                return RedirectToAction("Index");
            }
            return View(pacienteViewModel);
        }

        public ActionResult Edit(int id)
        {
            var pacienteDoServico = _servico.GetPacientePorId(id);
            if (pacienteDoServico == null)
            {
                return HttpNotFound();
            }
            var pacienteViewModel = new TO.PacienteTO
            {
                Id = pacienteDoServico.Id,
                Nome = pacienteDoServico.Nome,
                NomeMae = pacienteDoServico.NomeMae,
                Nascimento = pacienteDoServico.Nascimento,
                Sexo = (TO.SexoEnum)pacienteDoServico.Sexo
            };
            return View(pacienteViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PacienteTO pacienteDoServico)
        {
            if (ModelState.IsValid)
            {
                _servico.AtualizarPaciente(pacienteDoServico);
                return RedirectToAction("Index");
            }
            return View(pacienteDoServico);
        }

        public ActionResult Delete(int id)
        {
            var pacienteDoServico = _servico.GetPacientePorId(id);
            if (pacienteDoServico == null)
            {
                return HttpNotFound();
            }
            var pacienteViewModel = new TO.PacienteTO
            {
                Id = pacienteDoServico.Id,
                Nome = pacienteDoServico.Nome,
                NomeMae = pacienteDoServico.NomeMae,
                Nascimento = pacienteDoServico.Nascimento,
                Sexo = (TO.SexoEnum)pacienteDoServico.Sexo
            };
            return View(pacienteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _servico.ExcluirPaciente(id);
                return Json(new { success = true });
            }
            catch (System.Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}