using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

namespace UPHoteisAPI.Services
{
    public class HotelService
    {
        private HotelAPIDbContext _hotelAPIDbContext;

        public HotelService(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        public async Task CadastrarHotelAsync(Hotel hotel)
        {
            await _hotelAPIDbContext.hoteis.AddAsync(hotel);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> ListarHoteisAsync()
        {
            return await _hotelAPIDbContext.hoteis.ToListAsync();
        }

        public async Task<Hotel> BuscarHotelAsync(int id)
        {
            return await _hotelAPIDbContext.hoteis.FindAsync(id);
        }

        public async Task AlterarHotelAsync(Hotel hotel)
        {
            var hotelExistente = await _hotelAPIDbContext.hoteis.FindAsync(hotel.Id);

            hotelExistente.Nome = hotel.Nome;

            _hotelAPIDbContext.hoteis.Update(hotelExistente);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task ExcluirHotelAsync(int id)
        {
            var hotel = await _hotelAPIDbContext.hoteis.FindAsync(id);

            _hotelAPIDbContext.hoteis.Remove(hotel);
            await _hotelAPIDbContext.SaveChangesAsync();
        }
    }
}
