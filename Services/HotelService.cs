using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

namespace UPHoteisAPI.Services
{
    public class HotelService
    {
        private readonly HotelAPIDbContext _hotelAPIDbContext;

        public HotelService(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        public async Task CadastrarHotelAsync(Hotel hotel)
        {
            await _hotelAPIDbContext.Hoteis.AddAsync(hotel);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Hotel>> ListarHoteisAsync()
        {
            return await _hotelAPIDbContext.Hoteis.ToListAsync();
        }

        public async Task<Hotel> BuscarHotelAsync(int id)
        {
            return await _hotelAPIDbContext.Hoteis.FindAsync(id);
        }

        public async Task AlterarHotelAsync(Hotel hotel)
        {
            var hotelExistente = await _hotelAPIDbContext.Hoteis.FindAsync(hotel.Id);

            hotelExistente.Nome = hotel.Nome;
            hotelExistente.Cnpj = hotel.Cnpj;
            hotelExistente.Endereco = hotel.Endereco;
            hotelExistente.Contato = hotel.Contato;

            _hotelAPIDbContext.Hoteis.Update(hotelExistente);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task ExcluirHotelAsync(int id)
        {
            var hotel = await _hotelAPIDbContext.Hoteis.FindAsync(id);

            _hotelAPIDbContext.Hoteis.Remove(hotel);
            await _hotelAPIDbContext.SaveChangesAsync();
        }
    }
}
