using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

namespace API_Hotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControladorCliente : ControllerBase
    {
        private HotelAPIDbContext _hotelAPIDbContext;

        public ControladorCliente(HotelAPIDbContext hotelAPIDbContext)
        {
           _hotelAPIDbContext = hotelAPIDbContext;
        }

        // POST: api/ControladorCliente/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult<Cliente>> Cadastrar(Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Dados de cliente inválidos.");
            }

            await _hotelAPIDbContext.clientes.AddAsync(cliente);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Created("", cliente);
        }

        // GET: api/ControladorCliente/listar
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
        {
            var clientes = await _hotelAPIDbContext.clientes.ToListAsync();

            return Ok(clientes);
        }

        // GET: api/ControladorCliente/buscar/{id}
        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Cliente>> Buscar(int id)
        {
            var cliente = await _hotelAPIDbContext.clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/ControladorCliente/alterar
        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Cliente cliente)
        {
            var clienteExistente = await _hotelAPIDbContext.clientes.FindAsync(cliente.Id);

            if (clienteExistente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            clienteExistente.Nome = cliente.Nome;

            _hotelAPIDbContext.clientes.Update(clienteExistente);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/ControladorCliente/excluir/{id}
        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var cliente = await _hotelAPIDbContext.clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _hotelAPIDbContext.clientes.Remove(cliente);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
