using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

namespace UPHoteisAPI.Services
{
    public class AvaliacaoService
    {
        private readonly HotelAPIDbContext _hotelAPIDbContext;

        public AvaliacaoService(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        public async Task CadastrarAvaliacaoAsync(Avaliacao avaliacoes)
        {
            await _hotelAPIDbContext.Avaliacoes.AddAsync(avaliacoes);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Avaliacao>> ListarAvaliacoesAsync()
        {
            return await _hotelAPIDbContext.Avaliacoes.ToListAsync();
        }

        public async Task<Avaliacao> BuscarAvaliacaoAsync(int id)
        {
            return await _hotelAPIDbContext.Avaliacoes.FindAsync(id);
        }

        public async Task AlterarAvaliacaoAsync(Avaliacao avaliacao)
        {
            var avaliacaoAnterior = await _hotelAPIDbContext.Avaliacoes.FindAsync(avaliacao.Id);

            avaliacaoAnterior.NotaAvaliacao = avaliacao.NotaAvaliacao;

            _hotelAPIDbContext.Avaliacoes.Update(avaliacaoAnterior);

            await _hotelAPIDbContext.SaveChangesAsync();

            if (avaliacaoAnterior.NotaAvaliacao != avaliacao.NotaAvaliacao)
            {
                avaliacaoAnterior.NotaAvaliacao = avaliacao.NotaAvaliacao;
                _hotelAPIDbContext.Avaliacoes.Update(avaliacaoAnterior);

                await _hotelAPIDbContext.SaveChangesAsync();

                var hotelId = avaliacaoAnterior.HotelId;
                AtualizarMediaEstrelas(hotelId);
            }

        }

        public async Task ExcluirAvaliacaoAsync(int id)
        {
            var avaliacao = await _hotelAPIDbContext.Avaliacoes.FindAsync(id);

            _hotelAPIDbContext.Avaliacoes.Remove(avaliacao);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        protected void AtualizarMediaEstrelas(int hotelId)
        {
            var hotel = _hotelAPIDbContext.Hoteis
                .Include(h => h.Avaliacoes)
                .FirstOrDefault(h => h.Id == hotelId);

            double mediaEstrelas = hotel.Avaliacoes.Average(av => av.NotaAvaliacao);
            double media = (mediaEstrelas / 5.0) * 5.0;

            hotel.MediaAvaliacoes = media;

            _hotelAPIDbContext.Hoteis.Update(hotel);
            _hotelAPIDbContext.SaveChanges();
        }

    }
}
