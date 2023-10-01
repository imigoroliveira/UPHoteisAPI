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
    public class ControladorReservaHotel : ControllerBase
    {
        private HotelAPIDbContext _hotelAPIDbContext;

        public ControladorReservaHotel(HotelAPIDbContext hotelAPIDbContext)
        {
           _hotelAPIDbContext = hotelAPIDbContext;
        }

        // POST: api/ControladorReservaHotel/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult<Reserva>> Cadastrar(Reserva reserva)
        {
            if (reserva == null)
            {
                return BadRequest("Dados de reserva inválidos.");
            }

            await _hotelAPIDbContext.reservas.AddAsync(reserva);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Created("", reserva);
        }

        // GET: api/ControladorReservaHotel/listar
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Reserva>>> Listar()
        {
            var reservas = await _hotelAPIDbContext.reservas.ToListAsync();

            return Ok(reservas);
        }

        // GET: api/ControladorReservaHotel/buscar/{id}
        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Reserva>> Buscar(int id)
        {
            var reserva = await _hotelAPIDbContext.reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return Ok(reserva);
        }

        // PUT: api/ControladorReservaHotel/alterar
        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Reserva reserva)
        {
            var reservaExistente = await _hotelAPIDbContext.reservas.FindAsync(reserva.Id);

            if (reservaExistente == null)
            {
                return NotFound("Reserva não encontradas.");
            }

            reservaExistente.NomeCliente = reserva.NomeCliente;
            reservaExistente.DataEntrada = reserva.DataEntrada;

            _hotelAPIDbContext.reservas.Update(reservaExistente);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/ControladorReservaHotel/excluir/{id}
        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var reserva = await _hotelAPIDbContext.reservas.FindAsync(id);

            if (reserva == null)
            {
                return NotFound("Reserva não encontrada.");
            }

            _hotelAPIDbContext.reservas.Remove(reserva);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
