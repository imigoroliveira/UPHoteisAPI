using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UPHoteisAPI.Data;
using UPHoteisAPI.Models;

namespace UPHoteisAPI.Controllers
{
    public class QuartoController : Controller
    {
        private HotelAPIDbContext _hotelAPIDbContext;

        public QuartoController(HotelAPIDbContext hotelAPIDbContext)
        {
            _hotelAPIDbContext = hotelAPIDbContext;
        }

        [HttpPost]
        [Route("cadastrar")]
        public async Task<ActionResult<Hotel>> Cadastrar(Quarto quarto)
        {
            if (quarto == null)
            {
                return BadRequest("Dados de Quartos inválidos.");
            }

            await _hotelAPIDbContext.quartos.AddAsync(quarto);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Created("", quarto);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<ActionResult<IEnumerable<Quarto>>> Listar()
        {
            var quartos = await _hotelAPIDbContext.quartos.ToListAsync();

            return Ok(quartos);
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public async Task<ActionResult<Quarto>> Buscar(int id)
        {
            var quarto = await _hotelAPIDbContext.quartos.FindAsync(id);

            if (quarto == null)
            {
                return NotFound();
            }

            return Ok(quarto);
        }

        [HttpPut]
        [Route("alterar")]
        public async Task<ActionResult> Alterar(Quarto quarto)
        {
            var quartoExistente = await _hotelAPIDbContext.quartos.FindAsync(quarto.Id);

            if (quartoExistente == null)
            {
                return NotFound("Quarto não encontrado.");
            }

            quartoExistente.Numero = quarto.Numero;

            _hotelAPIDbContext.quartos.Update(quartoExistente);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var quarto = await _hotelAPIDbContext.quartos.FindAsync(id);

            if (quarto == null)
            {
                return NotFound("Quarto não encontrado.");
            }

            _hotelAPIDbContext.quartos.Remove(quarto);
            await _hotelAPIDbContext.SaveChangesAsync();

            return Ok();

        }
    }
}
