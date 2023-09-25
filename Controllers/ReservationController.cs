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
    public class HotelReservationController : ControllerBase
    {
        private HotelAPIDbContext _dbContext;

        public HotelReservationController(HotelAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: api/HotelReservation/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult<Reservation>> Cadastrar(Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest("Dados de reserva inválidos.");
            }

            await _dbContext.Reservations.AddAsync(reservation);
            await _dbContext.SaveChangesAsync();

            return Created("", reservation);
        }

        // GET: api/HotelReservation/listar
        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Reservation>>> Listar()
        {
            var reservations = await _dbContext.Reservations.ToListAsync();

            return Ok(reservations);
        }

        // GET: api/HotelReservation/buscar/{id}
        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Reservation>> Buscar(int id)
        {
            var reservation = await _dbContext.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/HotelReservation/alterar
        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Reservation reservation)
        {
            var existingReservation = await _dbContext.Reservations.FindAsync(reservation.id);

            if (existingReservation == null)
            {
                return NotFound("Reserva não encontrada.");
            }

            existingReservation.ClientName = reservation.ClientName;
            existingReservation.CheckInDate = reservation.CheckInDate;

            _dbContext.Reservations.Update(existingReservation);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/HotelReservation/excluir/{id}
        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var reservation = await _dbContext.Reservations.FindAsync(id);

            if (reservation == null)
            {
                return NotFound("Reserva não encontrada.");
            }

            _dbContext.Reservations.Remove(reservation);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
