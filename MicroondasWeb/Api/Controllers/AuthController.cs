using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwt;
    private readonly IUsuarioRepository _repo;

    public AuthController(
        JwtService jwt,
        IUsuarioRepository repo)
    {
        _jwt = jwt;
        _repo = repo;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest req)
    {
        var usuario = _repo.Obter(req.Usuario);

        if (usuario == null)
            return Ok(new ApiResponse
            {
                Sucesso = false,
                Mensagem = "Usuário inválido"
            });

        var senhaHash = HashService.Gerar(req.Senha);

        if (usuario.Senha != senhaHash)
            return Ok(new ApiResponse
            {
                Sucesso = false,
                Mensagem = "Senha inválida"
            });

        var token = _jwt.GerarToken(usuario.Usuario);

        return Ok(new ApiResponse
        {
            Sucesso = true,
            Mensagem = "Login realizado com sucesso",
            Dados = new
            {
                token
            }
        });
    }
}