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

        public async Task AlterarAvaliacaoAsync(Avaliacao avaliacao)
        {
            var avaliacaoAtual = await _hotelAPIDbContext.avaliacoes.FindAsync(avaliacao.Id);
   
            avaliacaoAtual.Estrelas = avaliacao.Estrelas;

            _hotelAPIDbContext.avaliacoes.Update(avaliacaoAtual);

            await _hotelAPIDbContext.SaveChangesAsync();

            if (avaliacaoAtual != null)
            {
                var hotelId = avaliacaoAtual.Hotel.Id;
                AtualizarMediaEstrelas(hotelId);
            }

        }

        public async Task ExcluirAvaliacaoAsync(int id)
        {
            var avaliacao = await _hotelAPIDbContext.avaliacoes.FindAsync(id);

            _hotelAPIDbContext.avaliacoes.Remove(avaliacao);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        protected void AtualizarMediaEstrelas(int hotelId)
        {
            var hotel = _hotelAPIDbContext.hoteis
                .Include(h => h.Avaliacoes)
                .FirstOrDefault(h => h.Id == hotelId);

            double mediaEstrelas = hotel.Avaliacoes.Average(av => av.Estrelas);
            double media = (mediaEstrelas / 5.0) * 5.0;

            hotel.MediaEstrelas = media;

            _hotelAPIDbContext.hoteis.Update(hotel);
            _hotelAPIDbContext.SaveChanges();
        }

    }
}
