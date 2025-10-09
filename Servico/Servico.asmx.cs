using Negocio;
using System.Collections.Generic;
using System.Web.Services;
using TO;

namespace Servico
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Servico : System.Web.Services.WebService
    {
        private readonly PacienteNegocio _pacienteNegocio = new PacienteNegocio();

        private readonly CarroNegocio _carroNegocio = new CarroNegocio();


        #region Métodos de Paciente (INTOCÁVEIS)

        [WebMethod]
        public List<PacienteTO> GetMeusPacientes()
        {
            return _pacienteNegocio.GetMeusPacientes();
        }

        [WebMethod]
        public PacienteTO GetPacientePorId(int id)
        {
            return _pacienteNegocio.GetPacientePorId(id);
        }

        [WebMethod]
        public void AdicionarPaciente(PacienteTO pacienteTO)
        {
            _pacienteNegocio.AdicionarPaciente(pacienteTO);
        }

        [WebMethod]
        public void AtualizarPaciente(PacienteTO pacienteTO)
        {
            _pacienteNegocio.AtualizarPaciente(pacienteTO);
        }

        [WebMethod]
        public void ExcluirPaciente(int id)
        {
            _pacienteNegocio.ExcluirPaciente(id);
        }

        #endregion


        #region Métodos de Carro (NOVOS)



        [WebMethod]
        public List<CarroTO> GetTodosCarros()
        {
            return _carroNegocio.GetTodos();
        }

        [WebMethod]
        public CarroTO GetCarroPorId(int id)
        {
            return _carroNegocio.GetPorId(id);
        }

        [WebMethod]
        public void AdicionarCarro(CarroTO carroTO)
        {
            _carroNegocio.Adicionar(carroTO);
        }

        [WebMethod]
        public void AtualizarCarro(CarroTO carroTO)
        {
            _carroNegocio.Atualizar(carroTO);
        }

        [WebMethod]
        public void ExcluirCarro(int id)
        {
            _carroNegocio.Excluir(id);
        }

        #endregion
    }
}