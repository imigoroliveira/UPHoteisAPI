using UPHoteisAPI.Data;
using UPHoteisAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ReservaService
{
    private HotelAPIDbContext _hotelAPIDbContext;

    public ReservaService(HotelAPIDbContext hotelAPIDbContext)
    {
        _hotelAPIDbContext = hotelAPIDbContext;
    }

    public async Task CadastrarReservaAsync(Reserva reserva)
    {
        var quarto = await _hotelAPIDbContext.quartos.FindAsync(reserva.QuartoId);
        if (quarto == null)
        {
            throw new ArgumentException("O id do quarto não existe.");
        }

        quarto.Disponibilidade = false;

        await _hotelAPIDbContext.reservas.AddAsync(reserva);
        await _hotelAPIDbContext.SaveChangesAsync();
    }


    public async Task<IEnumerable<Reserva>> ListarReservasAsync()
    {
        return await _hotelAPIDbContext.reservas.ToListAsync();
    }

    public async Task<Reserva> BuscarReservaAsync(int id)
    {
        return await _hotelAPIDbContext.reservas.FindAsync(id);
    }

    public async Task AlterarReservaAsync(Reserva reserva)
    {
        var reservaExistente = await _hotelAPIDbContext.reservas.FindAsync(reserva.Id);

        reservaExistente.CheckIn = reserva.CheckIn;

        _hotelAPIDbContext.reservas.Update(reservaExistente);
        await _hotelAPIDbContext.SaveChangesAsync();
    }

    public async Task ExcluirReservaAsync(int id)
    {
        var reserva = await _hotelAPIDbContext.reservas.FindAsync(id);

        _hotelAPIDbContext.reservas.Remove(reserva);
        await _hotelAPIDbContext.SaveChangesAsync();
    }
}