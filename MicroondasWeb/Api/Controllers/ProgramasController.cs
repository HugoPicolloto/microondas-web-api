using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MicroondasWeb.Application.DTOs.Request;

[ApiController]
[Route("api/programas")]
public class ProgramasController : ControllerBase
{
    private readonly IProgramaService _service;
    private readonly IMicroondasService _microondas;

    public ProgramasController(
        IProgramaService service,
        IMicroondasService microondas)
    {
        _service = service;
        _microondas = microondas;
    }

    [HttpGet("listarTodos")]
    public IActionResult Listar()
    {
        var result = _service.Listar();

        return Ok(new ApiResponse
        {
            Sucesso = true,
            Dados = result
        });
    }

    [Authorize]
    [HttpPost("criar")]
    public IActionResult Criar([FromBody] Programa request)
    {
        var result = _service.Criar(request);

        return Ok(new ApiResponse
        {
            Sucesso = true,
            Mensagem = "Programa criado",
            Dados = result
        });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public IActionResult Remover(Guid id)
    {
        _service.Remover(id);

        return Ok(new ApiResponse
        {
            Sucesso = true,
            Mensagem = "Programa removido"
        });
    }

    [Authorize]
    [HttpPost("{programa}")]
    public IActionResult Iniciar(string programa)
    {
        var result = _microondas.IniciarPrograma(programa);

        return Ok(new ApiResponse
        {
            Sucesso = true,
            Mensagem = "Programa iniciado",
            Dados = result
        });
    }
}