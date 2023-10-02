using Microsoft.AspNetCore.Mvc;
using UPHoteisAPI.Models;
using UPHoteisAPI.Services;

[ApiController]
[Route("[controller]")]
public class AvaliacaoController : ControllerBase
{
    private AvaliacaoService _avaliacaoService;

    public AvaliacaoController(AvaliacaoService avaliacaoService)
    {
        _avaliacaoService = avaliacaoService;
    }


    // POST: api/AvaliacaoController/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult<Cliente>> Cadastrar(Cliente cliente)
    {
        if (cliente == null)
        {
            return BadRequest("Dados de cliente inválidos.");
        }

        await _avaliacaoService.CadastrarClienteAsync(cliente);

        return Created("", cliente);
    }

    // GET: api/AvaliacaoController/listar
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
    {
        var clientes = await _avaliacaoService.ListarClientesAsync();

        return Ok(clientes);
    }

    // GET: api/AvaliacaoController/buscar/{id}
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Cliente>> Buscar(int id)
    {
        var cliente = await _avaliacaoService.BuscarClienteAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }

    // PUT: api/AvaliacaoController/alterar
    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Cliente cliente)
    {
        await _avaliacaoService.AlterarClienteAsync(cliente);

        return Ok();
    }

    // DELETE: api/AvaliacaoController/excluir/{id}
    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        await _avaliacaoService.ExcluirClienteAsync(id);

        return Ok();
    }
}