using Microsoft.VisualStudio.TestTools.UnitTesting;
using Negocio;
using System;
using TO;

namespace Testes
{
    [TestClass]
    public class PacienteTeste
    {
        [TestMethod]
        public void NovoPaciente()
        {
            try
            {
                PacienteNegocio negPaciente = new PacienteNegocio();
                PacienteTO paciente = new PacienteTO();
                paciente.Nome = "Antônio Roberto";
                paciente.NomeMae = "Deinha";
                paciente.Nascimento = DateTime.Today.AddYears(-10);
                paciente.Sexo = SexoEnum.Masculino; 
                negPaciente.AdicionarPaciente(paciente);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}