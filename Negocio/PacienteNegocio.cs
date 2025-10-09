using Repositorio;
using System.Collections.Generic;
using TO;

namespace Negocio
{
    public class PacienteNegocio
    {
        private readonly PacienteRepositorio _repositorio = new PacienteRepositorio();

        public PacienteTO GetPacientePorId(int id)
        {
            return _repositorio.GetPacientePorId(id);
        }

        public List<PacienteTO> GetMeusPacientes()
        {
            return _repositorio.GetTodos();
        }

        public void AdicionarPaciente(PacienteTO pacienteTO)
        {
            _repositorio.Novo(pacienteTO);
        }

        public void AtualizarPaciente(PacienteTO pacienteTO)
        {
            _repositorio.Atualiza(pacienteTO);
        }

        public void ExcluirPaciente(int id)
        {
            _repositorio.Excluir(id); // Certifique-se que o método Excluir(id) existe no repositório
        }
    }
}