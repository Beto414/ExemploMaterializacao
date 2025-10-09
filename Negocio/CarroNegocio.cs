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
            _repositorio.Novo(carroTO);
        }

        public void Atualizar(CarroTO carroTO)
        {
            _repositorio.Atualiza(carroTO);
        }

        public void Excluir(int id)
        {
            _repositorio.Excluir(id);
        }
    }
}