using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

namespace UPHoteisAPI.Services
{
    public class ClienteService
    {
        private HotelAPIDbContext _hotelAPIDbContext;

        public ClienteService(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        public async Task CadastrarClienteAsync(Cliente cliente)
        {
            await _hotelAPIDbContext.clientes.AddAsync(cliente);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> ListarClientesAsync()
        {
            return await _hotelAPIDbContext.clientes.ToListAsync();
        }

        public async Task<Cliente> BuscarClienteAsync(int id)
        {
            return await _hotelAPIDbContext.clientes.FindAsync(id);
        }

        public async Task AlterarClienteAsync(Cliente cliente)
        {
            var clienteExistente = await _hotelAPIDbContext.clientes.FindAsync(cliente.Id);

            clienteExistente.Nome = cliente.Nome;

            _hotelAPIDbContext.clientes.Update(clienteExistente);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task ExcluirClienteAsync(int id)
        {
            var cliente = await _hotelAPIDbContext.clientes.FindAsync(id);

            _hotelAPIDbContext.clientes.Remove(cliente);
            await _hotelAPIDbContext.SaveChangesAsync();
        }
    }
}
