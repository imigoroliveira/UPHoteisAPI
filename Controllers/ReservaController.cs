using Microsoft.AspNetCore.Mvc;
using UPHoteisAPI.Models;

[ApiController]
[Route("[controller]")]
public class ReservaController : ControllerBase
{
    private ReservaService _reservaHotelService;

    public ReservaController(ReservaService reservaHotelService)
    {
        _reservaHotelService = reservaHotelService;
    }

    // POST: api/ReservaController/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult<Reserva>> Cadastrar(Reserva reserva)
    {
        if (reserva == null)
        {
            return BadRequest("Dados de reserva inválidos.");
        }

        await _reservaHotelService.CadastrarReservaAsync(reserva);

        return Created("", reserva);
    }

    // GET: api/ReservaController/listar
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Reserva>>> Listar()
    {
        var reservas = await _reservaHotelService.ListarReservasAsync();

        return Ok(reservas);
    }

    // GET: api/ReservaController/buscar/{id}
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Reserva>> Buscar(int id)
    {
        var reserva = await _reservaHotelService.BuscarReservaAsync(id);

        if (reserva == null)
        {
            return NotFound();
        }

        return Ok(reserva);
    }

    // PUT: api/ReservaController/alterar
    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Reserva reserva)
    {
        await _reservaHotelService.AlterarReservaAsync(reserva);

        return Ok();
    }

    // DELETE: api/ReservaController/excluir/{id}
    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        await _reservaHotelService.ExcluirReservaAsync(id);

        return Ok();
    }
}