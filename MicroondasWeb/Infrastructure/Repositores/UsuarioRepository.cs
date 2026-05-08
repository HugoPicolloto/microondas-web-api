public class UsuarioRepository : IUsuarioRepository
{
    private readonly List<LoginRequest> _usuarios = new()
    {
        new LoginRequest
        {
            Usuario = "admin",
            Senha = HashService.Gerar("123")
        }
    };

    public LoginRequest? Obter(string usuario)
    {
        return _usuarios
            .FirstOrDefault(x => x.Usuario == usuario);
    }
}