using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

namespace UPHoteisAPI.Services
{
    public class ServicoService
    {
        private readonly HotelAPIDbContext _hotelAPIDbContext;

        public ServicoService(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        public async Task CadastrarServicoAsync(ServicoQuarto servico)
        {
            await _hotelAPIDbContext.Servicos.AddAsync(servico);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ServicoQuarto>> ListarServicosAsync()
        {
            return await _hotelAPIDbContext.Servicos.ToListAsync();
        }

        public async Task<ServicoQuarto> BuscarServicoAsync(int id)
        {
            return await _hotelAPIDbContext.Servicos.FindAsync(id);
        }

        public async Task AlterarServicoAsync(ServicoQuarto servico)
        {
            var servicoAtual = await _hotelAPIDbContext.Servicos.FindAsync(servico.Id);

            if (servicoAtual != null)
            {
                servicoAtual.Nome = servico.Nome;
                servicoAtual.ValorServico = servico.ValorServico;
                servicoAtual.Disponibilidade = servico.Disponibilidade;
                servicoAtual.Horario = servico.Horario;

                await _hotelAPIDbContext.SaveChangesAsync();
            }
        }

        public async Task ExcluirServicoAsync(int id)
        {
            var servico = await _hotelAPIDbContext.Servicos.FindAsync(id);

            if (servico != null)
            {
                _hotelAPIDbContext.Servicos.Remove(servico);
                await _hotelAPIDbContext.SaveChangesAsync();
            }
        }
    }
}