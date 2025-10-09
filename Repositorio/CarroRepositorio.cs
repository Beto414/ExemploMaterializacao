using Dados;
using System.Collections.Generic;
using System.Linq;
using TO;

namespace Repositorio
{
    public class CarroRepositorio : RepositorioBase
    {
        public List<CarroTO> GetTodos()
        {
            return this.Contexto.Carroes.ToList().Select(s => s.ToCarroTO()).ToList();
        }

        public CarroTO GetPorId(int id)
        {
            return this.Contexto.Carroes.FirstOrDefault(c => c.id == id).ToCarroTO();
        }

        public void Novo(CarroTO carroTO)
        {
            Carro entity = new Carro();
            entity.Apply(carroTO);

            this.Contexto.Carroes.Add(entity);
            this.Contexto.SaveChanges();
        }

        public void Atualiza(CarroTO carroTO)
        {
            Carro entity = this.Contexto.Carroes.FirstOrDefault(c => c.id == carroTO.Id);
            if (entity != null)
            {
                entity.Apply(carroTO);
                this.Contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                this.Contexto.SaveChanges();
            }
        }

        public void Excluir(int id)
        {
            Carro entity = this.Contexto.Carroes.Find(id);
            if (entity != null)
            {
                this.Contexto.Carroes.Remove(entity);
                this.Contexto.SaveChanges();
            }
        }
    }
}