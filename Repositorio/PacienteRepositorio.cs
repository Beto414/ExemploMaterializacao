using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TO;

namespace Repositorio
{
    public class PacienteRepositorio : RepositorioBase
    {
        public PacienteTO GetPacientePorId (int id)
        {
            Paciente paciente = this.Contexto.Pacientes.Where(p => p.id == id).FirstOrDefault();
            return paciente.ToPacienteTO();
        }

        public List<PacienteTO> GetTodos()
        {
            List<Paciente> pacientes = this.Contexto.Pacientes.ToList();
            return pacientes.Select(s => s.ToPacienteTO()).ToList();
        }
        public void Novo(PacienteTO paciente)
        {
            Paciente entity = new Paciente();
            entity.DataCriacao = DateTime.Now;
            entity.DataEdicao = DateTime.Now;
            entity.Apply(paciente);
            this.Contexto.Pacientes.Add(entity);
            this.Contexto.SaveChanges();
        }
        public void Atualiza(PacienteTO paciente)
        {
            Paciente entity = this.Contexto.Pacientes.Where(p => p.id == paciente.Id).FirstOrDefault();
            entity.Apply(paciente);
            entity.DataEdicao = DateTime.Now;
            this.Contexto.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            this.Contexto.SaveChanges();
        }
        // ... (dentro da classe PacienteRepositorio)

        public void Excluir(int id)
        {
            Paciente entity = this.Contexto.Pacientes.Find(id);
            if (entity != null)
            {
                this.Contexto.Pacientes.Remove(entity);
                this.Contexto.SaveChanges();
            }
        }
    }
}
