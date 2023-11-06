using Microsoft.AspNetCore.Mvc;
using UPHoteisAPI.Models;
using UPHoteisAPI.Services;

[ApiController]
[Route("[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly FuncionarioService _funcionarioService;

    public FuncionarioController(FuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }


    // POST: api/FuncionarioController/cadastrar
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult<Funcionario>> Cadastrar(Funcionario funcionario)
    {
        await _funcionarioService.CadastrarFuncionarioAsync(funcionario);

        return Created("", funcionario);
    }

    // GET: api/FuncionarioController/listar
    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Funcionario>>> Listar()
    {
        var funcionarios = await _funcionarioService.ListarFuncionariosAsync();

        return Ok(funcionarios);
    }

    // GET: api/FuncionarioController/buscar/{id}
    [HttpGet]
    [Route("buscar/{id}")]
    public async Task<ActionResult<Funcionario>> Buscar(int id)
    {
        var funcionario = await _funcionarioService.BuscarFuncionarioAsync(id);

        if (funcionario == null)
        {
            return NotFound();
        }

        return Ok(funcionario);
    }

    // PUT: api/FuncionarioController/alterar
    [HttpPut]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Funcionario funcionario)
    {
        await _funcionarioService.AlterarFuncionarioAsync(funcionario);

        return Ok();
    }

    // DELETE: api/FuncionarioController/excluir/{id}
    [HttpDelete]
    [Route("excluir/{id}")]
    public async Task<ActionResult> Excluir(int id)
    {
        await _funcionarioService.ExcluirFuncionarioAsync(id);

        return Ok();
    }
}