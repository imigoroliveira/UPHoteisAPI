using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

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
                // Atualize os atributos do serviço conforme necessário.
                servicoAtual.CheckIn = servico.CheckIn;
                servicoAtual.CheckOut = servico.CheckOut;
                servicoAtual.ValorTotal = servico.ValorTotal;
                servicoAtual.Reservado = servico.Reservado;
                servicoAtual.ClienteId = servico.ClienteId;
                servicoAtual.QuartoId = servico.QuartoId;

                _hotelAPIDbContext.servicos.Update(servicoAtual);
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
