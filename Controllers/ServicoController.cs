using Microsoft.AspNetCore.Mvc;
using UPHoteisAPI.Models;
using UPHoteisAPI.Services;

[ApiController]
[Route("[controller]")]
public class ServicoController : ControllerBase
{
    private ServicoService _servicoService;

    public ServicoController(ServicoService servicoService)
    {
        _servicoService = servicoService;
    }

    // POST: Servico/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult<Servico>> Cadastrar(Servico servico)
    {
        if (servico == null)
        {
            return BadRequest("Dados do serviço inválidos.");
        }

        await _servicoService.CadastrarServicoAsync(servico);

        return Created("", servico);
    }

    // GET: Servico/listar
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Servico>>> Listar()
    {
        var servicos = await _servicoService.ListarServicosAsync();

        return Ok(servicos);
    }

    // GET: Servico/buscar/{id}
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Servico>> Buscar(int id)
    {
        var servico = await _servicoService.BuscarServicoAsync(id);

        if (servico == null)
        {
            return NotFound();
        }

        return Ok(servico);
    }

    // PUT: Servico/alterar
    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Servico servico)
    {
        await _servicoService.AlterarServicoAsync(servico);

        return Ok();
    }

    // DELETE: Servico/excluir/{id}
    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        await _servicoService.ExcluirServicoAsync(id);

        return Ok();
    }
}
