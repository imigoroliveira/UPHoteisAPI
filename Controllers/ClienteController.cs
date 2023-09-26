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
    public class ClienteController : ControllerBase
    {
        private HotelAPIDbContext _hotelAPIDbContext;

        public ClienteController(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        // POST: api/Cliente/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult<Cliente>> Cadastrar(Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Dados do cliente inválidos.");
            }

            await _hotelAPIDbContext.Clientes.AddAsync(cliente);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Created("", cliente);
        }

        // GET: api/Cliente/listar
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
        {
            var clientes = await _hotelAPIDbContext.Clientes.ToListAsync();

            return Ok(clientes);
        }

        // GET: api/Cliente/buscar/{id}
        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Cliente>> Buscar(int id)
        {
            var cliente = await _hotelAPIDbContext.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/Cliente/alterar
        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Cliente cliente)
        {
            var existingCliente = await _hotelAPIDbContext.Clientes.FindAsync(cliente.Id);

            if (existingCliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            existingCliente.Nome = cliente.Nome;
            existingCliente.Email = cliente.Email;

            _hotelAPIDbContext.Clientes.Update(existingCliente);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Cliente/excluir/{id}
        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var cliente = await _hotelAPIDbContext.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _hotelAPIDbContext.Clientes.Remove(cliente);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
