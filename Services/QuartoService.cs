using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

namespace UPHoteisAPI.Services
{
    public class QuartoService
    {
        private readonly HotelAPIDbContext _hotelAPIDbContext;

        public QuartoService(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        public async Task CadastrarQuartoAsync(Quarto quarto)
        {
            await _hotelAPIDbContext.Quartos.AddAsync(quarto);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Quarto>> ListarQuartosAsync()
        {
            return await _hotelAPIDbContext.Quartos.ToListAsync();
        }

        public async Task<Quarto> BuscarQuartoAsync(int id)
        {
            return await _hotelAPIDbContext.Quartos.FindAsync(id);
        }

        public async Task AlterarQuartoAsync(Quarto quarto)
        {
            var quartoExistente = await _hotelAPIDbContext.Quartos.FindAsync(quarto.Id);

            quartoExistente.Numero = quarto.Numero;

            _hotelAPIDbContext.Quartos.Update(quartoExistente);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task ExcluirQuartoAsync(int id)
        {
            var quarto = await _hotelAPIDbContext.Quartos.FindAsync(id);

            _hotelAPIDbContext.Quartos.Remove(quarto);
            await _hotelAPIDbContext.SaveChangesAsync();
        }
    }
}
