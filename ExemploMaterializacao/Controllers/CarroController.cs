using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ExemploMaterializacao.ServicoExposto;

namespace ExemploMaterializacao.Controllers
{
    public class CarroController : Controller
    {
        private readonly ServicoSoapClient _servico = new ServicoSoapClient();

        private void PrepararViewBagAno()
        {
            var anos = new List<SelectListItem>();
            for (int ano = System.DateTime.Now.Year + 1; ano >= 1950; ano--)
            {
                anos.Add(new SelectListItem { Value = ano.ToString(), Text = ano.ToString() });
            }
            ViewBag.Anos = anos;
        }

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

        public ActionResult Create()
        {
            PrepararViewBagAno();
            return View();
        }

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
                TempData["SuccessMessage"] = "Carro adicionado com sucesso!";
                return RedirectToAction("Index");
            }

            PrepararViewBagAno();
            return View(carroViewModel);
        }

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

            PrepararViewBagAno();
            return View(carroViewModel);
        }

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
                TempData["SuccessMessage"] = "Carro atualizado com sucesso!";
                return RedirectToAction("Index");
            }

            PrepararViewBagAno();
            return View(carroViewModel);
        }

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _servico.ExcluirCarro(id);
                return Json(new { success = true, message = "Carro excluído com sucesso!" });
            }
            catch (System.Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}