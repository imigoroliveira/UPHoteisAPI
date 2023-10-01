using Microsoft.AspNetCore.Mvc;
using UPHoteisAPI.Models;
using UPHoteisAPI.Services;

[ApiController]
[Route("[controller]")]
public class QuartoController : ControllerBase
{
    private QuartoService _quartoService;

    public QuartoController(QuartoService quartoService)
    {
        _quartoService = quartoService;
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult<Hotel>> Cadastrar(Quarto quarto)
    {
        if (quarto == null)
        {
            return BadRequest("Dados de Quartos inválidos.");
        }

        await _quartoService.CadastrarQuartoAsync(quarto);

        return Created("", quarto);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Quarto>>> Listar()
    {
        var quartos = await _quartoService.ListarQuartosAsync();

        return Ok(quartos);
    }

    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Quarto>> Buscar(int id)
    {
        var quarto = await _quartoService.BuscarQuartoAsync(id);

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
        await _quartoService.AlterarQuartoAsync(quarto);

        return Ok();
    }

    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        await _quartoService.ExcluirQuartoAsync(id);

        return Ok();

    }
}