using Microsoft.AspNetCore.Mvc;
using UPHoteisAPI.Models;
using UPHoteisAPI.Services;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClienteController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    // POST: api/ClienteController/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult<Cliente>> Cadastrar(Cliente cliente)
    {
        await _clienteService.CadastrarClienteAsync(cliente);

        return Created("", cliente);
    }

    // GET: api/ClienteController/listar
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Cliente>>> Listar()
    {
        var clientes = await _clienteService.ListarClientesAsync();

        return Ok(clientes);
    }

    // GET: api/ClienteController/buscar/{id}
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Cliente>> Buscar(int id)
    {
        var cliente = await _clienteService.BuscarClienteAsync(id);

        if (cliente == null)
        {
            return NotFound();
        }

        return Ok(cliente);
    }

    // PUT: api/ClienteController/alterar
    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Cliente cliente)
    {
        await _clienteService.AlterarClienteAsync(cliente);

        return Ok();
    }

    // DELETE: api/ClienteController/excluir/{id}
    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        await _clienteService.ExcluirClienteAsync(id);

        return Ok();
    }
}