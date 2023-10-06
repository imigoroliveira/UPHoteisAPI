using UPHoteisAPI.Data;
using UPHoteisAPI.Models;
using Microsoft.EntityFrameworkCore;

public class ReservaService
{
    private readonly HotelAPIDbContext _hotelAPIDbContext;

    public ReservaService(HotelAPIDbContext hotelAPIDbContext)
    {
        _hotelAPIDbContext = hotelAPIDbContext;
    }

    public async Task CadastrarReservaAsync(Reserva reserva)
    {
        await _hotelAPIDbContext.Reservas.AddAsync(reserva);
        await _hotelAPIDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Reserva>> ListarReservasAsync()
    {
        return await _hotelAPIDbContext.Reservas.ToListAsync();
    }

    public async Task<Reserva> BuscarReservaAsync(int id)
    {
        return await _hotelAPIDbContext.Reservas.FindAsync(id);
    }

    public async Task AlterarReservaAsync(Reserva reserva)
    {
        var reservaExistente = await _hotelAPIDbContext.Reservas.FindAsync(reserva.Id);

        reservaExistente.CheckIn = reserva.CheckIn;
        reservaExistente.CheckOut = reserva.CheckOut;
        reservaExistente.ValorTotal = reserva.ValorTotal;
        reservaExistente.QuartoId = reserva.QuartoId;

        _hotelAPIDbContext.Reservas.Update(reservaExistente);
        await _hotelAPIDbContext.SaveChangesAsync();
    }

    public async Task ExcluirReservaAsync(int id)
    {
        var reserva = await _hotelAPIDbContext.Reservas.FindAsync(id);

        _hotelAPIDbContext.Reservas.Remove(reserva);
        await _hotelAPIDbContext.SaveChangesAsync();
    }
}