public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException ex)
        {
            context.Response.StatusCode = 400;

            await context.Response.WriteAsJsonAsync(new
            {
                sucesso = false,
                mensagem = ex.Message
            });
        }
        catch (Exception ex)
        {
            File.AppendAllText(
                "logs.txt",
                $"{DateTime.Now}\n{ex}\n\n");

            context.Response.StatusCode = 500;

            await context.Response.WriteAsJsonAsync(new
            {
                sucesso = false,
                mensagem = "Erro interno"
            });
        }
    }
}