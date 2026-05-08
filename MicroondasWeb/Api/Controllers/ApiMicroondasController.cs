using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[ApiController]
[Route("api/microondas")]
public class ApiMicroondasController : ControllerBase
{
    private readonly IMicroondasService _service;

    public ApiMicroondasController(IMicroondasService service)
    {
        _service = service;
    }

    [HttpPost("iniciar")]
    public IActionResult Iniciar([FromBody] Aquecimento req)
    {
        var result = _service.Iniciar(req);

        return Ok(new ApiResponse
        {
            Sucesso = true,
            Mensagem = "Micro-ondas iniciado",
            Dados = result
        });
    }

    [HttpPost("tick")]
    public IActionResult Tick()
    {
        var result = _service.Tick();

        return Ok(new ApiResponse
        {
            Sucesso = true,
            Dados = result
        });
    }

    [HttpPost("pause")]
    public IActionResult Pause()
    {
        var result = _service.Pausar();

        return Ok(new ApiResponse
        {
            Sucesso = true,
            Mensagem = "Micro-ondas pausado",
            Dados = result
        });
    }

    [HttpPost("cancel")]
    public IActionResult Cancel()
    {
        _service.Cancelar();

        return Ok(new ApiResponse
        {
            Sucesso = true,
            Mensagem = "Micro-ondas cancelado"
        });
    }

    [HttpGet("status")]
    public IActionResult Status()
    {
        var result = _service.ObterStatus();

        return Ok(new ApiResponse
        {
            Sucesso = true,
            Dados = result
        });
    }
}