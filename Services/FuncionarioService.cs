using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

namespace UPHoteisAPI.Services
{
    public class FuncionarioService
    {
        private readonly HotelAPIDbContext _hotelAPIDbContext;

        public FuncionarioService(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        public async Task CadastrarFuncionarioAsync(Funcionario funcionario)
        {
            await _hotelAPIDbContext.Funcionarios.AddAsync(funcionario);
            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Funcionario>> ListarFuncionariosAsync()
        {
            return await _hotelAPIDbContext.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> BuscarFuncionarioAsync(int id)
        {
            return await _hotelAPIDbContext.Funcionarios.FindAsync(id);
        }

        public async Task AlterarFuncionarioAsync(Funcionario funcionario)
        {
            var funcionarioAnterior = await _hotelAPIDbContext.Funcionarios.FindAsync(funcionario.Id);

            funcionarioAnterior.Nome = funcionario.Nome;
            funcionarioAnterior.CPF = funcionario.CPF;
            funcionarioAnterior.Cargo = funcionario.Cargo;

            _hotelAPIDbContext.Funcionarios.Update(funcionarioAnterior);

            await _hotelAPIDbContext.SaveChangesAsync();
        }

        public async Task ExcluirFuncionarioAsync(int id)
        {
            var funcionario = await _hotelAPIDbContext.Funcionarios.FindAsync(id);

            _hotelAPIDbContext.Funcionarios.Remove(funcionario);
            await _hotelAPIDbContext.SaveChangesAsync();
        }
    }
}