using Microsoft.AspNetCore.Mvc;
using UPHoteisAPI.Models;
using UPHoteisAPI.Services;

[ApiController]
[Route("[controller]")]
public class AvaliacaoController : ControllerBase
{
    private readonly AvaliacaoService _avaliacaoService;

    public AvaliacaoController(AvaliacaoService avaliacaoService)
    {
        _avaliacaoService = avaliacaoService;
    }


    // POST: api/AvaliacaoController/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult<Avaliacao>> Cadastrar(Avaliacao avaliacao)
    {
        await _avaliacaoService.CadastrarAvaliacaoAsync(avaliacao);

        return Created("", avaliacao);
    }

    // GET: api/AvaliacaoController/listar
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Avaliacao>>> Listar()
    {
        var avaliacoes = await _avaliacaoService.ListarAvaliacoesAsync();

        return Ok(avaliacoes);
    }

    // GET: api/AvaliacaoController/buscar/{id}
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Avaliacao>> Buscar(int id)
    {
        var avaliacao = await _avaliacaoService.BuscarAvaliacaoAsync(id);

        if (avaliacao == null)
        {
            return NotFound();
        }

        return Ok(avaliacao);
    }

    // PUT: api/AvaliacaoController/alterar
    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Avaliacao avaliacao)
    {
        await _avaliacaoService.AlterarAvaliacaoAsync(avaliacao);

        return Ok();
    }

    // DELETE: api/AvaliacaoController/excluir/{id}
    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        await _avaliacaoService.ExcluirAvaliacaoAsync(id);

        return Ok();
    }
}