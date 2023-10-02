using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

namespace UPHoteisAPI.Services
{
    public class AvaliacaoService
    {
        private HotelAPIDbContext _hotelAPIDbContext;

        public AvaliacaoService(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        public async Task CadastrarAvaliacaoAsync(Avaliacao avaliacoes)
        {
            await _hotelAPIDbContext.avaliacoes.AddAsync(avaliacoes);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Avaliacao>> ListarAvaliacoesAsync()
        {
            return await _hotelAPIDbContext.avaliacoes.ToListAsync();
        }

        public async Task<Avaliacao> BuscarAvaliacaoAsync(int id)
        {
            return await _hotelAPIDbContext.avaliacoes.FindAsync(id);
        }

        public async Task AlterarAvaliacaoAsync(Cliente cliente)
        {
            var avaliacaoExistente = await _hotelAPIDbContext.avaliacoes.FindAsync(cliente.Id);

            avaliacaoExistente.Id = cliente.Id;

            _hotelAPIDbContext.clientes.Update(avaliacaoExistente);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task ExcluirAvaliacaoAsync(int id)
        {
            var avaliacao = await _hotelAPIDbContext.avaliacoes.FindAsync(id);

            _hotelAPIDbContext.clientes.Remove(avaliacao);
            await _hotelAPIDbContext.SaveChangesAsync();
        }
    }
}
