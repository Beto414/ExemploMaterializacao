using Dados; 
using TO;  

namespace Repositorio
{
    public static class CarroConversao
    {
        public static CarroTO ToCarroTO(this Carro entity)
        {
            if (entity == null) return null;

            return new CarroTO
            {
                Id = entity.id, 
                Marca = entity.Marca,
                Modelo = entity.Modelo,
                Ano = entity.Ano,
                Placa = entity.Placa,
                Cor = entity.Cor
            };
        }

        public static void Apply(this Carro entity, CarroTO to)
        {
            if (entity == null || to == null) return;

            entity.Marca = to.Marca;
            entity.Modelo = to.Modelo;
            entity.Ano = to.Ano;
            entity.Placa = to.Placa;
            entity.Cor = to.Cor;
        }
    }
}