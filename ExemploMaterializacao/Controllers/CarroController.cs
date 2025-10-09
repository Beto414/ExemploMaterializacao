using System.Linq;
using System.Web.Mvc;
using ExemploMaterializacao.ServicoExposto;

namespace ExemploMaterializacao.Controllers
{
    public class CarroController : Controller
    {
        private readonly ServicoSoapClient _servico = new ServicoSoapClient();

        // GET: Carro
        public ActionResult Index()
        {
            var carrosDoServico = _servico.GetTodosCarros();
            var carrosViewModel = carrosDoServico.Select(c => new TO.CarroTO
            {
                Id = c.Id,
                Marca = c.Marca,
                Modelo = c.Modelo,
                Ano = c.Ano,
                Placa = c.Placa,
                Cor = c.Cor
            }).ToList();
            return View(carrosViewModel);
        }

        // GET: Carro/Details/5
        public ActionResult Details(int id)
        {
            var carroDoServico = _servico.GetCarroPorId(id);
            if (carroDoServico == null)
            {
                return HttpNotFound();
            }
            var carroViewModel = new TO.CarroTO
            {
                Id = carroDoServico.Id,
                Marca = carroDoServico.Marca,
                Modelo = carroDoServico.Modelo,
                Ano = carroDoServico.Ano,
                Placa = carroDoServico.Placa,
                Cor = carroDoServico.Cor
            };
            return View(carroViewModel);
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TO.CarroTO carroViewModel)
        {
            if (ModelState.IsValid)
            {
                var carroParaServico = new CarroTO
                {
                    Marca = carroViewModel.Marca,
                    Modelo = carroViewModel.Modelo,
                    Ano = carroViewModel.Ano,
                    Placa = carroViewModel.Placa,
                    Cor = carroViewModel.Cor
                };
                _servico.AdicionarCarro(carroParaServico);
                return RedirectToAction("Index");
            }
            return View(carroViewModel);
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int id)
        {
            var carroDoServico = _servico.GetCarroPorId(id);
            if (carroDoServico == null)
            {
                return HttpNotFound();
            }
            var carroViewModel = new TO.CarroTO
            {
                Id = carroDoServico.Id,
                Marca = carroDoServico.Marca,
                Modelo = carroDoServico.Modelo,
                Ano = carroDoServico.Ano,
                Placa = carroDoServico.Placa,
                Cor = carroDoServico.Cor
            };
            return View(carroViewModel);
        }

        // POST: Carro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TO.CarroTO carroViewModel)
        {
            if (ModelState.IsValid)
            {
                var carroParaServico = new CarroTO
                {
                    Id = carroViewModel.Id,
                    Marca = carroViewModel.Marca,
                    Modelo = carroViewModel.Modelo,
                    Ano = carroViewModel.Ano,
                    Placa = carroViewModel.Placa,
                    Cor = carroViewModel.Cor
                };
                _servico.AtualizarCarro(carroParaServico);
                return RedirectToAction("Index");
            }
            return View(carroViewModel);
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int id)
        {
            var carroDoServico = _servico.GetCarroPorId(id);
            if (carroDoServico == null)
            {
                return HttpNotFound();
            }
            var carroViewModel = new TO.CarroTO
            {
                Id = carroDoServico.Id,
                Marca = carroDoServico.Marca,
                Modelo = carroDoServico.Modelo,
                Ano = carroDoServico.Ano,
                Placa = carroDoServico.Placa,
                Cor = carroDoServico.Cor
            };
            return View(carroViewModel);
        }

        // POST: Carro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _servico.ExcluirCarro(id);
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