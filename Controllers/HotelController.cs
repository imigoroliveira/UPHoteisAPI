using Microsoft.AspNetCore.Mvc;
using UPHoteisAPI.Models;
using UPHoteisAPI.Services;

[ApiController]
[Route("[controller]")]
public class HotelController : ControllerBase
{
    private HotelService _hotelService;

    public HotelController(HotelService hotelService)
    {
        _hotelService = hotelService;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult<Hotel>> Cadastrar(Hotel hotel)
    {
        if (hotel == null)
        {
            return BadRequest("Dados de Hoteis inválidos.");
        }

        await _hotelService.CadastrarHotelAsync(hotel);

        return Created("", hotel);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Hotel>>> Listar()
    {
        var hoteis = await _hotelService.ListarHoteisAsync();

        return Ok(hoteis);
    }

    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Hotel>> Buscar(int id)
    {
        var hotel = await _hotelService.BuscarHotelAsync(id);

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
        await _hotelService.AlterarHotelAsync(hotel);

        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        await _hotelService.ExcluirHotelAsync(id);

        return Ok();

    }
}