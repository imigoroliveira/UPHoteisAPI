using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UPHoteisAPI.Services
{
    public class ServicoService
    {
        private HotelAPIDbContext _hotelAPIDbContext;

        public ServicoService(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        public async Task CadastrarServicoAsync(Servico servico)
        {
            await _hotelAPIDbContext.servicos.AddAsync(servico);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Servico>> ListarServicosAsync()
        {
            return await _hotelAPIDbContext.servicos.ToListAsync();
        }

        public async Task<Servico> BuscarServicoAsync(int id)
        {
            return await _hotelAPIDbContext.servicos.FindAsync(id);
        }

        public async Task AlterarServicoAsync(Servico servico)
        {
            var servicoAtual = await _hotelAPIDbContext.servicos.FindAsync(servico.Id);

            if (servicoAtual != null)
            {
                // Atualize os campos do serviço conforme necessário
                servicoAtual.Nome = servico.Nome;
                servicoAtual.Preco = servico.Preco;
                servicoAtual.Disponibilidade = servico.Disponibilidade;
                servicoAtual.HorarioFuncionamento = servico.HorarioFuncionamento;

                await _hotelAPIDbContext.SaveChangesAsync();
            }
        }

        public async Task ExcluirServicoAsync(int id)
        {
            var servico = await _hotelAPIDbContext.servicos.FindAsync(id);

            if (servico != null)
            {
                _hotelAPIDbContext.servicos.Remove(servico);
                await _hotelAPIDbContext.SaveChangesAsync();
            }
        }
    }
}
