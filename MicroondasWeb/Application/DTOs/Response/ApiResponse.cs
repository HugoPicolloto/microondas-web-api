public class ApiResponse
{
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; } = "";
    public object? Dados { get; set; }
}