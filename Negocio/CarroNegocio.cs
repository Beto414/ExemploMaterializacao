using Repositorio;
using System.Collections.Generic;
using TO;

namespace Negocio
{
    public class CarroNegocio
    {
        private readonly CarroRepositorio _repositorio;

        public CarroNegocio()
        {
            _repositorio = new CarroRepositorio();
        }

        public List<CarroTO> GetTodos()
        {
            return _repositorio.GetTodos();
        }

        public CarroTO GetPorId(int id)
        {
            return _repositorio.GetPorId(id);
        }

        public void Adicionar(CarroTO carroTO)
        {
            if (_repositorio.PlacaExiste(carroTO.Placa, 0))
            {
                throw new System.Exception("A placa informada já está cadastrada no sistema.");
            }
            _repositorio.Novo(carroTO);
        }

        public void Atualizar(CarroTO carroTO)
        {
            if (_repositorio.PlacaExiste(carroTO.Placa, carroTO.Id))
            {
                throw new System.Exception("A placa informada já está cadastrada para outro veículo.");
            }
            _repositorio.Atualiza(carroTO);
        }

        public void Excluir(int id)
        {
            _repositorio.Excluir(id);
        }
    }
}