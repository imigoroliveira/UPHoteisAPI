using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

namespace UPHoteisAPI.Services
{
    public class ClienteService
    {
        private readonly HotelAPIDbContext _hotelAPIDbContext;

        public ClienteService(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        public async Task CadastrarClienteAsync(Cliente cliente)
        {
            await _hotelAPIDbContext.Clientes.AddAsync(cliente);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> ListarClientesAsync()
        {
            return await _hotelAPIDbContext.Clientes.ToListAsync();
        }

        public async Task<Cliente> BuscarClienteAsync(int id)
        {
            return await _hotelAPIDbContext.Clientes.FindAsync(id);
        }

        public async Task AlterarClienteAsync(Cliente cliente)
        {
            var clienteExistente = await _hotelAPIDbContext.Clientes.FindAsync(cliente.Id);

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Cpf = cliente.Cpf;
            clienteExistente.Email = cliente.Email;
            clienteExistente.Contato = cliente.Contato;

            _hotelAPIDbContext.Clientes.Update(clienteExistente);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task ExcluirClienteAsync(int id)
        {
            var cliente = await _hotelAPIDbContext.Clientes.FindAsync(id);

            _hotelAPIDbContext.Clientes.Remove(cliente);
            await _hotelAPIDbContext.SaveChangesAsync();
        }
    }
}
