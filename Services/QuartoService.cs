using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

public class QuartoService
{
    private HotelAPIDbContext _hotelAPIDbContext;

    public QuartoService(HotelAPIDbContext hotelAPIDbContext)
    {
        _hotelAPIDbContext = hotelAPIDbContext;
    }

    public async Task CadastrarQuartoAsync(Quarto quarto)
    {
        await _hotelAPIDbContext.quartos.AddAsync(quarto);
        await _hotelAPIDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Quarto>> ListarQuartosAsync()
    {
        return await _hotelAPIDbContext.quartos.ToListAsync();
    }

    public async Task<Quarto> BuscarQuartoAsync(int id)
    {
        return await _hotelAPIDbContext.quartos.FindAsync(id);
    }

    public async Task AlterarQuartoAsync(Quarto quarto)
    {
        var quartoExistente = await _hotelAPIDbContext.quartos.FindAsync(quarto.Id);

        quartoExistente.Numero = quarto.Numero;
        quartoExistente.TipoQuarto = quarto.TipoQuarto;

        _hotelAPIDbContext.quartos.Update(quartoExistente);
        await _hotelAPIDbContext.SaveChangesAsync();
    }

    public async Task ExcluirQuartoAsync(int id)
    {
        var quarto = await _hotelAPIDbContext.quartos.FindAsync(id);

        _hotelAPIDbContext.quartos.Remove(quarto);
        await _hotelAPIDbContext.SaveChangesAsync();
    }
}
