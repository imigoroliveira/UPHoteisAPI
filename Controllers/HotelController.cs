using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

namespace UPHoteisAPI.Controllers
{
    public class HotelController : Controller
    {
        private HotelAPIDbContext _hotelAPIDbContext;

        public HotelController(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult<Hotel>> Cadastrar(Hotel hotel)
        {
            if (hotel == null)
            {
                return BadRequest("Dados de Hoteis inválidos.");
            }

            await _hotelAPIDbContext.hoteis.AddAsync(hotel);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Created("", hotel);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Hotel>>> Listar()
        {
            var hoteis = await _hotelAPIDbContext.hoteis.ToListAsync();

            return Ok(hoteis);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Hotel>> Buscar(int id)
        {
            var hotel = await _hotelAPIDbContext.hoteis.FindAsync(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Hotel hotel)
        {
            var hotelExistente = await _hotelAPIDbContext.hoteis.FindAsync(hotel.Id);

            if (hotelExistente == null)
            {
                return NotFound("Hotel não encontrado.");
            }

            hotelExistente.Nome = hotel.Nome;

            _hotelAPIDbContext.hoteis.Update(hotelExistente);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var hotel = await _hotelAPIDbContext.hoteis.FindAsync(id);

            if (hotel == null)
            {
                return NotFound("Hotel não encontrado.");
            }

            _hotelAPIDbContext.hoteis.Remove(hotel);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Ok();

        }
    }
}
